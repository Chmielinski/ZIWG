using System;
using AutoMapper;
using VehicleHistory.Logic.Models.Database;
using VehicleHistory.Logic.Models.Dtos;
using VehicleHistory.Logic.Models.Enums;

namespace VehicleHistory.Logic.Models.Mappings
{
    public class VehicleRecordMappings : Profile
    {
        public VehicleRecordMappings()
        {
            CreateMap<VehicleRecordDto, VehicleRecord>()
                .ForMember(x => x.Id, y => y.MapFrom(z => Guid.Parse(z.Id)))
                .ForMember(x => x.RecordType, y => y.MapFrom(z => (RecordTypes)z.RecordTypeId));
            CreateMap<VehicleRecord, VehicleRecordDto>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id.ToString()))
                .ForMember(x => x.InsertDateStr, y => y.MapFrom(z => z.InsertDate.ToString("g")))
                .ForMember(x => x.UpdateDateStr, y => y.MapFrom(z => z.UpdateDate.ToString("g")))
                .ForMember(x => x.Timestamp, y => y.MapFrom(z => z.Timestamp.ToString("g")))
                .ForMember(x => x.TimestampStr, y => y.MapFrom(z => z.Timestamp.ToString("g")))
                .ForMember(x => x.RecordTypeId, y => y.MapFrom(z => z.RecordType))
                .ForMember(x => x.RecordTypeStr, y => y.MapFrom(z => z.RecordType.ToString()))
                .ForMember(x => x.Location, y => y.MapFrom(z => z.User.Location));
        }
    }
}
