using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace API_Tests_Demo.Services;

public class HttpClient_Service
{
	private static readonly string Url = "https://reqres.in/api/";
	private static HttpClient httpClient = new HttpClient();

	public HttpClient_Service()
	{
		httpClient.BaseAddress = new Uri(Url);
		httpClient.Timeout = new TimeSpan(0, 0, 30);
		httpClient.DefaultRequestHeaders.Clear();
	}

	public async Task<HttpResponseMessage> GetUserInfoById(string userId)
	{
		httpClient.DefaultRequestHeaders.Accept.Add(
						new MediaTypeWithQualityHeaderValue("application/json"));

		HttpResponseMessage response = await httpClient.GetAsync($"users/{userId}");
		return response;
	}
}
