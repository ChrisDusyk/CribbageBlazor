using CribBlazor.Shared.Cards;
using CribBlazor.Shared.Errors;
using CribBlazor.Shared.Errors.ErrorCodes;
using Functional;
using System.Linq;

namespace CribBlazor.Game.Hand.Handlers
{
	internal class CalculateNobsHandler
	{
		public Result<int, ApplicationError> Calculate(Card[] hand, Card cutCard)
			=> Result.Try(() => hand.Where(c => c.Face == Faces.Jack && c.Suit == cutCard.Suit).Count())
			.MapOnFailure(ex => GameLogicError.Create($"Error calculating Nobs points: {ex.Message}", ex, ErrorCodes.HandErrorCode.Create("Nobs")));
	}
}
