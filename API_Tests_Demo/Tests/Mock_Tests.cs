using API_Tests_Demo.DataTransferObjects.NewtonsoftJson;
using API_Tests_Demo.Services;
using FluentAssertions;
using FluentAssertions.Execution;
using Moq;
using NUnit.Framework;
using System;

namespace API_Tests_Demo.Tests
{
	public class Mock_Tests
	{
		private static Mock<IMockService> _mockRepository;
		private static IMockService _mockService;


		[SetUp]
		public void Setup()
		{
			_mockRepository = new Mock<IMockService>();
		}

		[Test]
		[TestCase("6", 6)]
		[Category("ApiTests")]
		public void GetUserInfoById(string userID, int expectedUserId)
		{
			// Arrange
			var expectedResponse = new SingleUserResponse
			{
				Data = new Data
				{
					Id = 6,
					Email = "tracey.ramos@reqres.in",
					FirstName = "Tracey",
					LastName = "Ramos",
					Avatar = new Uri("https://reqres.in/img/faces/6-image.jpg")
				},
				Support = new Support
				{
					Url = new Uri("https://reqres.in/#support-heading"),
					Text = "To keep ReqRes free, contributions towards server costs are appreciated!"
				}
			};

			_mockRepository
				.Setup(repo => repo.GetUserInfoById(expectedResponse.Data.Id.ToString()))
				.Returns(expectedResponse);
			_mockService = _mockRepository.Object;

			// Act
			var result = _mockService.GetUserInfoById(userID);

			// Assert
			_mockRepository.Verify(repo => repo.GetUserInfoById(userID), Times.Once);

			using (new AssertionScope())
			{
				result.Should().NotBeNull();
				result.Data.Id.Should().Be(expectedUserId);
				result.Data.Email.Should().NotBeNullOrEmpty();
				result.Data.FirstName.Should().NotBeNullOrEmpty();
				result.Data.LastName.Should().NotBeNullOrEmpty();
				result.Data.Avatar.ToString().Should().NotBeNullOrEmpty();
				result.Support.Url.ToString().Should().NotBeNullOrEmpty();
				result.Support.Text.Should().NotBeNullOrEmpty();
			};
		}
	}
}
