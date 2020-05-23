using System.Collections.Generic;
using VehicleHistory.Logic.Models.Database;
using VehicleHistory.Logic.Models.Dtos;
using VehicleHistory.Logic.Models.Utility;

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
        User GetUserByEmail(string email);
        void SendPasswordRecoveryEmail(User user, AppSettings settings);
        bool IsPasswordCorrect(string input, string email);
        void CheckUserData(User user);
        IList<User> GetEmployees(string locationId, string currentUserId);
        IList<User> DisableEmployee(UserDto userParam, string currentUserId);
        void AddEmployee(User user, AppSettings settings);
    }
}
