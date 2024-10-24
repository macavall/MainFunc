using System;
using Azure.Messaging.EventHubs;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FunctionApp17
{
    public class eventhub1
    {
        private readonly ILogger<eventhub1> _logger;

        public eventhub1(ILogger<eventhub1> logger)
        {
            _logger = logger;
        }

        [Function(nameof(eventhub1))]
        public void Run([EventHubTrigger("samples-workitems", Connection = "")] EventData[] events)
        {
            foreach (EventData @event in events)
            {
                _logger.LogInformation("Event Body: {body}", @event.Body);
                _logger.LogInformation("Event Content-Type: {contentType}", @event.ContentType);
            }
        }
    }
}
