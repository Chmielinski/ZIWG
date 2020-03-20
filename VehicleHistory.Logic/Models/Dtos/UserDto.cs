namespace VehicleHistory.Logic.Models.Dtos
{
    public class UserDto : DtoModelBase
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string OldPassword { get; set; }
        public string Token { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LocationId { get; set; }
        public bool PasswordRecoveryActive { get; set; }
        public int Group { get; set; }
    }
}
