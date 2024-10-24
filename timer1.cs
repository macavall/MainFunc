using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FunctionApp17
{
    public class timer1
    {
        private readonly ILogger _logger;

        public timer1(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<timer1>();
        }

        [Function("timer1")]
        public void Run([TimerTrigger("*/5 * * * * *")] TimerInfo myTimer)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            
            if (myTimer.ScheduleStatus is not null)
            {
                _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
            }
        }
    }
}
