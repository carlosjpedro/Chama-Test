using System;

namespace Chama.Signup.Services.Exceptions
{
    public abstract class ChamaException : Exception
    {
        protected ChamaException(string message) : base(message) { }
    }
}
