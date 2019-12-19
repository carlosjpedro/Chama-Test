namespace Chama.Signup.Services
{
    public interface IEmailSender
    {
        void SendEmail(string email, string message);
    }
}