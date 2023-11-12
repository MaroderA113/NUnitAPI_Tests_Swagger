using API_Tests_Demo.DataTransferObjects.SystemTextJson;
using API_Tests_Demo.Services;
using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;
using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace API_Tests_Demo.Tests;

public class HttpClient_Tests
{
	//private static HttpMessageHandler handler = new HttpClientHandler();
	//private static HttpClient httpClient = new HttpClient(handler, false);

	private static SocketsHttpHandler socketsHandler = new SocketsHttpHandler
	{
		PooledConnectionLifetime = TimeSpan.FromMinutes(2)
	};
	private static HttpClient httpClient = new HttpClient(socketsHandler);

	private static HttpClient_Service httpClientService = new HttpClient_Service(httpClient);
	private static JsonSerializerOptions _options;

	[SetUp]
	public void Setup()
	{
	}

	[Test]
	[TestCase("6", 6)]
	[TestCase("10", 10)]
	[Category("ApiTests")]
	public async Task GetUserInfoById(string userID, int expectedUserId)
	{
		var response = await httpClientService.GetUserInfoById(userID);

		using (new AssertionScope())
		{
			response.StatusCode.Should().Be(HttpStatusCode.OK);
			response.Content.Headers.ContentType.ToString().Should().Contain("application/json");
		};

		string responseContent = await response.Content.ReadAsStringAsync();

		_options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
		var singleUserResponse = JsonSerializer.Deserialize<SingleUserResponse>(responseContent, _options);

		using (new AssertionScope())
		{
			singleUserResponse.Data.Id.Should().Be(expectedUserId);
			singleUserResponse.Data.Email.Should().NotBeNullOrEmpty();
			singleUserResponse.Data.FirstName.Should().NotBeNullOrEmpty();
			singleUserResponse.Data.LastName.Should().NotBeNullOrEmpty();
			singleUserResponse.Data.Avatar.ToString().Should().NotBeNullOrEmpty();
			singleUserResponse.Support.Url.ToString().Should().NotBeNullOrEmpty();
			singleUserResponse.Support.Text.Should().NotBeNullOrEmpty();
		};
	}

}
