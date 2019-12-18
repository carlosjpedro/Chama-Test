﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace Chama.Signup.Services
{
    public interface IEmailSender
    {
        void SendEmail(string email, string message);
    }

    public class EmailSender : IEmailSender
    {
        private readonly ILogger _logger;

        public EmailSender(ILogger<EmailSender> logger)
        {
            _logger = logger;
        }
        public void SendEmail(string email, string message)
        {
            _logger.LogInformation($"Address : {email} \t Body : {message}");
        }
    }
}
