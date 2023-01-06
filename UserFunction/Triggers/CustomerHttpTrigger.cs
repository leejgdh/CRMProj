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

namespace UserFunction.Triggers
{
    public class CustomerHttpTrigger
    {
        private ICustomerService _customerService;


        public CustomerHttpTrigger(
            ICustomerService customerService
            )
        {
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
                return new OkObjectResult("hello");
            }
            else
            {
                return new BadRequestObjectResult(res.Message);
            }
            
        }
    }
}
