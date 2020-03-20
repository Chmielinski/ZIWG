using System.ComponentModel.DataAnnotations;
using VehicleHistory.Logic.Models.Enums;

namespace VehicleHistory.Logic.Models.Database
{
    public class LocationApplication : ModelBase
    {
        [Required, MaxLength(150), StringLength(150), EmailAddress]
        public string Email { get; set; }
        [Required, MaxLength(250), StringLength(250)]
        public string Name { get; set; }
        [Required, MaxLength(100), StringLength(100)]
        public string Line1 { get; set; }
        [MaxLength(15), StringLength(15)]
        public string ApartmentNumber { get; set; }
        [Required, MaxLength(100), StringLength(100)]
        public string Line2 { get; set; }
        [Required, MaxLength(10), StringLength(10)]
        public string ZipCode { get; set; }
        [Required]
        public LocationTypes LocationType { get; set; }

        public int Status { get; set; }                 // -1 -> rejected
                                                        // 0 -> not answered
                                                        // 1 -> accepted
    }
}
