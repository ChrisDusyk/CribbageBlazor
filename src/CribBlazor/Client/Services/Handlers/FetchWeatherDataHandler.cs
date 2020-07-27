using CribBlazor.RestClient;
using CribBlazor.Shared;
using CribBlazor.Shared.Errors;
using Functional;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CribBlazor.Client.Services.Handlers
{
	public class FetchWeatherDataHandler
	{
		private IRestClient RestClient { get; }

		public FetchWeatherDataHandler(IRestClient restClient)
			=> RestClient = restClient;

		public Task<Result<WeatherForecast[], ApplicationError>> GetResult()
			=> from weatherData in RestClient.GetFromJsonAsync<WeatherForecast[]>("WeatherForecast")
			   select weatherData;
	}
}
