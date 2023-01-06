using System;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using FranchiseeFunction.Interfaces;
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

        private readonly IClassService _classService;

        public FranchiseeServiceBusTrigger(
            ILogger<FranchiseeServiceBusTrigger> log,
            IClassService classService
            )
        {
            _logger = log;
            _classService = classService;
        }

        [FunctionName("AssignmentCustomerTrigger")]
        public async Task AssignmentCustomer([ServiceBusTrigger("Customer", "AssignmentCustomer", Connection = "ConnectionStrings:ServiceBus")] string payload)
        {

            _logger.LogInformation($"C# ServiceBus topic trigger function processed message: {payload}");

            var data = JsonConvert.DeserializeObject<SendCreateCustomerMsg>(payload);

            //Assign Customer in class

            if (data.ClassId.HasValue)
            {
                var assignRes = await _classService.InAssignmentCustomerAsync(data.ClassId.Value, new Models.DAO.Class._Customer()
                {
                    Name = data.Name,
                    Email = data.Email,
                    Tel = data.Tel,
                    StartDate = DateTime.Today
                });

            }

        }
    }
}
