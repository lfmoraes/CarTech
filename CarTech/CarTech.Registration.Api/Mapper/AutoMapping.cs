using AutoMapper;
using CarTech.Domain.Models;
using CarTech.ViewModel;

namespace CarTech.Registration.Api.Mapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
            CreateMap<Categoria, CategoriaViewModel>().ReverseMap();
        }
    }
}
