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
	private static RestSharp_Service _restSharpService;

	[SetUp]
	public void Setup()
	{
		_restSharpService = new ();
	}

	[Test]
	[TestCase("6", 6)]
	[TestCase("10", 10)]
	[Category("ApiTests")]
	public void GetUserInfoById(string userID, int expectedUserId)
	{
		var response = _restSharpService.GetUserInfoById(userID);

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