using System.Linq;
using AutoMapper;
using Chama.Signup.Repositories;
using Chama.Signup.Repositories.Entities;
using Chama.Signup.Services.Exceptions;
using Chama.Signup.Services.Models;
using Moq;
using Xunit;

namespace Chama.Signup.Services.UnitTests
{
    public class AddingStudentTests
    {
        private readonly IStudentManager _studentManager;
        private readonly Mock<IMapper> _mapperMock;

        public AddingStudentTests()
        {
            _mapperMock = new Mock<IMapper>();
            _studentManager = new StudentManager(
                new CourseRepositoryMock(),
                new StudentRepositoryMock(),
                _mapperMock.Object);
        }

        [Fact]
        public void AddStudentWillFailWhenCourseDoesNotExist()
        {
            var student = new Student
            {
                Name = "Carlos",
                Email = "cjp.developer@gmail.com"
            };
            Assert.Throws<CourseNotFound>(() =>
                _studentManager.AddStudentToCourse(CourseRepositoryMock.CourseWithoutStudents, student));
        }

        [Fact]
        public void AddStudentWillFailWhenCourseIsFull()
        {
            var student = new Student
            {
                Name = "Peter",
                Email = "ptt.developer@gmail.com"
            };

            Assert.Throws<CourseFull>(() =>
                _studentManager.AddStudentToCourse(CourseRepositoryMock.CourseFullCourse, student));
        }

        [Fact]
        public void AddStudentWillAddStudentForCourseWithFreeSlots()
        {
            var student = new Student
            {
                Name = "John",
                Email = "jon.developer@gmail.com"
            };

            var mappedStudent = new StudentEntity
            {
                Name = student.Name,
                Email = student.Email
            };

            _mapperMock
                .Setup(x => x.Map<StudentEntity>(student))
                .Returns(mappedStudent);

            _studentManager.AddStudentToCourse(CourseRepositoryMock.CourseWithFreeSlots, student);

            Assert.Contains(mappedStudent, StudentRepositoryMock.StudentCollection);
        }


        [Fact]
        public void AddStudentWithExistingEmailFail()
        {
            var student1 = new Student
            {
                Name = "Peter",
                Email = "ptt.developer@gmail.com"
            };
            var mappedStudent1 = new StudentEntity
            {
                Name = student1.Name,
                Email = student1.Email
            };

            var student2 = new Student
            {
                Name = "Mike",
                Email = "ptt.developer@gmail.com"
            };
            var mappedStudent2 = new StudentEntity
            {
                Name = student2.Name,
                Email = student2.Email
            };

            _mapperMock
                .Setup(x => x.Map<StudentEntity>(student1))
                .Returns(mappedStudent1);

            _mapperMock
                .Setup(x => x.Map<StudentEntity>(student2))
                .Returns(mappedStudent2);
            _studentManager.AddStudentToCourse(CourseRepositoryMock.CourseWithFreeSlots, student1);

            Assert.Throws<DuplicatedEmail>(() =>
                _studentManager.AddStudentToCourse(CourseRepositoryMock.CourseWithFreeSlots, student2));
        }
    }
}
