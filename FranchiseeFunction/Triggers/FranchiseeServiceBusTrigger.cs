using System;
using System.Text.Json.Nodes;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SharedProject.Models.EventMsg;

namespace FranchiseeFunction.Triggers
{
    public class FranchiseeServiceBusTrigger
    {
        private readonly ILogger<FranchiseeServiceBusTrigger> _logger;

        public FranchiseeServiceBusTrigger(ILogger<FranchiseeServiceBusTrigger> log)
        {
            _logger = log;
        }

        [FunctionName("AssignmentCustomerTrigger")]
        public void AssignmentCustomer([ServiceBusTrigger("Customer", "AssignmentCustomer", Connection = "ServiceBus")] string payload)
        {

            _logger.LogInformation($"C# ServiceBus topic trigger function processed message: {payload}");

            var data = JsonConvert.DeserializeObject<SendCreateCustomerMsg>(payload);

        }
    }
}
