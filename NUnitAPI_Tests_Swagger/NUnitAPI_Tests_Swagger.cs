using RestSharp;
using System.Net;
using Newtonsoft.Json;
using NUnit.Framework;
using FluentAssertions;
using FluentAssertions.Execution;

namespace NUnitAPI_Tests_Swagger
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[TestCase("6", "6")]
		[TestCase("10", "10")]
		public void GetUserInfoById(string userID, string expectedUserId)
		{
			var client = new RestClient("https://reqres.in/api/users/" + userID.ToString());
			client.Timeout = 3000;
			var request = new RestRequest(Method.GET);
			request.AddHeader("Content-Type", "application/json");
			var response = client.Execute(request);

			UserResponse userResponse = JsonConvert.DeserializeObject<UserResponse>(response.Content);

			using (new AssertionScope())
			{
				response.StatusCode.Should().Be(HttpStatusCode.OK);
				response.ContentType.Should().Contain("application/json");
				
				//Assert.That(userResponse.data.id, Is.EqualTo(expectedUserId));				
				userResponse.data.id.Should().BeEquivalentTo(expectedUserId);

				userResponse.data.email.Should().NotBeNullOrEmpty();
				userResponse.data.first_name.Should().NotBeNullOrEmpty();
				userResponse.data.last_name.Should().NotBeNullOrEmpty();
				userResponse.data.avatar.Should().NotBeNullOrEmpty();
				userResponse.support.url.Should().NotBeNullOrEmpty();
				userResponse.support.text.Should().NotBeNullOrEmpty();
			};
		}
	}

	/// <summary>
	/// Информация о пользователе.
	/// </summary>
	public class UserResponse
	{
		public Data? data;
		public Support? support;

		public class Support
		{
			public string? url;
			public string? text;
		}
		public class Data
		{
			public string? id;
			public string? email;
			public string? first_name;
			public string? last_name;
			public string? avatar;
		}
	}
}