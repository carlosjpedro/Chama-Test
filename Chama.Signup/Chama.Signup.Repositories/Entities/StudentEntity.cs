namespace Chama.Signup.Repositories.Entities
{
    public class StudentEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public CourseEntity Course { get; set; }
    }
}