using System;
using System.Threading.Tasks;
using Chama.Signup.Repositories;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Chama.Signup.Workers
{
    public class AggregationFunction
    {
        private readonly IDataAggregator _dataAggregator;
        public AggregationFunction(IDataAggregator dataAggregator)
        {
            _dataAggregator = dataAggregator;
        }

        [FunctionName("AgregationFunction")]
        public async Task Run([TimerTrigger("*/10 * * * * *")]TimerInfo myTimer, ILogger log)
        {
            await _dataAggregator.CreateCourseSummary();
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        }
    }
}
