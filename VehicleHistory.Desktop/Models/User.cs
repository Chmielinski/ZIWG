﻿namespace VehicleHistoryDesktop.Models
{
    public class User : ModelBase
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LocationId { get; set; }
        public bool PasswordRecoveryActive { get; set; }
    }
}
