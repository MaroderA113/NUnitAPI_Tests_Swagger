using RestSharp;
using System.Net;
using Newtonsoft.Json;
using NUnit.Framework;

namespace NUnitAPI_Tests_Swagger
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		/// <summary>
		/// Получить информацию о пользователе.
		/// </summary>
		/// <param name="userID"></param>
		[TestCase(6)]
		public void GetUserInfoById(int userID)
		{
			var client = new RestClient("https://reqres.in/api/users/" + userID.ToString());
			client.Timeout = 3000;
			var request = new RestRequest(Method.GET);
			request.AddHeader("Content-Type", "application/json");
			var response = client.Execute(request);

			Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

			Assert.IsTrue(response.ContentType.StartsWith("application/json"));

			UserResponse userResponse = JsonConvert.DeserializeObject<UserResponse>(response.Content);

			Assert.That(userResponse.data.id, Is.EqualTo(6));
			Assert.That(!string.IsNullOrEmpty(userResponse.data.email));
			Assert.That(!string.IsNullOrEmpty(userResponse.data.first_name));
			Assert.That(!string.IsNullOrEmpty(userResponse.data.last_name));
			Assert.That(!string.IsNullOrEmpty(userResponse.data.avatar));
			Assert.That(!string.IsNullOrEmpty(userResponse.support.url));
			Assert.That(!string.IsNullOrEmpty(userResponse.support.text));
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
			public int id;
			public string? email;
			public string? first_name;
			public string? last_name;
			public string? avatar;
		}
	}
}