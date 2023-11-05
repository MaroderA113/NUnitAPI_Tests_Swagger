using RestSharp;
using System;

namespace API_Tests_Demo.Services;

public class RestSharp_Service
{
	private static readonly string Url = "https://reqres.in/api/";
	private static RestClient restClient = new RestClient();

	public RestSharp_Service()
	{
		restClient.BaseUrl = new Uri(Url);
		restClient.Timeout = 30000;
	}

	public IRestResponse GetUserInfoById(string userId)
	{
		RestRequest request = new RestRequest($"users/{userId}", Method.GET);
		request.AddHeader("Content-Type", "application/json");

		IRestResponse response = restClient.Execute(request);
		return response;
	}
}