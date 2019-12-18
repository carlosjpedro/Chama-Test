using System;
using System.Collections.Generic;
using System.Linq;
using Chama.Signup.Repositories;
using Chama.Signup.Repositories.Entities;

namespace Chama.Signup.Services.UnitTests
{
    public class StudentRepositoryMock : IStudentRepository
    {
        public static List<StudentEntity> StudentCollection = new List<StudentEntity>();

        public StudentEntity GetStudentByEmail(string email)
        {
            return StudentCollection.FirstOrDefault(x => x.Email == email);
        }
    }
}