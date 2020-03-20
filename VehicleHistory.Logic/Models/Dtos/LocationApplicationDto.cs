namespace VehicleHistory.Logic.Models.Dtos
{
    public class LocationApplicationDto : DtoModelBase
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Line1 { get; set; }
        public string ApartmentNumber { get; set; }
        public string Line2 { get; set; }
        public string ZipCode { get; set; }
        public int? LocationTypeId { get; set; }
        public string LocationTypeStr { get; set; }
        public string FullAddress { get; set; }
        public int Status { get; set; }
    }
}
