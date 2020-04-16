using AutoMapper;
using VehicleHistory.Logic.Models.Database;
using VehicleHistory.Logic.Models.Dtos;
using VehicleHistory.Logic.Models.Enums;

namespace VehicleHistory.Logic.Models.Mappings
{
    public class DictionaryItemsMappings : Profile
    {
        public DictionaryItemsMappings()
        {
            CreateMap<DictionaryItem, DictionaryItemDto>()
                .ForMember(x => x.DictionaryTypeId, y => y.MapFrom(z => (int)z.DictionaryType));

            CreateMap<DictionaryItemDto, DictionaryItem>()
                .ForMember(x => x.DictionaryType, y => y.MapFrom(z => (DictionaryType)z.DictionaryTypeId));
        }
    }
}
