using AutoMapper;
using CarTech.Domain.Models;
using CarTech.Registration.Api.DTO;

namespace CarTech.Registration.Api.Mapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
        }
    }
}
