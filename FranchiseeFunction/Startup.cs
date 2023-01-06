using FranchiseeFunction.Interfaces;
using FranchiseeFunction.Models.DAO;
using FranchiseeFunction.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(FranchiseeFunction.Startup))]
namespace FranchiseeFunction
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {

            var configuration = builder.GetContext().Configuration;

            builder.Services.AddHttpClient();


            builder.Services.AddDbContext<FranchiseeContext>(e => e.UseCosmos(configuration.GetConnectionString("DHCosmos"), "Franchisee"));

            builder.Services.AddTransient<IFranchiseeService, FranchiseeService>();
            builder.Services.AddTransient<IClassService, ClassService>();

        }
    }
}
