using System;
using System.ComponentModel.DataAnnotations;
using VehicleHistory.Logic.Models.Enums;

namespace VehicleHistory.Logic.Models.Database
{
    public class VehicleRecord : ModelBase
    {
        [Required]
        public DateTime Timestamp { get; set; } = DateTime.Now;
        [Required]
        public RecordTypes RecordType { get; set; }
        [Required]
        public int? Mileage { get; set; }
        [Required, MaxLength(17), StringLength(17)]
        public string Vin { get; set; }
        public string Description { get; set; }
        [MaxLength(150), StringLength(150)]
        public string Title { get; set; }
        [Required]
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
