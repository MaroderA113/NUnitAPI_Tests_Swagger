using API_Tests_Demo.DataTransferObjects.NewtonsoftJson;
using API_Tests_Demo.Services;
using FluentAssertions;
using FluentAssertions.Execution;
using Newtonsoft.Json;
using NUnit.Framework;
using Refit;
using System.Threading.Tasks;

namespace API_Tests_Demo.Tests
{
	public class Refit_Tests
	{
		private static readonly string Url = "https://reqres.in/api/";
		private readonly IRefitService _httpRefitService;

		public Refit_Tests()
		{
			_httpRefitService = RestService.For<IRefitService>(Url);
		}

		[Test]
		[TestCase("6", 6)]
		[TestCase("10", 10)]
		[Category("ApiTests")]
		public async Task GetUserInfoById(string userID, int expectedUserId)
		{
			var response = await _httpRefitService.GetUserInfoById(userID);

			SingleUserResponse singleUserResponse = JsonConvert.DeserializeObject<SingleUserResponse>(response);

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
}
