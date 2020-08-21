using AutoMapper;
using WebApi.Entities;
using WebApi.Models;

namespace WebApi.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RegisterModel, User>();
            CreateMap<CreatePlan, Plan>();
            CreateMap<CreateExercise, Exercise>();
        }
    }
}