using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FunctionApp17
{
    public class sbqueue
    {
        private readonly ILogger<sbqueue> _logger;

        public sbqueue(ILogger<sbqueue> logger)
        {
            _logger = logger;
        }

        [Function(nameof(sbqueue))]
        public async Task Run(
            [ServiceBusTrigger("myqueue", Connection = "")]
            ServiceBusReceivedMessage message,
            ServiceBusMessageActions messageActions)
        {
            _logger.LogInformation("Message ID: {id}", message.MessageId);
            _logger.LogInformation("Message Body: {body}", message.Body);
            _logger.LogInformation("Message Content-Type: {contentType}", message.ContentType);

            // Complete the message
            await messageActions.CompleteMessageAsync(message);
        }
    }
}
