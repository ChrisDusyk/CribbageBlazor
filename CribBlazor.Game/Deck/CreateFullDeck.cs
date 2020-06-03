using Functional;
using System;

namespace CribBlazor.Game.Deck
{
	public delegate Result<Shared.Deck.Deck, Exception> CreateFullDeck();
}