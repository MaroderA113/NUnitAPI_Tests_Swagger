using System;
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

		public async Task<HttpResponseMessage> GetUserInfoById_ReadAsStream(string useId)
		{
			var response = await _client.GetAsync($"users/{useId}", HttpCompletionOption.ResponseHeadersRead);
			response.EnsureSuccessStatusCode();

			return response;
		}
	}
}
