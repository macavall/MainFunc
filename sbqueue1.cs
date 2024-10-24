using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FunctionApp17
{
    public class sbqueue1
    {
        private readonly ILogger<sbqueue1> _logger;

        public sbqueue1(ILogger<sbqueue1> logger)
        {
            _logger = logger;
        }

        [Function(nameof(sbqueue1))]
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
