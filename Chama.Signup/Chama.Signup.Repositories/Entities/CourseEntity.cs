using System.Collections.Generic;


namespace Chama.Signup.Repositories.Entities
{
    public class CourseEntity
    {
        public int Id { get; set; }
        public int MaxStudents { get; set; }
        public IEnumerable<StudentEntity> Students { get; set; }
        public string Name { get; set; }
        public string Teacher { get; set; }
        public int Capacity { get; set; }
    }
}
