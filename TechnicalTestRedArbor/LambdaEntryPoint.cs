using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace TechnicalTestRedArbor
{
    public class LambdaEntryPoint :

        Amazon.Lambda.AspNetCoreServer.APIGatewayProxyFunction
    {
        protected override void Init(IWebHostBuilder builder)
        {
            builder
                .UseStartup<Startup>();
        }

        protected override void Init(IHostBuilder builder)
        {
        }
    }
}