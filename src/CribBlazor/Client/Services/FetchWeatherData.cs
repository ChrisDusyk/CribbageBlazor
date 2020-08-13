using CribBlazor.Shared;
using CribBlazor.Shared.Errors;
using Functional;
using System.Threading;
using System.Threading.Tasks;

namespace CribBlazor.Client.Services
{
	public delegate Task<Result<WeatherForecast[], ApplicationError>> FetchWeatherData();
}
