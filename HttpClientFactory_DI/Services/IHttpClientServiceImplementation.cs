using System.Threading.Tasks;

namespace HttpClientFactory_DI.Services
{
	public interface IHttpClientServiceImplementation
	{
		Task Execute();
	}
}
