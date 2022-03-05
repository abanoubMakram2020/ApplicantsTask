using ApplicantsTask.Application.DTOs.InputDTO;
using ApplicantsTask.Application.DTOs.OutputDTO;
using ApplicantsTask.Domain.Entities;
using AutoMapper;

namespace ApplicantsTask.Application.Automapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Applicant, ApplicantInputDTO>().ReverseMap();
            CreateMap<Applicant, ApplicantOutputDTO>().ReverseMap();

            CreateMap<User, UserInputDTO>().ReverseMap();
            CreateMap<User, UserOutputDTO>().ReverseMap();
            CreateMap<User, RegistrationDTO>().ReverseMap();
            CreateMap<User, LoginDTO>().ReverseMap();
        }
    }
}
