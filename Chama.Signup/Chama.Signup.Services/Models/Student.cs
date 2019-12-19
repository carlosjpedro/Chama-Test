using System.Collections.Generic;

namespace Chama.Signup.Services.Models
{
    public class Student
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
    }

    public class CourseSummary
    {
        public int Id { get; set; }
        public double AverageAge { get; set; }
        public int MinimumAge { get; set; }
        public int MaximumAge { get; set; }
        public int Capacity { get; set; }
        public int NumberOfStudents { get; set; }
        public string Teacher { get; set; }
    }
}
