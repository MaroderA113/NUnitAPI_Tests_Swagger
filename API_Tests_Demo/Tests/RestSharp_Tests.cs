using API_Tests_Demo.DataTransferObjects.NewtonsoftJson;
using API_Tests_Demo.Services;
using FluentAssertions;
using FluentAssertions.Execution;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Net;

namespace API_Tests_Demo.Tests;

public class RestSharp_Tests
{
	[SetUp]
	public void Setup()
	{
	}

	[Test]
	[TestCase("10", "10")]
	[Category("ApiTests")]
	public void GetUserInfoById(string userID, int expectedUserId)
	{
		RestSharp_Service restSharpService = new RestSharp_Service();
		var response = restSharpService.GetUserInfoById(userID);

		using (new AssertionScope())
		{
			response.StatusCode.Should().Be(HttpStatusCode.OK);
			response.ContentType.Should().Contain("application/json");
		};

		SingleUserResponse singleUserResponse = JsonConvert.DeserializeObject<SingleUserResponse>(response.Content);

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