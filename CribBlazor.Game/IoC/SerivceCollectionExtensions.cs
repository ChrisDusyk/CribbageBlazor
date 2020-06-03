using CribBlazor.Game.Deck;
using CribBlazor.Game.Deck.Handlers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CribBlazor.Shared.IoC
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
				.AddDelegate<CreateFullDeck, CreateFullDeckHandler>(handler => handler.Create);
	}
}
