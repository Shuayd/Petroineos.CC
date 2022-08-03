using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Petroineos.CC.PowerPositionFunc;
using Petroineos.CC.Service;
using Petroineos.CC.Service.Configuration;
using Petroineos.CC.Service.Interfaces;
using Services;

[assembly: FunctionsStartup(typeof(Startup))]
namespace Petroineos.CC.PowerPositionFunc
{
    public class Startup : FunctionsStartup
    {
        public static IConfiguration GetConfiguration()
        {
            var configBuilder = new ConfigurationBuilder()
            .AddJsonFile("local.settings.json", true, true)
            .AddEnvironmentVariables();

            var config = configBuilder.Build();

            return configBuilder.Build();

        }

        public override void Configure(IFunctionsHostBuilder builder)
        {
            var config = GetConfiguration();
            builder.Services.Configure<AppSettings>(config);
            RegisterServices(builder.Services);
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<IPowerService, PowerService>();
            services.AddTransient<IPowerPositionService, PowerPositionService>();
            services.AddTransient<IReportService, ReportService>();
            services.AddTransient<ILogService, LogService>();

        }
    }
}
