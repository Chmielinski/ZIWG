using System.ComponentModel.DataAnnotations;
using VehicleHistory.Logic.Models.Enums;

namespace VehicleHistory.Logic.Models.Database
{
    public class Location : ModelBase
    {
        [Required, MaxLength(250), StringLength(250)]
        public string Name { get; set; }

        [Required, MaxLength(100), StringLength(100)]
        public string Street { get; set; }
        [Required, MaxLength(15), StringLength(15)]
        public string Number { get; set; }
        [MaxLength(15), StringLength(15)]
        public string ApartmentNumber { get; set; }
        [Required, MaxLength(100), StringLength(100)]
        public string City { get; set; }
        [Required, MaxLength(10), StringLength(10)]
        public string ZipCode { get; set; }
        [Required]
        public LocationTypes LocationType { get; set; }          
    }
}
