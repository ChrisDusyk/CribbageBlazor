using CribBlazor.Shared.Cards;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Functional;

namespace CribBlazor.Game.Deck.Handlers
{
	public class CreateFullDeckHandler
	{
		public Result<Shared.Deck.Deck, Exception> Create()
			=> from cards in CreateCards()
			   select Shared.Deck.Deck.Create(cards);

		private Result<Card[], Exception> CreateCards()
			=> Result.Try(() =>
			{
				return (from suits in EnumHelper.EnumerateEnum<Suits>()
						from faces in EnumHelper.EnumerateEnum<Faces>()
						select Card.Create(suits, faces)).ToArray();
			});

	}
}
