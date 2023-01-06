using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SharedProject.Models.EventMsg;

namespace UserFunction.Triggers
{
    public class CustomerServiceBusTrigger
    {
        private readonly ILogger<CustomerServiceBusTrigger> _logger;

        public CustomerServiceBusTrigger(ILogger<CustomerServiceBusTrigger> log)
        {
            _logger = log;
        }

        [FunctionName("SendEmailTrigger")]
        public void SendEmail([ServiceBusTrigger("Customer", "SendEmail", Connection = "ConnectionStrings:ServiceBus")] string payload)
        {
            _logger.LogInformation($"C# ServiceBus topic trigger function processed message: {payload}");

            var data = JsonConvert.DeserializeObject<SendCreateCustomerMsg>(payload);

        }
    }
}
