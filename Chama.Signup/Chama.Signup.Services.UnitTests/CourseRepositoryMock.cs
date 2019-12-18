using System;
using System.Collections.Generic;
using System.Linq;
using Chama.Signup.Repositories;
using Chama.Signup.Repositories.Entities;

namespace Chama.Signup.Services.UnitTests
{
    public class CourseRepositoryMock : ICourseRepository
    {
        public const int CourseWithoutStudents = 9999;
        public const int CourseFullCourse = 7777;
        public const int CourseWithFreeSlots = 4444;
        public const int FreeSlotCount = 10;
        public static readonly IEnumerable<CourseEntity> Courses = new[]
        {
            new CourseEntity
            {
                Id = CourseFullCourse,
                MaxStudents = 0
            },
            new CourseEntity
            {
                Id = CourseWithFreeSlots,
                MaxStudents = FreeSlotCount
            }
        };
        public CourseEntity GetCourse(int courseId)
        {
            return Courses.FirstOrDefault(x => x.Id == courseId);
        }

        public IEnumerable<CourseEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public void UpdateCourse(CourseEntity course)
        {
        }

        public void AddStudent(int courseId, StudentEntity student)
        {
            StudentRepositoryMock.StudentCollection.Add(student);
        }
    }
}