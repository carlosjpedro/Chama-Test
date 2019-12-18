using System.Linq;
using Chama.Signup.Repositories.Entities;

namespace Chama.Signup.Repositories
{
    public static class DbInit
    {
        public static void Init(ChamaContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var courses = new[]
            {
                new CourseEntity
                {
                    MaxStudents = 0,
                    Capacity = 10,
                    Name = "Full Course",
                    Teacher = "Mark"
                },
                new CourseEntity
                {
                    MaxStudents = 10,
                    Capacity = 10,
                    Name = "English Course",
                    Teacher = "John"
                }
            };

            foreach (var course in courses)
            {
                context.Courses.Add(course);
            }

            context.SaveChanges();
        }
    }
}
