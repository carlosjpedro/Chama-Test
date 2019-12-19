using System.Collections.Generic;
using AutoMapper;
using Chama.Signup.Repositories;
using Chama.Signup.Repositories.Entities;
using Chama.Signup.Services.Exceptions;
using Chama.Signup.Services.Models;

namespace Chama.Signup.Services
{
    public class StudentManager : IStudentManager
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;

        public StudentManager(ICourseRepository courseRepository, IStudentRepository studentRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public void AddStudentToCourse(int courseId, Student student)
        {
            var course = _courseRepository.GetCourse(courseId);

            if (course == default(CourseEntity))
            {
                throw new CourseNotFound();
            }

            if (course.Capacity == 0)
            {
                throw new CourseFull();
            }

            var existingStudent = _studentRepository.GetStudentByEmail(student.Email);
            if (existingStudent != default(StudentEntity))
            {
                throw new DuplicatedEmail();
            }

            var studentEntity = _mapper.Map<StudentEntity>(student);

            _courseRepository.AddStudent(courseId, studentEntity);
        }
    }
}
