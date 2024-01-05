using System.Net.Http;
using System.Threading.Tasks;

namespace API_Tests_Demo.Services;

public interface IRestService
{
	Task<HttpResponseMessage> GetUserInfoById(string userId);
}
