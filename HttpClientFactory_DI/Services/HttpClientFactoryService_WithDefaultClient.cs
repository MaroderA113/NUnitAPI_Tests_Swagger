using HttpClientFactory_DI.DataTransferObjects.SystemTextJson;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace HttpClientFactory_DI.Services
{
	public class HttpClientFactoryService_WithDefaultClient : IHttpClientServiceImplementation
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly JsonSerializerOptions _options;

		public HttpClientFactoryService_WithDefaultClient(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
			_options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
		}

		public async Task Execute()
		{
			await Test("6", 6);
		}

		private async Task Test(string useId, int expectedUserId)
		{
			var singleUserResponse = await GetUserInfoById_HttpRequestMessage(useId);
			Assert.AreEqual(expectedUserId, singleUserResponse.Data.Id);
			// поставить точку останова на этой строке, чтобы проверить результат выполнения
		}

		private async Task<SingleUserResponse> GetUserInfoById_HttpRequestMessage(string useId)
		{
			var httpClient = _httpClientFactory.CreateClient();
			httpClient.DefaultRequestHeaders.Clear();

			var request = new HttpRequestMessage(HttpMethod.Get, $"https://reqres.in/api/users/{useId}");
			request.Headers.Accept.Add(
				new MediaTypeWithQualityHeaderValue("application/json"));

			var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
			response.EnsureSuccessStatusCode();

			var responseContent = await response.Content.ReadAsStringAsync();
			var singleUserResponse = JsonSerializer.Deserialize<SingleUserResponse>(responseContent, _options);
			return singleUserResponse;	
		}

	}
}
