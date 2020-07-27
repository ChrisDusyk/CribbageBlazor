using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using CribBlazor.Game.IoC;
using CribBlazor.RestClient;
using CribBlazor.Client.Services;

namespace CribBlazor.Client
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.RootComponents.Add<App>("app");

			builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
			builder.Services.AddFunctionalRestClient();

			builder.Services.AddWeatherHandlers();

			builder.Services.AddDeckLogic();

			await builder.Build().RunAsync();
		}
	}
}
