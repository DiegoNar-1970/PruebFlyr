using AutoMapper;
using Flyr.Application.DTOs;
using Flyr.Domain.Entities;

namespace Flyr.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Transport, TransportDto>().ReverseMap();
            CreateMap<Flight, FlightDto>().ReverseMap();
            CreateMap<Journey, JourneyDto>().ReverseMap();
        }
    }
}
