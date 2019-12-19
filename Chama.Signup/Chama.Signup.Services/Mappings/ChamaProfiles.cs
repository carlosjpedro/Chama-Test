using AutoMapper;
using Chama.Signup.Repositories.Entities;
using Chama.Signup.Services.Models;

namespace Chama.Signup.Services.Mappings
{
    public class ChamaProfiles : Profile
    {
        public ChamaProfiles()
        {
            CreateMap<Student, StudentEntity>();
        }
    }
}
