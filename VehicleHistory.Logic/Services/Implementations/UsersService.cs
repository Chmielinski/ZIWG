using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using SendGrid;
using SendGrid.Helpers.Mail;
using VehicleHistory.Logic.DB;
using VehicleHistory.Logic.Helpers;
using VehicleHistory.Logic.Models.Database;
using VehicleHistory.Logic.Models.Dtos;
using VehicleHistory.Logic.Models.Enums;
using VehicleHistory.Logic.Models.Utility;
using VehicleHistory.Logic.Services.Interfaces;

namespace VehicleHistory.Logic.Services.Implementations
{
    public class UsersService : IUsersService
    {
        private VehicleHistoryContext _context;
        private IEmailSender _emailSender;

        public UsersService(VehicleHistoryContext context, IEmailSender emailSender)
        {
            _context = context;
            _emailSender = emailSender;
        }
		
		public User Authenticate(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return null;
            }

            var user = _context.Users.SingleOrDefault(x => x.Email == email && !x.Archival);

            if (user == null)
            {
                return null;
            }

            if (!Crypto.VerifyPasswordHash(user.PasswordHash, user.PasswordSalt, password))
            {
                return null;
            }

            return user;
        }

        private static bool VerifyPasswordHash(byte[] storedHash, byte[] storedSalt, string passwordInput)
        {
            if (passwordInput == null)
            {
                throw new ArgumentNullException("passwordInput");
            }

            if (string.IsNullOrWhiteSpace(passwordInput))
            {
                throw new ArgumentException("Password cannot be empty or whitespace only");
            }

            if (storedHash.Length != 64)
            {
                throw new ArgumentException("Invalid password hash length");
            }

            if (storedSalt.Length != 128)
            {
                throw new ArgumentException("Invalid password salt length");
            }

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(passwordInput));
                for (var i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public User Create(User user, string password)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password))
            {
                throw new AppException("Invalid password");
            }

            if (_context.Users.Any(x => x.Email == user.Email && !x.Archival))
            {
                throw new AppException("Specified E-Mail address is already taken");
            }

            Crypto.CreatePasswordHash(password, out var passwordHash, out var passwordSalt);

            user.PasswordSalt = passwordSalt;
            user.PasswordHash = passwordHash;

            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }

            if (string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Password cannot be empty or whitespace only");
            }

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public IList<User> GetAll()
        {
            return _context.Users.Where(x => !x.Archival).ToList();
        }

        public User GetUserById(string id)
        {
            return _context.Users.FirstOrDefault(x => x.Id.ToString() == id);
        }

        public void UpdateUser(User userParam, string password = null)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == userParam.Id);

            if (user == null)
            {
                throw new AppException("User not found");
            }

            if (user.Email != userParam.Email)
            {
                if (_context.Users.Any(x => x.Email == userParam.Email && !x.Archival))
                {
                    throw new AppException("Another user is already registered under this E-Mail address");
                }
            }

            user.FirstName = userParam.FirstName;
            user.LastName = userParam.LastName;
            user.Email = userParam.Email;
            user.UpdateDate = DateTime.Now;
            user.PasswordRecoveryActive = false;

            if (!string.IsNullOrEmpty(password) || !string.IsNullOrWhiteSpace(password))
            {
                Crypto.CreatePasswordHash(password, out var passwordHash, out var passwordSalt);
                user.PasswordSalt = passwordSalt;
                user.PasswordHash = passwordHash;
            }

            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void DeleteUser(string id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id.ToString() == id);

            if (user == null)
            {
                throw new AppException("User does not exist");
            }
            _context.Remove(user);
            _context.SaveChanges();
        }
        public User GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(x => x.Email == email && !x.Archival);
        }

        public async void SendPasswordRecoveryEmail(User userParam, AppSettings settings)
        {
            var builder = new DbContextOptionsBuilder<VehicleHistoryContext>();
            builder.UseSqlServer(settings.ConnectionString);
            using (var context = new VehicleHistoryContext(builder.Options))
            {
                var generatedPassword = Crypto.GenerateRendomPassword();
                Crypto.CreatePasswordHash(generatedPassword, out var generatedPassHash, out var generatedPassSalt);
                var user = context.Users.FirstOrDefault(x => x.Id.ToString() == userParam.Id.ToString());
                if (user == null)
                {
                    throw new AppException("An error occured when trying to get the user object from the database.");
                }
                user.PasswordHash = generatedPassHash;
                user.PasswordSalt = generatedPassSalt;
                user.PasswordRecoveryActive = true;

                var emailSubject = "Your Password has been reset";
                var emailBody = $"Use the following password the next time you log in: <b>{generatedPassword}</b>. " +
                                $"You will be prompted to change the password when you log in.";

                await _emailSender.SendEmailAsync(user.Email, emailSubject, emailBody);
                await context.SaveChangesAsync();
            }
        }

        public bool IsPasswordCorrect(string input, string email)
        {
            var user = GetUserByEmail(email);
            if (user == null)
            {
                throw new AppException("User not found");
            }

            return Crypto.VerifyPasswordHash(user.PasswordHash, user.PasswordSalt, input);
        }

        public void CheckUserData(User user)
        {
            var userDb = GetUserById(user.Id.ToString());
            if (userDb == null)
            {
                throw new AppException("No user found");
            }

            if (user.Email != userDb.Email || user.Group != userDb.Group || user.LocationId != userDb.LocationId)
            {
                throw new AppException("Incoming data is not integral with database");
            }
        }
    }
}
