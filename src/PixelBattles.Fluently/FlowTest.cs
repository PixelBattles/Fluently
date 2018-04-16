using Microsoft.Extensions.Configuration;
using PixelBattles.Fluently.Context;
using System;

namespace PixelBattles.Fluently
{
    public abstract class FlowTest : IDisposable
    {
        protected IConfiguration Configuration { get; private set; }
        protected IFlowContext Context { get; private set; }

        public FlowTest()
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var configBuilder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", true, true)
                .AddJsonFile($"appsettings.{environmentName}.json", true, true);

            this.Configuration = configBuilder.Build();

            this.Context = new FlowContext();
        }

        public void Dispose()
        {
        }
    }
}
