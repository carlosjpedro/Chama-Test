using Chama.Signup.Repositories.Entities;

namespace Chama.Signup.Repositories
{
    public interface IStudentRepository
    {
        StudentEntity GetStudentByEmail(string email);
    }
}
