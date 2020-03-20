using System.Collections.Generic;
using VehicleHistory.Logic.Models.Database;

namespace VehicleHistory.Logic.Services.Interfaces
{
    public interface IUsersService
    {
		User Authenticate(string email, string password);
        User Create(User user, string password);
        IList<User> GetAll();
        User GetUserById(string id);
        void UpdateUser(User user, string password);
        void DeleteUser(string id);
    }
}
