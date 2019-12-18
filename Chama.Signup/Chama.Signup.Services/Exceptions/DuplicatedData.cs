namespace Chama.Signup.Services.Exceptions
{
    public abstract class DuplicatedData : ChamaException
    {
        protected DuplicatedData(string message) : base(message) { }
    }
}