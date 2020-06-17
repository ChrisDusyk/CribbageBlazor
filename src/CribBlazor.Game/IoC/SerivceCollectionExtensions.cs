using CribBlazor.Game.Deck;
using CribBlazor.Game.Deck.Handlers;
using CribBlazor.Game.Hand;
using CribBlazor.Game.Hand.Handlers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace CribBlazor.Game.IoC
{
	public static class SerivceCollectionExtensions
	{
		public static IServiceCollection AddDelegate<TDelegate, TImplementation>(this IServiceCollection services, Func<TImplementation, TDelegate> delegateFactory)
			where TDelegate : class
			where TImplementation : class
		{
			services.TryAddTransient<TImplementation>();

			services.AddTransient(serviceProvider => delegateFactory.Invoke(serviceProvider.GetRequiredService<TImplementation>()));

			return services;
		}

		public static IServiceCollection AddDeckLogic(this IServiceCollection services)
			=> services
				.AddDelegate<CreateFullDeck, CreateFullDeckHandler>(handler => handler.Create)
				.AddDelegate<CalculateHandScore, CalculateHandScoreHandler>(handler => handler.Calculate)
				.AddDelegate<CalculateRuns, CalculateRunsHandler>(handler => handler.Calculate)
				.AddDelegate<CalculateFlush, CalculateFlushHandler>(handler => handler.Calculate)
				.AddDelegate<CalculatePairs, CalculatePairsHandler>(handler => handler.CalculatePairs);
	}
}
