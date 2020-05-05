using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SendGrid;
using SendGrid.Helpers.Mail;
using VehicleHistory.Logic.DB;
using VehicleHistory.Logic.Extensions;
using VehicleHistory.Logic.Helpers;
using VehicleHistory.Logic.Models.Database;
using VehicleHistory.Logic.Models.Dtos;
using VehicleHistory.Logic.Models.Enums;
using VehicleHistory.Logic.Models.Utility;
using VehicleHistory.Logic.Services.Interfaces;

namespace VehicleHistory.Logic.Services.Implementations
{
    public class LocationsService : ILocationsService
    {
        private VehicleHistoryContext _context;

        public LocationsService(VehicleHistoryContext context)
        {
            _context = context;
        }
        public void Create(LocationApplication application)
        {
            var userWithEmail = _context.Users.FirstOrDefault(x => x.Email == application.Email);

            if (userWithEmail != null)
            {
                throw new AppException("There is already a user registered with this E-Mail address");
            }
            if (!StringExtenstions.IsValid(application.Line1))
            {
                throw new AppException("Address Line 1 cannot be empty.");
            }
            if (!StringExtenstions.IsValid(application.ZipCode))
            {
                throw new AppException("Zip code cannot be empty.");
            }
            if (!StringExtenstions.IsValid(application.Line2))
            {
                throw new AppException("Address Line 2 cannot be empty.");
            }
            if (!StringExtenstions.IsValid(application.Name))
            {
                throw new AppException("The location must have a name.");
            }

            _context.LocationApplications.Add(application);
            _context.SaveChanges();
        }

        public async void HandleApplication(bool accepted, string id, AppSettings settings)
        {
            var application = _context.LocationApplications.FirstOrDefault(x => x.Id == Guid.Parse(id));

            if (application == null)
            {
                throw new AppException("Application not found");
            }

            application.Status = accepted ? 1 : -1;

            _context.SaveChanges();

            if (accepted)
            {
                var newLocation = new Location
                {
                    ApartmentNumber = application.ApartmentNumber,
                    Line1 = application.Line1,
                    Line2 = application.Line2,
                    LocationType = application.LocationType,
                    Name = application.Name,
                    ZipCode = application.ZipCode
                };
                _context.Locations.Add(newLocation);
                var generatedPassword = Crypto.GenerateRendomPassword();
                Crypto.CreatePasswordHash(generatedPassword, out var generatedPassHash, out var generatedPassSalt);
                var builder = new DbContextOptionsBuilder<VehicleHistoryContext>();
                builder.UseSqlServer(settings.ConnectionString);
                using (var context = new VehicleHistoryContext(builder.Options))
                {
                    context.Users.Add(new User
                    {
                        Location = newLocation,
                        FirstName = "undefined",
                        LastName = "undefined",
                        Email = application.Email,
                        Group = UserGroups.ShopOwner,
                        PasswordHash = generatedPassHash,
                        PasswordSalt = generatedPassSalt,
                        PasswordRecoveryActive = true
                    });

                    var emailSubject = "Your application has been accepted";
                    var emailBody = $"Use the following password the next time you log in: <b>{generatedPassword}</b>. " +
                                    $"You will be prompted to change the password when you log in.";

                    var client = new SendGridClient(settings.SendGridKey);
                    var message = new SendGridMessage
                    {
                        From = new EmailAddress("235028@student.pwr.edu.pl", "Vehicle History Account Management"),
                        Subject = emailSubject,
                        HtmlContent = emailBody
                    };

                    message.AddTo(new EmailAddress(application.Email));
                    await client.SendEmailAsync(message);
                    await context.SaveChangesAsync();
                }
            }
            else
            {
                var builder = new DbContextOptionsBuilder<VehicleHistoryContext>();
                builder.UseSqlServer(settings.ConnectionString);
                using (var context = new VehicleHistoryContext(builder.Options))
                {

                    var emailSubject = "Your application has been rejected";
                    var emailBody = $"You can try applying again or contacting the administrators if you believe this decision is unwarranted.";

                    var client = new SendGridClient(settings.SendGridKey);
                    var message = new SendGridMessage
                    {
                        From = new EmailAddress("235028@student.pwr.edu.pl", "Vehicle History Account Management"),
                        Subject = emailSubject,
                        HtmlContent = emailBody
                    };

                    message.AddTo(new EmailAddress(application.Email));
                    await client.SendEmailAsync(message);
                    await context.SaveChangesAsync();
                }
            }
        }

        public IList<LocationApplication> GetActiveApplications()
        {
            return _context.LocationApplications.Where(x => x.Status == 0).ToList();
        }

        public IList<User> GetLocationOperators(LocationDto location)
        {
            return _context.Users.Where(x => x.Group == UserGroups.ShopOwner && x.LocationId.ToString() == location.Id).ToList();
        }
    }
}
