using HttpClientFactory_DI.DataTransferObjects.NewtonsoftJson;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpClientFactory_DI.Services
{
	public class HttpClientFactoryService_WithNamedClient : IHttpClientServiceImplementation
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public HttpClientFactoryService_WithNamedClient(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task Execute()
		{
			await Test("6", 6);
		}

		private async Task Test(string useId, int expectedUserId)
		{
			var singleUserResponse = await GetUserInfoById_ReadAsString(useId);
			Assert.AreEqual(expectedUserId, singleUserResponse.Data.Id);
			// поставить точку останова на этой строке, чтобы проверить результат выполнения
		}

		private async Task<SingleUserResponse> GetUserInfoById_ReadAsString(string useId)
		{
			var httpClient = _httpClientFactory.CreateClient("SingleUserClient");

			using (var response = await httpClient.GetAsync($"users/{useId}", HttpCompletionOption.ResponseHeadersRead))
			{
				response.EnsureSuccessStatusCode();

				var responseString = await response.Content.ReadAsStringAsync();
				var singleUserResponse = JsonConvert.DeserializeObject<SingleUserResponse>(responseString);
				return singleUserResponse;
			}
		}

	}
}
