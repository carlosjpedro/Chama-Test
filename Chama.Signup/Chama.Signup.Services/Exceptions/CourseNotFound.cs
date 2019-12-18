namespace Chama.Signup.Services.Exceptions
{
    public class CourseNotFound : ChamaException
    {
        public CourseNotFound() : base("Course not found")
        {
        }
    }
}