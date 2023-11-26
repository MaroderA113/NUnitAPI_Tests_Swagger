using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace API_Tests_Demo.Services
{
	public class HttpClientFactory_Service
	{
		private static readonly string Url = "https://reqres.in/api/";
		private readonly HttpClient _httpClient;

		public HttpClientFactory_Service()
		{
			_httpClient = CreateHttpClient();

			_httpClient.BaseAddress = new Uri(Url);
			_httpClient.Timeout = new TimeSpan(0, 0, 30);
			_httpClient.DefaultRequestHeaders.Clear();
		}

		public async Task<HttpResponseMessage> GetUserInfoById(string userId)
		{
			_httpClient.DefaultRequestHeaders.Accept.Add(
							new MediaTypeWithQualityHeaderValue("application/json"));

			HttpResponseMessage response = await _httpClient.GetAsync($"users/{userId}");
			return response;
		}

		private HttpClient CreateHttpClient()
		{
			var services = new ServiceCollection();
			services.AddHttpClient();

			var serviceProvider = services.BuildServiceProvider();
			var requiredService = serviceProvider.GetService<IHttpClientFactory>();
			var httpClient = requiredService.CreateClient();

			return httpClient;
		}
	}
}
