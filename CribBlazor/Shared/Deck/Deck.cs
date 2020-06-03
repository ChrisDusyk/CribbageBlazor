using CribBlazor.Shared.Cards;

namespace CribBlazor.Shared.Deck
{
	public class Deck
	{
		public Deck(Card[] cards)
		{
			Cards = cards;
		}

		public Card[] Cards { get; }

		public static Deck Create(Card[] cards) => new Deck(cards);
	}
}
