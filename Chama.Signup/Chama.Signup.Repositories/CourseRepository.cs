using System;
using System.Collections.Generic;
using System.Linq;
using Chama.Signup.Repositories.Entities;

namespace Chama.Signup.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ChamaContext _dbContext;

        public CourseRepository(ChamaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public CourseEntity GetCourse(int courseId)
        {
            return _dbContext.Courses.FirstOrDefault(x => x.Id == courseId);
        }

        public void AddStudent(int courseId, StudentEntity student)
        {
            var course = _dbContext.Courses.First(x => x.Id == courseId);
            course.MaxStudents--;
            student.Course = course;
            _dbContext.Students.Add(student);
            _dbContext.SaveChanges();
        }
    }
}