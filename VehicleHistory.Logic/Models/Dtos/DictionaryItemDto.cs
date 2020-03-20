namespace VehicleHistory.Logic.Models.Dtos
{
    public class DictionaryItemDto : DtoModelBase
    {
        public int DictionaryTypeId { get; set; }
        public int EnumValue { get; set; }
        public int? IntValue { get; set; }
        public string StringValue { get; set; }
        public decimal? DecimalValue { get; set; }
        public bool? BoolValue { get; set; }
    }
}
