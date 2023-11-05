using System;
using System.Text.Json.Serialization;

namespace HttpClientFactory_DI.DataTransferObjects.SystemTextJson
{
	/// <summary>
	/// Информация о пользователе.
	/// </summary>
	public class SingleUserResponse
	{
		public Data Data { get; set; }
		public Support Support { get; set; }
	}

	public class Data
	{
		public int Id { get; set; }
		public string Email { get; set; }
		[JsonPropertyName("first_name")]
		public string FirstName { get; set; }
		[JsonPropertyName("last_name")]
		public string LastName { get; set; }
		public Uri Avatar { get; set; }
	}

	public class Support
	{
		public Uri Url { get; set; }
		public string Text { get; set; }
	}

}
