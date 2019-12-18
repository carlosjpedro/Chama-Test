using System.Collections.Generic;
using Chama.Signup.Repositories.Entities;

namespace Chama.Signup.Repositories
{
    public interface ICourseRepository
    {
        CourseEntity GetCourse(int courseId);
        void AddStudent(int courseId, StudentEntity student);
    }
}