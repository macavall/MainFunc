using System;
using Azure.Storage.Queues.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FunctionApp17
{
    public class queue1
    {
        private readonly ILogger<queue1> _logger;

        public queue1(ILogger<queue1> logger)
        {
            _logger = logger;
        }

        [Function(nameof(queue1))]
        public void Run([QueueTrigger("myqueue-items", Connection = "")] QueueMessage message)
        {
            _logger.LogInformation($"C# Queue trigger function processed: {message.MessageText}");
        }
    }
}
