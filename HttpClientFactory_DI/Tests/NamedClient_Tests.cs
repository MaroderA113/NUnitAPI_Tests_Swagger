using HttpClientFactory_DI.DataTransferObjects.NewtonsoftJson;
using HttpClientFactory_DI.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace HttpClientFactory_DI.Tests
{
	public class NamedClient_Tests
	{
		public NamedClient_Tests()
		{
		}

		public async Task GetUserInfoById(HttpClientFactoryService_NamedClient service, string useId, int expectedUserId)
		{
			var response = await service.GetUserInfoById_ReadAsString(useId);

			var responseString = await response.Content.ReadAsStringAsync();
			var singleUserResponse = JsonConvert.DeserializeObject<SingleUserResponse>(responseString);

			Assert.AreEqual(expectedUserId, singleUserResponse.Data.Id);
			Console.WriteLine("expectedUserId = {0}, actualUserId = {1}", useId, singleUserResponse.Data.Id);
		}
	}
}
