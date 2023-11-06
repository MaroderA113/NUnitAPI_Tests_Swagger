using HttpClientFactory_DI.DataTransferObjects.NewtonsoftJson;
using HttpClientFactory_DI.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace HttpClientFactory_DI.Tests
{
	public class TypedClient_Tests
	{
		public TypedClient_Tests()
		{
		}

		public async Task GetUserInfoById(HttpClientFactoryService_TypedClient service, string useId, int expectedUserId)
		{
			var response = await service.GetUserInfoById_ReadAsStream(useId);

			using (var stream = await response.Content.ReadAsStreamAsync())
			{
				var serializer = new JsonSerializer();

				using (var sr = new StreamReader(stream))
				using (var jsonReader = new JsonTextReader(sr))
				{
					var singleUserResponse = serializer.Deserialize<SingleUserResponse>(jsonReader);
					
					Assert.AreEqual(expectedUserId, singleUserResponse.Data.Id);
					Console.WriteLine("expectedUserId = {0}, actualUserId = {1}", useId, singleUserResponse.Data.Id);
				}
			}
		}
	}
}
