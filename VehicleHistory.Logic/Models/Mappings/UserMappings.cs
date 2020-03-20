using System;
using AutoMapper;
using VehicleHistory.Logic.Models.Database;
using VehicleHistory.Logic.Models.Dtos;

namespace VehicleHistory.Logic.Models.Mappings
{
    public class UserMappings : Profile
    {
        public UserMappings()
        {
            CreateMap<UserDto, User>()
                .ForMember(x => x.Id, y => y.MapFrom(z => Guid.Parse(z.Id)))
                .ForMember(x => x.LocationId, y => y.MapFrom(z => Guid.Parse(z.LocationId)))
                .ForMember(x => x.Location, y => y.Ignore());
            CreateMap<User, UserDto>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id.ToString()))
                .ForMember(x => x.InsertDateStr, y => y.MapFrom(z => z.InsertDate.ToString("g")))
                .ForMember(x => x.UpdateDateStr, y => y.MapFrom(z => z.UpdateDate.ToString("g")))
                .ForMember(x => x.LocationId, y => y.MapFrom(z => z.LocationId.ToString()));
        }
    }
}
