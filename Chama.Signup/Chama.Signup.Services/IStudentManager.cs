using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Chama.Signup.Repositories;
using Chama.Signup.Services.Models;

namespace Chama.Signup.Services
{
    public interface IStudentManager
    {
        void AddStudentToCourse(int courseId, Student student);
    }

    public interface ICourseDetailProvider
    {
        IEnumerable<CourseSummary> GetCourses();
    }
    public class CourseDetailProvider : ICourseDetailProvider
    {
        private readonly ChamaContext _dbContext;
        private readonly IMapper _mapper;

        public CourseDetailProvider(ChamaContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public IEnumerable<CourseSummary> GetCourses()
        {
            return from summary in _dbContext.Summaries
                   join course in _dbContext.Courses on
                       summary.Id equals course.Id
                   select new CourseSummary
                   {
                       Capacity = summary.Capacity,
                       AverageAge = summary.AverageAge,
                       MaximumAge = summary.MaximumAge,
                       MinimumAge = summary.MinimumAge,
                       NumberOfStudents = summary.NumberOfStudents,
                       Teacher = course.Teacher
                   };

        }
    }

}