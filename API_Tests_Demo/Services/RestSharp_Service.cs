using RestSharp;
using System;

namespace API_Tests_Demo.Services;

public class RestSharp_Service
{
	private static readonly string Url = "https://reqres.in/api/";
	private readonly RestClient _restClient;

	public RestSharp_Service()
	{
		_restClient = CreateHttpClient();

		_restClient.BaseUrl = new Uri(Url);
		_restClient.Timeout = 30000;
	}

	public IRestResponse GetUserInfoById(string userId)
	{
		RestRequest request = new RestRequest($"users/{userId}", Method.GET);
		request.AddHeader("Content-Type", "application/json");

		IRestResponse response = _restClient.Execute(request);
		return response;
	}

	private RestClient CreateHttpClient()
	{
		var restClient = new RestClient();

		return restClient;
	}
}