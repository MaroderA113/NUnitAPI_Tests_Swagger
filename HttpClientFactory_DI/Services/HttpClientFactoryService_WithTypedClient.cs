using HttpClientFactory_DI.Clients;
using HttpClientFactory_DI.DataTransferObjects.NewtonsoftJson;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace HttpClientFactory_DI.Services
{
	public class HttpClientFactoryService_WithTypedClient : IHttpClientServiceImplementation
	{
		private readonly SingleUserClient _singleUserClient;

		public HttpClientFactoryService_WithTypedClient(SingleUserClient singleUserClient)
		{
			_singleUserClient = singleUserClient;
		}

		public async Task Execute()
		{
			await Test("6", 6);
		}

		private async Task Test(string useId, int expectedUserId)
		{
			var singleUserResponse = await GetUserInfoById_ReadAsStream(useId);
			Assert.AreEqual(expectedUserId, singleUserResponse.Data.Id);
			// поставить точку останова на этой строке, чтобы проверить результат выполнения
		}

		private async Task<SingleUserResponse> GetUserInfoById_ReadAsStream(string useId) => await _singleUserClient.GetUserInfoById_ReadAsStream(useId);
	}

}
