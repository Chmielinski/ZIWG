using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using VehicleHistory.Logic.DB;
using VehicleHistory.Logic.Helpers;
using VehicleHistory.Logic.Models.Database;
using VehicleHistory.Logic.Models.Utility;
using VehicleHistory.Logic.Services.Interfaces;

namespace VehicleHistory.Logic.Services.Implementations
{
    public class VehicleRecordsService : IVehicleRecordsService
    {
        private VehicleHistoryContext _context;

        public VehicleRecordsService(VehicleHistoryContext context)
        {
            _context = context;
        }

        public IList<VehicleRecord> GetAllRecordsByVin(string vin)
        {
            vin.Validate();
            return _context.VehicleRecords.Include(x => x.User.Location).Where(x => x.Vin == vin).OrderBy(x => x.Timestamp).ToList();
        }

        public IList<VehicleRecord> GetAllRecords()
        {
            return _context.VehicleRecords.ToList();
        }

        public VehicleRecord GetRecordById(string recordId)
        {
            return _context.VehicleRecords.FirstOrDefault(x => x.Id.ToString() == recordId);
        }

        public IList<VehicleRecord> GetRecordsByUser(string id)
        {
            return _context.VehicleRecords.Include(x => x.User).Where(x => x.UserId.ToString() == id).ToList();
        }
    }
}
