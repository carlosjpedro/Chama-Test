namespace Chama.Signup.Services.Exceptions
{
    public class DuplicatedEmail : DuplicatedData
    {
        public DuplicatedEmail() : base("Entity with specified email already exists.") { }
    }
}