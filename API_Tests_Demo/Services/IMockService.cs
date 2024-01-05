using API_Tests_Demo.DataTransferObjects.NewtonsoftJson;

namespace API_Tests_Demo.Services;

public interface IMockService
{
	SingleUserResponse GetUserInfoById(string userId);
}
