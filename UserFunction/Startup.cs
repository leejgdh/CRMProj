using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserFunction.Interfaces;
using UserFunction.Models.DAO;
using UserFunction.Options;
using UserFunction.Services;

[assembly: FunctionsStartup(typeof(UserFunction.Startup))]
namespace UserFunction
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {

            var configuration = builder.GetContext().Configuration;


            builder.Services.AddDbContext<UserContext>(e => e.UseCosmos(configuration.GetConnectionString("DHCosmos"), "User"));

            builder.Services.AddTransient<ICustomerService, CustomerService>();

            //Options
            builder.Services.Configure<SendgridOption>(configuration.GetSection("Sendgrid"));
            builder.Services.Configure<TwilioOption>(configuration.GetSection("Twilio"));

            builder.Services.AddHttpClient();
        }
    }
}
