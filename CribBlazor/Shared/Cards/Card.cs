using Newtonsoft.Json;

namespace CribBlazor.Shared.Cards
{
	public class Card
	{
		public Card(Suits suit, Faces face)
		{
			Suit = suit;
			Face = face;
		}

		public Suits Suit { get; }
		public Faces Face { get; }

		public static Card Create(Suits suit, Faces face) => new Card(suit, face);

		public static Card FromJson(string json) => JsonConvert.DeserializeObject<Card>(json);
	}
}
