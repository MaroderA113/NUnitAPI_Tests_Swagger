using HttpClientFactory_DI.Clients;
using HttpClientFactory_DI.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace HttpClientFactory_DI
{
	class Program
	{
		static async Task Main(string[] args)
		{
			var services = new ServiceCollection();
			ConfigureServices(services);
			 
			var serviceProvider = services.BuildServiceProvider();
			var requiredService = serviceProvider.GetRequiredService<IHttpClientServiceImplementation>();

			await requiredService.Execute();
		}

		private static void ConfigureServices(IServiceCollection services)
		{
			// WithDefaultClient
			services.AddHttpClient();
			services.AddScoped<IHttpClientServiceImplementation, HttpClientFactoryService_DefaultClient>();

			// WithNamedClient
			//services.AddHttpClient("SingleUserClient", config =>
			//{
			//	config.BaseAddress = new Uri("https://reqres.in/api/");
			//	config.Timeout = new TimeSpan(0, 0, 30);
			//	config.DefaultRequestHeaders.Clear();
			//});
			//services.AddScoped<IHttpClientServiceImplementation, HttpClientFactoryService_NamedClient>();

			// WithTypedClient
			//services.AddHttpClient<SingleUserClient>();
			//services.AddScoped<IHttpClientServiceImplementation, HttpClientFactoryService_TypedClient>();
		}

	}
}
