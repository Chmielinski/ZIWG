using System.ComponentModel.DataAnnotations;
using VehicleHistory.Logic.Models.Enums;

namespace VehicleHistory.Logic.Models.Database
{
    public class DictionaryItem : ModelBase
    {
        [Required]
        public DictionaryType DictionaryType { get; set; }
        [Required]
        public int EnumValue { get; set; }
        public int? IntValue { get; set; }
        [MaxLength(250), StringLength(250)]
        public string StringValue { get; set; }
        public decimal? DecimalValue { get; set; }
        public bool? BoolValue { get; set; }
    }
}
