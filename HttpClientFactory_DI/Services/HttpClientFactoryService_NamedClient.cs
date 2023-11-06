using HttpClientFactory_DI.Tests;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpClientFactory_DI.Services
{
	public class HttpClientFactoryService_NamedClient : IHttpClientServiceImplementation
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly NamedClient_Tests _namedClient_Tests;

		public HttpClientFactoryService_NamedClient(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
			_namedClient_Tests = new NamedClient_Tests();
		}

		public async Task Execute()
		{
			await _namedClient_Tests.GetUserInfoById(this, "6", 6);
		}

		public async Task<HttpResponseMessage> GetUserInfoById_ReadAsString(string useId)
		{
			var httpClient = _httpClientFactory.CreateClient("SingleUserClient");

			var response = await httpClient.GetAsync($"users/{useId}", HttpCompletionOption.ResponseHeadersRead);
			response.EnsureSuccessStatusCode();

			return response;
		}

	}
}
