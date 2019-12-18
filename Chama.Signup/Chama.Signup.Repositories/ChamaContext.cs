using Chama.Signup.Repositories.Entities;
using Microsoft.EntityFrameworkCore;

namespace Chama.Signup.Repositories
{
    public class ChamaContext : DbContext
    {
        public ChamaContext(DbContextOptions<ChamaContext> options) : base(options)
        {
        }

        public DbSet<CourseEntity> Courses { get; set; }
        public DbSet<StudentEntity> Students { get; set; }
    }
}
