using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Chama.Signup.Api.QueueClient
{
    public interface IQueueClient
    {
        Task SendMessage(object message);
    }
}
