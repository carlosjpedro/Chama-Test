using System;
using Chama.Signup.Messages;
using Chama.Signup.Services;
using Chama.Signup.Services.Exceptions;
using Chama.Signup.Services.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Chama.Signup.Workers
{
    public class SignUpProcessorFunction
    {
        private readonly IStudentManager _studentManager;
        private readonly IEmailSender _emailSender;

        public SignUpProcessorFunction(IStudentManager studentManager, IEmailSender emailSender)
        {
            _studentManager = studentManager;
            _emailSender = emailSender;
        }

        [FunctionName("SignUpProcessorFunction")]
        public void Run([QueueTrigger("student-signup", Connection = "AzureWebJobsStorage")]string message, ILogger logger)
        {
            try
            {
                var content = JsonConvert.DeserializeObject<SignupMessageContent>(message);
                var student = new Student
                {
                    Name = content.StudentName,
                    Email = content.StudentEmail,
                    Age = content.StudentAge
                };
                _studentManager.AddStudentToCourse(content.CourseId, student);
                _emailSender.SendEmail(student.Email, "Registered");
            }
            catch (ChamaException e)
            {
                logger.LogError(e.Message);
            }
            catch (Exception e)
            {
                logger.LogCritical(e.Message);
            }
            logger.LogInformation($"C# Queue trigger function processed: {message}");
        }
    }
}
