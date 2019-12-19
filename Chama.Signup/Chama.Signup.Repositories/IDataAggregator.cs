using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chama.Signup.Repositories
{
    public interface IDataAggregator
    {
        Task CreateCourseSummary();
    }
}
