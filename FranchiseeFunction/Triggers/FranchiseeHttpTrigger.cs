using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FranchiseeFunction.Interfaces;
using FranchiseeFunction.Models.DTO.Franchisee;

namespace FranchiseeFunction.Triggers
{
    public class FranchiseeHttpTrigger
    {
        private IFranchiseeService _franchiseeService;


        public FranchiseeHttpTrigger(
            IFranchiseeService franchiseeService
            )
        {
            _franchiseeService = franchiseeService;
        }



        [FunctionName("CreateFranchisee")]
        public async Task<IActionResult> CreateFranchisee(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] RequestCreateFranchisee req,
            ILogger log)
        {

            var res = await _franchiseeService.CreateFranchisee(req);

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
