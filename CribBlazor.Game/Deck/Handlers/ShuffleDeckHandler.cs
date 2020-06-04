using CribBlazor.Shared.Cards;
using CribBlazor.Shared.Errors;
using CribBlazor.Shared.Errors.ErrorCodes;
using Functional;
using System;
using System.Linq;
using CardDeck = CribBlazor.Shared.Deck.Deck;

namespace CribBlazor.Game.Deck.Handlers
{
    public class ShuffleDeckHandler
    {
        private Random Random { get; } = new Random();

        public Result<CardDeck, ApplicationError> Shuffle(CardDeck deck)
            => from shuffledCards in ShuffleCards(deck.Cards)
               select CardDeck.Create(shuffledCards);

        private Result<Card[], ApplicationError> ShuffleCards(Card[] cards)
            => Result.Try(() =>
            {
                for (int n = cards.Length - 1; n >= 0; --n)
                {
                    var k = Random.Next(n + 1);
                    var temp = cards[n];
                    cards[n] = cards[k];
                    cards[k] = temp;
                }

                return cards;
            })
            .MapOnFailure(ex => GameLogicError.Create($"Error shuffling deck of cards: {ex.Message}", ex, ErrorCodes.DeckErrorCode.Create(ex.Message)));
    }
}
