using NUnit.Framework;
using Newtonsoft.Json;
using FluentAssertions.Execution;
using System.Net;
using FluentAssertions;

namespace NUnitAPI_Tests_Swagger
{
	public class HttpClient_NUnitAPI_Tests_Swagger
	{
		[SetUp]
		public void Setup()
		{
		}

		[TestCase("6", "6")]
		[TestCase("10", "10")]
		public async Task GetUserInfoById(string userID, string expectedUserId)
		{
			var response = await HttpClient_GetUserInfoById(userID);
			
			using (new AssertionScope())
			{
				response.StatusCode.Should().Be(HttpStatusCode.OK);
				response.Content.Headers.ContentType.ToString().Should().Contain("application/json");
			};

			string responseContent = await response.Content.ReadAsStringAsync();
			UserResponse userResponse = JsonConvert.DeserializeObject<UserResponse>(responseContent);

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

		private async Task<HttpResponseMessage> HttpClient_GetUserInfoById(string userID)
		{	
			var URI = "https://reqres.in/api/users/" + userID.ToString();

			HttpClient httpClient = new HttpClient();
			httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");

			HttpResponseMessage response = await httpClient.GetAsync(URI);
			return response;
		}
	}
}
