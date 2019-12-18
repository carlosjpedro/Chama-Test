using System;
using Chama.Signup.Messages;
using Chama.Signup.Services;
using Chama.Signup.Services.Exceptions;
using Chama.Signup.Services.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Chama.Signup.Workers
{
    public class Function1
    {
        private readonly IStudentManager _studentManager;
        private readonly ILogger _logger;

        public Function1(IStudentManager studentManager, ILogger logger)
        {
            _studentManager = studentManager;
            _logger = logger;
        }

        [FunctionName("Function1")]
        public void Run([QueueTrigger("student-signup", Connection = "AzureWebJobsStorage")]string message)
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
            }
            catch (ChamaException e)
            {
                _logger.LogError(e.Message);
            }
            catch (Exception e)
            {
                _logger.LogCritical(e.Message);
            }
            _logger.LogInformation($"C# Queue trigger function processed: {message}");
        }
    }
}
