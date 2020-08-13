using Microsoft.Extensions.DependencyInjection;

namespace CribBlazor.RestClient
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddFunctionalRestClient(this IServiceCollection services)
			=> services.AddSingleton<IRestClient, RestClient>();
	}
}
