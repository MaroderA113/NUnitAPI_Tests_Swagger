using HttpClientFactory_DI.DataTransferObjects.NewtonsoftJson;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpClientFactory_DI.Clients
{
	public class SingleUserClient
	{
		private readonly HttpClient _client;

		public SingleUserClient(HttpClient client)
		{
			_client = client;

			_client.BaseAddress = new Uri("https://reqres.in/api/");
			_client.Timeout = new TimeSpan(0, 0, 30);
			_client.DefaultRequestHeaders.Clear();
		}

		public async Task<SingleUserResponse> GetUserInfoById_ReadAsStream(string useId)
		{
			using (var response = await _client.GetAsync($"users/{useId}", HttpCompletionOption.ResponseHeadersRead))
			{
				response.EnsureSuccessStatusCode();

				var stream = await response.Content.ReadAsStreamAsync();
				var serializer = new JsonSerializer();

				using (var sr = new StreamReader(stream))
				using (var jsonReader = new JsonTextReader(sr))
				{
					var singleUserResponse = serializer.Deserialize<SingleUserResponse>(jsonReader);
					return singleUserResponse;
				}
			}
		}
	}
}
