using Refit;
using System.Threading.Tasks;

namespace API_Tests_Demo.Services
{
	public interface IRefitService
	{
		[Get("/users/{userId}")]
		Task<string> GetUserInfoById(string userId);
	}
}
