using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FunctionApp17
{
    public class sbtopic1
    {
        private readonly ILogger<sbtopic1> _logger;

        public sbtopic1(ILogger<sbtopic1> logger)
        {
            _logger = logger;
        }

        [Function(nameof(sbtopic1))]
        public async Task Run(
            [ServiceBusTrigger("mytopic", "mysubscription", Connection = "")]
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
