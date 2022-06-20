using AutoMapper;
using Domain.Models.Student;
using Application.Dtos.AccountDtos;
using Microsoft.AspNetCore.Identity;
using Application.Dtos.ProgramDto;
using Domain.Models.Program;
using Application.Dtos.StudentDtos;

namespace Application.Profiles
{

    public class UsersProfile : Profile {

        public UsersProfile() {

            CreateMap<IdentityUser, GetUsersDto>();    
            CreateMap<RegisterProgramDto, Programs>();
            CreateMap<Programs, GetProgramDto>();
            CreateMap<AddStudentFromFrontendDto, Students>();
            CreateMap<Students, GetStudentDto>();
            CreateMap<UpdateStudentDto, Students>();
        }
    
    }

}