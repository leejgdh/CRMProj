using FranchiseeFunction.Interfaces;
using FranchiseeFunction.Models.DTO.Class;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace FranchiseeFunction.Triggers
{
    public class ClassHttpTrigger
    {
        private IClassService _classService;

        public ClassHttpTrigger(
            IClassService classService
            )
        {
            _classService = classService;
        }


        [FunctionName("CreateClass")]
        public async Task<IActionResult> CreateClass(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] RequestCreateClass req,
            ILogger log)
        {

            var res = await _classService.CreateAsync(req);

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
