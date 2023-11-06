using HttpClientFactory_DI.Clients;
using HttpClientFactory_DI.Tests;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpClientFactory_DI.Services
{
	public class HttpClientFactoryService_TypedClient : IHttpClientServiceImplementation
	{
		private readonly SingleUserClient _singleUserClient;
		private readonly TypedClient_Tests _typedClient_Tests;

		public HttpClientFactoryService_TypedClient(SingleUserClient singleUserClient)
		{
			_singleUserClient = singleUserClient;
			_typedClient_Tests = new TypedClient_Tests();
		}

		public async Task Execute()
		{
			await _typedClient_Tests.GetUserInfoById(this, "6", 6);
		}

		public async Task<HttpResponseMessage> GetUserInfoById_ReadAsStream(string useId) => await _singleUserClient.GetUserInfoById_ReadAsStream(useId);
	}

}
