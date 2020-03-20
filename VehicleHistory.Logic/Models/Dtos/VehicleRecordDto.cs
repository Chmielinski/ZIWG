using System;

namespace VehicleHistory.Logic.Models.Dtos
{
    public class VehicleRecordDto : DtoModelBase
    {
        public DateTime Timestamp { get; set; }
        public int RecordTypeId { get; set; }
        public string RecordTypeStr { get; set; }
        public int Mileage { get; set; }
        public string Vin { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string UserId { get; set; }
        public string TimestampStr { get; set; }
        public LocationDto Location { get; set; }
    }
}
