using CribBlazor.Shared.Cards;
using CribBlazor.Shared.Errors;
using CribBlazor.Shared.Errors.ErrorCodes;
using Functional;
using System.Linq;

namespace CribBlazor.Game.Hand.Handlers
{
	internal class CalculateHandScoreHandler
	{
		public Result<int, ApplicationError> Calculate(Card[] hand, Card faceUpCard)
			=> from fullHand in CreateFullHand(hand, faceUpCard)
			   from fifteens in CalculateFifteens(fullHand)
			   from runs in CalculateRuns(fullHand)
			   select fifteens + runs;

		private Result<Card[], ApplicationError> CreateFullHand(Card[] hand, Card faceUpCard)
			=> Result.Try(() => hand.Append(faceUpCard).ToArray())
			.MapOnFailure(ex => GameLogicError.Create($"Error combining the hand and face up card", ErrorCodes.HandErrorCode.Create("Full hand")));

		private Result<int, ApplicationError> CalculateFifteens(Card[] hand)
			=> Result.Try(() =>
			{
				var pointSum = 0;

				// Actually calculate 15s

				return pointSum;
			})
			.MapOnFailure(ex => GameLogicError.Create($"Error calculating hand total: {ex.Message}", ErrorCodes.HandErrorCode.Create("15s")));

		private Result<int, ApplicationError> CalculateRuns(Card[] hand)
			=> Result.Try(() =>
			{
				var pointSum = 0;
				var orderedHand = hand.OrderBy(c => c.Face);

				return pointSum;
			})
			.MapOnFailure(ex => GameLogicError.Create($"Error calcuating hand total: {ex.Message}", ErrorCodes.HandErrorCode.Create("Runs")));
	}
}
