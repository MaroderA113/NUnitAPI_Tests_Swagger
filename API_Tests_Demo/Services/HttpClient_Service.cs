using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace API_Tests_Demo.Services;

public class HttpClient_Service
{
	private static readonly string Url = "https://reqres.in/api/";
	private readonly HttpClient _httpClient;

	public HttpClient_Service()
	{
		_httpClient = CreateHttpClient();

		_httpClient.BaseAddress = new Uri(Url);
		_httpClient.Timeout = new TimeSpan(0, 0, 30);
		_httpClient.DefaultRequestHeaders.Clear();
	}

	public async Task<HttpResponseMessage> GetUserInfoById(string userId)
	{
		_httpClient.DefaultRequestHeaders.Accept.Add(
						new MediaTypeWithQualityHeaderValue("application/json"));

		HttpResponseMessage response = await _httpClient.GetAsync($"users/{userId}");
		return response;
	}

	private HttpClient CreateHttpClient()
	{
		var socketsHandler = new SocketsHttpHandler { PooledConnectionLifetime = TimeSpan.FromMinutes(2) };
		var httpClient = new HttpClient(socketsHandler);
		
		//var handler = new HttpClientHandler();
		//var httpClient = new HttpClient(handler, false);

		return httpClient;
	}
}
