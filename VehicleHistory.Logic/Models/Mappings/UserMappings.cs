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
                .ForMember(x => x.Id, y => y.MapFrom(z => Guid.Parse(z.Id)));
            CreateMap<User, UserDto>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id.ToString()));
        }
    }
}
