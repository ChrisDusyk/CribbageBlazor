﻿using CribBlazor.Server.Domain.GameSession;
using CribBlazor.Server.Persistence.GameSession;
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
			=> services.AddDelegate<CreateGameSession, CreateGameSessionHandler>(handler => handler.CreateMockedSession);
	}
}
