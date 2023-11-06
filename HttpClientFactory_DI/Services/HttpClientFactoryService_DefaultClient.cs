using HttpClientFactory_DI.Tests;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HttpClientFactory_DI.Services
{
	public class HttpClientFactoryService_DefaultClient : IHttpClientServiceImplementation
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly DefaultClient_Tests _defaultClient_Tests;

		public HttpClientFactoryService_DefaultClient(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
			_defaultClient_Tests = new DefaultClient_Tests();
		}

		public async Task Execute()
		{
			await _defaultClient_Tests.GetUserInfoById(this, "6", 6);
		}

		public async Task<HttpResponseMessage> GetUserInfoById_HttpRequestMessage(string useId)
		{
			var httpClient = _httpClientFactory.CreateClient();
			httpClient.DefaultRequestHeaders.Clear();

			var request = new HttpRequestMessage(HttpMethod.Get, $"https://reqres.in/api/users/{useId}");
			request.Headers.Accept.Add(
				new MediaTypeWithQualityHeaderValue("application/json"));

			var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
			response.EnsureSuccessStatusCode();

			return response;
		}

	}
}
