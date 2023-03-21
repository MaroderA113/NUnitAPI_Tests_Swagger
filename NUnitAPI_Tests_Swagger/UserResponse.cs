namespace NUnitAPI_Tests_Swagger
{
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
