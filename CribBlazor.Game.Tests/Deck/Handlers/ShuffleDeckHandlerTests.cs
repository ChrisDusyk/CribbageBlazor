using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FakeItEasy;
using FluentAssertions;
using Functional;
using CribBlazor.Game.Deck.Handlers;
using CardDeck = CribBlazor.Shared.Deck.Deck;
using CribBlazor.Game.Deck;
using CribBlazor.Shared.Cards;

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
