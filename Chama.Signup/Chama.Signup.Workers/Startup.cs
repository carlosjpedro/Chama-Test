using System;
using AutoMapper;
using Chama.Signup.Repositories;
using Chama.Signup.Services;
using Chama.Signup.Services.Mappings;
using Chama.Signup.Workers;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

[assembly: FunctionsStartup(typeof(Startup))]
namespace Chama.Signup.Workers
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddDbContext<ChamaContext>(options =>
                SqlServerDbContextOptionsExtensions.UseSqlServer(options, Environment.GetEnvironmentVariable("DefaultConnection")));
            builder.Services.AddTransient<IStudentRepository, StudentRepository>();
            builder.Services.AddTransient<ICourseRepository, CourseRepository>();
            builder.Services.AddTransient<IStudentManager, StudentManager>();
            builder.Services.AddTransient<IEmailSender, EmailSender>();
            builder.Services.AddAutoMapper(typeof(ChamaProfiles).Assembly);
            builder.Services.AddLogging(x => x.AddConsole());
        }
    }
}