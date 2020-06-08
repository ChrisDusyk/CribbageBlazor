using CribBlazor.Game.Deck.Handlers;
using CribBlazor.Shared.Cards;
using FluentAssertions;
using Functional;
using System.Collections.Generic;
using Xunit;
using CribBlazor.Tests;

namespace CribBlazor.Game.Tests.Deck.Handlers
{
	public class CreateFullDeckHandlerTests
	{
		[Fact]
		public void Handler_WhenCalled_ReturnsValidDeckOfCards()
		{
			var sut = new CreateFullDeckHandler();
			var result = sut.Create();

			result.AssertSuccess();

			var deck = result.Success().ValueOrDefault();
			deck.Should().BeEquivalentTo(GenerateValidDeck());
		}

		private Shared.Deck.Deck GenerateValidDeck()
		{
			var cards = new List<Card>();

			foreach (var suit in EnumHelper.EnumerateEnum<Suits>())
			{
				foreach (var face in EnumHelper.EnumerateEnum<Faces>())
				{
					cards.Add(Card.Create(suit, face));
				}
			}

			return Shared.Deck.Deck.Create(cards.ToArray());
		}
	}
}
