using RestSharp;
using System.Net;
using Newtonsoft.Json;
using NUnit.Framework;
using FluentAssertions;
using FluentAssertions.Execution;

namespace NUnitAPI_Tests_Swagger
{
	public class RestSharp_NUnitAPI_Tests_Swagger
	{
		[SetUp]
		public void Setup()
		{
		}

		[TestCase("6", "6")]
		[TestCase("10", "10")]
		public void GetUserInfoById(string userID, string expectedUserId)
		{
			var response = RestSharp_GetUserInfoById(userID);

			using (new AssertionScope())
			{
				response.StatusCode.Should().Be(HttpStatusCode.OK);
				response.ContentType.Should().Contain("application/json");
			};

			UserResponse userResponse = JsonConvert.DeserializeObject<UserResponse>(response.Content);

			using (new AssertionScope())
			{			
				userResponse.data.id.Should().BeEquivalentTo(expectedUserId);
				userResponse.data.email.Should().NotBeNullOrEmpty();
				userResponse.data.first_name.Should().NotBeNullOrEmpty();
				userResponse.data.last_name.Should().NotBeNullOrEmpty();
				userResponse.data.avatar.Should().NotBeNullOrEmpty();
				userResponse.support.url.Should().NotBeNullOrEmpty();
				userResponse.support.text.Should().NotBeNullOrEmpty();
			};
		}

		public IRestResponse RestSharp_GetUserInfoById(string userID)
		{
			var URI = "https://reqres.in/api/users/" + userID.ToString();

			var client = new RestClient(URI);
			client.Timeout = 3000;
			var request = new RestRequest(Method.GET);
			request.AddHeader("Content-Type", "application/json");

			var response = client.Execute(request);
			return response;
		}
	}
}