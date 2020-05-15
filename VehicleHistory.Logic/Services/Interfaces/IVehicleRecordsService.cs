using System.Collections.Generic;
using VehicleHistory.Logic.Models.Database;

namespace VehicleHistory.Logic.Services.Interfaces
{
    public interface IVehicleRecordsService
    { 
        IList<VehicleRecord> GetAllRecordsByVin(string vin);
        IList<VehicleRecord> GetAllRecords();
        VehicleRecord GetRecordById(string recordId);
        void Create(VehicleRecord record);
        void RemoveRecord(string recordId);
        void UpdateRecord(VehicleRecord recordParam);
        IList<VehicleRecord> GetRecordsByUser(string id);
    }
}