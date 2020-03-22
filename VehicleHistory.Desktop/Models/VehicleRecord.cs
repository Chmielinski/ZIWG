using System;
using System.ComponentModel;

namespace VehicleHistoryDesktop.Models
{
    public class VehicleRecord : ModelBase
    {
        [DisplayName("Data utworzenia")]
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public int RecordTypeId { get; set; }
        [DisplayName("Typ rekordu")]
        public string RecordTypeStr { get; set; }
        [DisplayName("Przebieg pojazdu")]
        public int Mileage { get; set; }
        [DisplayName("Numer VIN")]
        public string Vin { get; set; }
        [DisplayName("Opis")]
        public string Description { get; set; }
        [DisplayName("Tytuł")]
        public string Title { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
