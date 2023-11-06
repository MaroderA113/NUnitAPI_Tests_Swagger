using HttpClientFactory_DI.DataTransferObjects.SystemTextJson;
using HttpClientFactory_DI.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace HttpClientFactory_DI.Tests
{
	public class DefaultClient_Tests
	{
		private readonly JsonSerializerOptions _options;

		public DefaultClient_Tests()
		{
			_options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
		}

		public async Task GetUserInfoById(HttpClientFactoryService_DefaultClient service, string useId, int expectedUserId)
		{
			var response = await service.GetUserInfoById_HttpRequestMessage(useId);

			var responseContent = await response.Content.ReadAsStringAsync();
			var singleUserResponse = JsonSerializer.Deserialize<SingleUserResponse>(responseContent, _options);

			Assert.AreEqual(expectedUserId, singleUserResponse.Data.Id);
			Console.WriteLine("expectedUserId = {0}, actualUserId = {1}", useId, singleUserResponse.Data.Id);
		}
	}
}
