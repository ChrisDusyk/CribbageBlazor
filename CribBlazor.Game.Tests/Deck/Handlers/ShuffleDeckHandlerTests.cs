using CribBlazor.Game.Deck.Handlers;
using CribBlazor.Shared.Cards;
using CribBlazor.Tests;
using FluentAssertions;
using Functional;
using Xunit;

namespace CribBlazor.Game.Tests.Deck.Handlers
{
	public class ShuffleDeckHandlerTests
	{
		[Fact]
		public void Deck_ShouldBeShuffled_WhenCalled()
		{
			var deck = Helpers.CreateDeck();
			var sut = new ShuffleDeckHandler();

			var result = sut.Shuffle(deck);

			result.AssertSuccess();

			var success = result.Success().ValueOrDefault();
			success.Cards.Should().BeEquivalentTo(deck.Cards);

			// Check ordering changed
			success.Cards[0].Should().NotBe(Card.Create(Suits.Clubs, Faces.Ace));
		}
	}
}
