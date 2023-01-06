using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserFunction.Interfaces;
using UserFunction.Models.DAO;
using UserFunction.Services;

[assembly: FunctionsStartup(typeof(UserFunction.Startup))]
namespace UserFunction
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {

            var configuration = builder.GetContext().Configuration;

            builder.Services.AddHttpClient();


            builder.Services.AddDbContext<UserContext>(e => e.UseCosmos(configuration.GetConnectionString("DHCosmos"), "User"));

            builder.Services.AddTransient<ICustomerService, CustomerService>();
        }
    }
}
