using AutoMapper;
using Chama.Signup.Api.Dtos;
using Chama.Signup.Repositories.Entities;
using Chama.Signup.Services.Models;

namespace Chama.Signup.Api.Mappings
{
    public class ChamaDtoProfiles : Profile
    {
        public ChamaDtoProfiles()
        {
            CreateMap<StudentDto, Student>();
            CreateMap<Student, StudentEntity>();
        }
    }
}
