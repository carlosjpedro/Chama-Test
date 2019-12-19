using System.Threading.Tasks;

namespace Chama.Signup.Repositories
{
    public interface IDataAggregator
    {
        Task CreateCourseSummary();
    }
}
