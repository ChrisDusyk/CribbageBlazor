using CribBlazor.Client.Services.Handlers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CribBlazor.Client.Services
{
	internal static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddDelegate<TDelegate, TImplementation>(this IServiceCollection services, Func<TImplementation, TDelegate> delegateFactory)
			where TDelegate : class
			where TImplementation : class
		{
			services.TryAddTransient<TImplementation>();

			services.AddTransient(serviceProvider => delegateFactory.Invoke(serviceProvider.GetRequiredService<TImplementation>()));

			return services;
		}

		public static IServiceCollection AddWeatherHandlers(this IServiceCollection services)
			=> services.AddDelegate<FetchWeatherData, FetchWeatherDataHandler>(handler => handler.GetResult);
	}
}
