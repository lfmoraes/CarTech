using AutoMapper;
using CarTech.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace CarTech.App.Mapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<IdentityUser, UserViewModel>().ReverseMap();
        }
    }
}
