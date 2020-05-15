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

        public void Create(VehicleRecord record)
        {
            record.Vin.Validate();
            if (!record.Mileage.HasValue)
            {
                throw new AppException("Vehicle Mileage must be specified.");
            }

            _context.VehicleRecords.Add(record);
            _context.SaveChanges();
        }

        public void RemoveRecord(string recordId)
        {
            var record = _context.VehicleRecords.FirstOrDefault(x => x.Id.ToString() == recordId);
            if (record == null)
            {
                throw new AppException("Record doesn't exist.");
            }

            _context.VehicleRecords.Remove(record);
            _context.SaveChanges();
        }

        public void UpdateRecord(VehicleRecord recordParam)
        {
            recordParam.Vin.Validate();
            if (!recordParam.Mileage.HasValue)
            {
                throw new AppException("Vehicle Mileage must be specified.");
            }


            var record = _context.VehicleRecords.FirstOrDefault(x => x.Id.ToString() == recordParam.Id.ToString());
            if (record == null)
            {
                throw new AppException("Record not found.");
            }

            record.Description = recordParam.Description;
            record.Mileage = recordParam.Mileage;
            record.Vin = recordParam.Vin;
            record.RecordType = recordParam.RecordType;
            record.Title = recordParam.Title;
            record.UpdateDate = DateTime.Now;
            _context.VehicleRecords.Update(record);
            _context.SaveChanges();
        }

        public IList<VehicleRecord> GetRecordsByUser(string id)
        {
            return _context.VehicleRecords.Include(x => x.User).Where(x => x.UserId.ToString() == id).ToList();
        }
    }
}
