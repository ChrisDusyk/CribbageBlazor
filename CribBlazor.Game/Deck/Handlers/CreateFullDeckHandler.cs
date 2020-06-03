using CribBlazor.Shared.Cards;
using CribBlazor.Shared.Errors;
using CribBlazor.Shared.Errors.ErrorCodes;
using Functional;
using System.Linq;

namespace CribBlazor.Game.Deck.Handlers
{
	public class CreateFullDeckHandler
	{
		public Result<Shared.Deck.Deck, ApplicationError> Create()
			=> from cards in CreateCards()
			   select Shared.Deck.Deck.Create(cards);

		private Result<Card[], ApplicationError> CreateCards()
			=> Result.Try(() =>
			{
				return (from suits in EnumHelper.EnumerateEnum<Suits>()
						from faces in EnumHelper.EnumerateEnum<Faces>()
						select Card.Create(suits, faces)).ToArray();
			})
			.MapOnFailure(ex => GameLogicError.Create($"Error creating deck of cards: {ex.Message}", ex, ErrorCodes.DeckErrorCode.Create(ex.Message)));

	}
}
