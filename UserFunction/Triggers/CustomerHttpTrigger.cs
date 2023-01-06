using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using UserFunction.Interfaces;
using UserFunction.Models.DTO.Customer;
using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;
using SharedProject.Models.EventMsg;
using SharedProject.Helpers;

namespace UserFunction.Triggers
{
    public class CustomerHttpTrigger
    {
        private ICustomerService _customerService;

        private readonly ServiceBusClient _serviceBusClient;


        public CustomerHttpTrigger(
            IConfiguration config,
            ICustomerService customerService
            )
        {
            _serviceBusClient = new ServiceBusClient(config.GetConnectionString("ServiceBus"));

            _customerService = customerService;
        }



        [FunctionName("CreateCustomer")]
        public async Task<IActionResult> CreateCustomer(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] RequestCreateCustomer req,
            ILogger log)
        {

            var res = await _customerService.CreateCustomer(req);

            if (res.IsSuccess)
            {
                //send message

                SendCreateCustomerMsg msg = new SendCreateCustomerMsg()
                {
                    Name = req.Name,
                    Email = req.Email,
                    ClassName = req.ClassName,
                };

                await _serviceBusClient.SendMessageAsync(msg);

                return new OkObjectResult("hello");
            }
            else
            {
                return new BadRequestObjectResult(res.Message);
            }
            
        }
    }
}
