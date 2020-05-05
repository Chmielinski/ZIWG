using System.Collections.Generic;
using VehicleHistory.Logic.Models.Database;
using VehicleHistory.Logic.Models.Dtos;
using VehicleHistory.Logic.Models.Utility;

namespace VehicleHistory.Logic.Services.Interfaces
{
    public interface ILocationsService
    {
        void Create(LocationApplication application);
        void HandleApplication(bool accepted, string id, AppSettings settings);
        IList<LocationApplication> GetActiveApplications();
        IList<User> GetLocationOperators(LocationDto location);
    }
}
