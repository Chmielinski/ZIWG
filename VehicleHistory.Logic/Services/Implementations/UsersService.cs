using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using VehicleHistory.Logic.DB;
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

        public UsersService(VehicleHistoryContext context)
        {
            _context = context;
        }
		
		public User Authenticate(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return null;
            }

            var user = _context.Users.SingleOrDefault(x => x.Email == email);

            if (user == null)
            {
                return null;
            }

            if (!VerifyPasswordHash(user.PasswordHash, user.PasswordSalt, password))
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

            if (_context.Users.Any(x => x.Email == user.Email))
            {
                throw new AppException("Specified E-Mail address is already taken");
            }

            CreatePasswordHash(password, out var passwordHash, out var passwordSalt);

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
            return _context.Users.ToList();
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
                if (_context.Users.Any(x => x.Email == userParam.Email))
                {
                    throw new AppException("Another user is already registered under this E-Mail address");
                }
            }

            user.FirstName = userParam.FirstName;
            user.LastName = userParam.LastName;
            user.Email = userParam.Email;

            if (!string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password))
            {
                CreatePasswordHash(password, out var passwordHash, out var passwordSalt);
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
    }
}
