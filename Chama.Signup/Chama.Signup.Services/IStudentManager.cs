using Chama.Signup.Services.Models;

namespace Chama.Signup.Services
{
    public interface IStudentManager
    {
        void AddStudentToCourse(int courseId, Student student);
    }
}