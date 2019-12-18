using Chama.Signup.Repositories;
using Chama.Signup.Services;
using Chama.Signup.Workers;
using Microsoft.EntityFrameworkCore;

[assembly: FunctionsStartup(typeof(Startup))]
namespace Chama.Signup.Workers
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddDbContext<ChamaContext>(options =>
                SqlServerDbContextOptionsExtensions.UseSqlServer(options, ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString));
            builder.Services.AddTransient<IStudentRepository, StudentRepository>();
            builder.Services.AddTransient<ICourseRepository, CourseRepository>();
            builder.Services.AddTransient<IStudentManager, StudentManager>();
        }
    }
}