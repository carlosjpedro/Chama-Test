using System.Collections.Generic;
using Chama.Signup.Services.Models;

namespace Chama.Signup.Services
{
    public interface ICourseDetailProvider
    {
        IEnumerable<CourseSummary> GetCourses();
    }
}