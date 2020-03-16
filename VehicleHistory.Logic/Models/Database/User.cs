using System.ComponentModel.DataAnnotations;
using VehicleHistory.Logic.Models.Enums;

namespace VehicleHistory.Logic.Models.Database
{
    public class User : ModelBase
    {
        [Required, MaxLength(150), StringLength(150)]
        public string Email { get; set; }
        [Required, MaxLength(150), StringLength(150)]
        public string FirstName { get; set; }
        [Required, MaxLength(150), StringLength(150)]
        public string LastName { get; set; }
        [Required, MaxLength(64)]
        public byte[] PasswordHash { get; set; }
        [Required, MaxLength(128)]
        public byte[] PasswordSalt { get; set; }
        [Required]
        public bool PasswordRecoveryActive { get; set; } = false;
        [Required]
        public Location Location { get; set; }
        [Required]
        public UserGroups Group { get; set; }
    }
}
