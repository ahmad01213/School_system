using AutoMapper;
using School_Management_System.Data.ViewModels;
using School_Management_System.Models;

namespace School_Management_System.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UserForRegister, User>();


        }
    }
}