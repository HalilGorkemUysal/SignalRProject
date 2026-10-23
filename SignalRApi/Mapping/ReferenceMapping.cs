using AutoMapper;
using SignalR.DtoLayer.ReferenceDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class ReferenceMapping : Profile
    {
        public ReferenceMapping()
        {
            CreateMap<Reference, ResultReferenceDto>().ReverseMap();
            CreateMap<Reference, CreateReferenceDto>().ReverseMap();
            CreateMap<Reference, GetReferenceDto>().ReverseMap();
            CreateMap<Reference, UpdateReferenceDto>().ReverseMap();
        }
    }
}
