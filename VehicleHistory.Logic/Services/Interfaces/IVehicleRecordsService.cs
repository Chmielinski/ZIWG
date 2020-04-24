using System.Collections.Generic;
using VehicleHistory.Logic.Models.Database;

namespace VehicleHistory.Logic.Services.Interfaces
{
    public interface IVehicleRecordsService
    { 
        IList<VehicleRecord> GetAllRecordsByVin(string vin);
        IList<VehicleRecord> GetAllRecords();
        VehicleRecord GetRecordById(string recordId);
        IList<VehicleRecord> GetRecordsByUser(string id);
    }
}