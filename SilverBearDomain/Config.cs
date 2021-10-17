using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using Marten;
using SilverBearDomain.Machines.DomainConfig;
using SilverBearDomain.Storage;

namespace SilverBearDomain
{
    public static class Config
    {
        public static string Url;// = "https://localhost:44337/api/";

        public static void SilverBearDomainManagement(this IServiceCollection services,
            IConfiguration config)
        {
            services.AddMarten(config, options =>
            {
                ConfigMachinesMarten
                .AddMachinesConfigureMarten(options);
            });
            Url = config["url:index"];
            services.AddConfigMachines();
        }
        public static HttpContent ToJsonStringContent(object obj)
        {
            return new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
        }
    }
}
