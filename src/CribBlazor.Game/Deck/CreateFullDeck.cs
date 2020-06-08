using CribBlazor.Shared.Errors;
using Functional;

namespace CribBlazor.Game.Deck
{
	public delegate Result<Shared.Deck.Deck, ApplicationError> CreateFullDeck();
}