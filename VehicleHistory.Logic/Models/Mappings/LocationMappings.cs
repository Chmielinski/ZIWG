using System;
using AutoMapper;
using VehicleHistory.Logic.Extensions;
using VehicleHistory.Logic.Models.Database;
using VehicleHistory.Logic.Models.Dtos;
using VehicleHistory.Logic.Models.Enums;

namespace VehicleHistory.Logic.Models.Mappings
{
    public class LocationMappings : Profile
    {
        public LocationMappings()
        {
            CreateMap<LocationDto, Location>()
                .ForMember(x => x.Id, y => y.MapFrom(z => Guid.Parse(z.Id)))
                .ForMember(x => x.LocationType, y => y.MapFrom(z => (LocationTypes)z.LocationTypeId));
            CreateMap<Location, LocationDto>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id.ToString()))
                .ForMember(x => x.InsertDateStr, y => y.MapFrom(z => z.InsertDate.ToString("g")))
                .ForMember(x => x.UpdateDateStr, y => y.MapFrom(z => z.UpdateDate.ToString("g")))
                .ForMember(x => x.FullAddress, y => y.MapFrom(z => StringExtenstions.ToFullAddress(z.Line1, z.ZipCode, z.Line2, z.ApartmentNumber)))
                .ForMember(x => x.LocationTypeId, y => y.MapFrom(z => z.LocationType))
                .ForMember(x => x.LocationTypeStr, y => y.MapFrom(z => z.LocationType.ToString()));
        }
    }
}
