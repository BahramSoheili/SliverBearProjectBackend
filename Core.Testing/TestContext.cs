using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Core.Events;
using Core.Events.External;
using Core.Testing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Testing
{ 
    public class TestContext<TStartup>: IDisposable
        where TStartup : class
    {
        public HttpClient Client { get; private set; }

        private TestServer server;

        private readonly DummyExternalEventProducer externalEventProducer = new DummyExternalEventProducer();

        public TestContext()
        {
            SetUpClient();
        }

        private void SetUpClient()
        {
            var projectDir = Directory.GetCurrentDirectory();

            server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Tests")
                .UseContentRoot(projectDir)
                .UseConfiguration(new ConfigurationBuilder()
                    .SetBasePath(projectDir)
                    .AddJsonFile("appsettings.json", true)
                    .Build()
                )
                .ConfigureServices(services =>
                {
                    services.AddSingleton<IExternalEventProducer>(externalEventProducer);
                    services.AddSingleton<IExternalEventConsumer, DummyExternalEventConsumer>();
                })
                .UseStartup<TStartup>());

            Client = server.CreateClient();
        }

        public IReadOnlyCollection<TEvent> PublishedExternalEventsOfType<TEvent>()
        {
            return externalEventProducer.PublishedEvents.OfType<TEvent>().ToList();
        }

        public async Task PublishInternalEvent(IEvent @event)
        {
            using (var scope = server.Host.Services.CreateScope())
            {
                var eventBus = scope.ServiceProvider.GetRequiredService<IEventBus>();
                await eventBus.Publish(@event);
            }
        }

        public void Dispose()
        {
            server?.Dispose();
            Client?.Dispose();
        }
    }
}
