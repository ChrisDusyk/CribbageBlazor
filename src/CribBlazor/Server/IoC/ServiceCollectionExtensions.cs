using CribBlazor.Server.Domain.GameState;
using CribBlazor.Server.Persistence.GameState;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace CribBlazor.Server.IoC
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddDelegate<TDelegate, TImplementation>(this IServiceCollection services, Func<TImplementation, TDelegate> delegateFactory)
			where TDelegate : class
			where TImplementation : class
		{
			services.TryAddTransient<TImplementation>();

			services.AddTransient(serviceProvider => delegateFactory.Invoke(serviceProvider.GetRequiredService<TImplementation>()));

			return services;
		}

		public static IServiceCollection AddServerHandlers(this IServiceCollection services)
			=> services.AddDelegate<CreateNewGame, CreateNewGameHandler>(handler => handler.CreateMockedSession);
	}
}
