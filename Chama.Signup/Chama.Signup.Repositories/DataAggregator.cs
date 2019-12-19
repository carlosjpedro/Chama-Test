using System;
using System.Linq;
using System.Threading.Tasks;
using Chama.Signup.Repositories.Entities;

namespace Chama.Signup.Repositories
{
    public class DataAggregator : IDataAggregator
    {
        private readonly ChamaContext _dbContext;

        public DataAggregator(ChamaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateCourseSummary()
        {
            try
            {
                var summaries = _dbContext
                    .Courses

                    .Select(x => new
                        CourseSummaryEntity
                        {
                            Id = x.Id,
                            AverageAge = x.Students.Average(student => student.Age),
                            MinimumAge = x.Students.Min(student => student.Age),
                            MaximumAge = x.Students.Max(student => student.Age),
                            Capacity = x.Capacity,
                            NumberOfStudents = x.MaxStudents - x.Capacity
                        });

                _dbContext.Summaries.RemoveRange(_dbContext.Summaries);

                await _dbContext.Summaries.AddRangeAsync(summaries);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }
}