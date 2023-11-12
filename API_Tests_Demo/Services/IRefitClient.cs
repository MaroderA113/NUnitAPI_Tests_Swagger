using Refit;
using System.Threading.Tasks;

namespace API_Tests_Demo.Services
{
	public interface IRefitClient
	{
		[Get("/users/{userId}")]
		Task<string> GetUser(string userId);
	}
}
