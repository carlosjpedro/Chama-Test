using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;

namespace Chama.Signup.Api.QueueClient
{
    public interface IQueueClient
    {
        Task SendMessage(object message);
    }

    public class QueueClient : IQueueClient
    {
        private readonly CloudQueue _queue;

        public QueueClient(string connectionString, string queueName)
        {
            _queue = CloudStorageAccount
                .Parse(connectionString)
                .CreateCloudQueueClient()
                .GetQueueReference(queueName);
        }

        public async Task SendMessage(object message)
        {
            await _queue.CreateIfNotExistsAsync();
            var content = JsonConvert.SerializeObject(message);
            await _queue.AddMessageAsync(new CloudQueueMessage(content));
        }
    }
}
