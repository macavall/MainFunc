// Default URL for triggering event grid function in the local environment.
// http://localhost:7071/runtime/webhooks/EventGrid?functionName={functionname}

using System;
using Azure.Messaging;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FunctionApp17
{
    public class eventgrid1
    {
        private readonly ILogger<eventgrid1> _logger;

        public eventgrid1(ILogger<eventgrid1> logger)
        {
            _logger = logger;
        }

        [Function(nameof(eventgrid1))]
        public void Run([EventGridTrigger] CloudEvent cloudEvent)
        {
            _logger.LogInformation("Event type: {type}, Event subject: {subject}", cloudEvent.Type, cloudEvent.Subject);
        }
    }
}
