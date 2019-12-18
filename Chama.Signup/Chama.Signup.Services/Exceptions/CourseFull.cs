namespace Chama.Signup.Services.Exceptions
{
    public class CourseFull : ChamaException
    {
        public CourseFull() : base("Course is Full")
        {
        }
    }
}