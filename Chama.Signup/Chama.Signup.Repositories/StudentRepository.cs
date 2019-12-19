using System.Linq;
using Chama.Signup.Repositories.Entities;

namespace Chama.Signup.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ChamaContext _dbContext;

        public StudentRepository(ChamaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public StudentEntity GetStudentByEmail(string email)
        {
            return _dbContext.Students.FirstOrDefault(x => x.Email == email);
        }
    }
}