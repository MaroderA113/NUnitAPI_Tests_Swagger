using API_Tests_Demo.DataTransferObjects.SystemTextJson;
using API_Tests_Demo.Services;
using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace API_Tests_Demo.Tests;

public class HttpClient_Tests
{
	private static JsonSerializerOptions _options;

	[SetUp]
	public void Setup()
	{
	}

	[Test]
	[TestCase("6", "6")]
	[Category("ApiTests")]
	public async Task GetUserInfoById(string userID, int expectedUserId)
	{
		HttpClient_Service httpClientService = new HttpClient_Service();
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
