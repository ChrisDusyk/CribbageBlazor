using CribBlazor.Shared.Cards;
using CribBlazor.Shared.Errors;
using CribBlazor.Shared.Errors.ErrorCodes;
using Functional;
using System.Linq;

namespace CribBlazor.Game.Hand.Handlers
{
	internal class CalculateFlushHandler
	{
		public Result<int, ApplicationError> Calculate(Card[] hand, Card cutCard, bool isCrib)
			=> isCrib
				? CalculateCribFlush(hand.Append(cutCard).ToArray())
				: CalculateHandFlush(hand, cutCard);

		private Result<int, ApplicationError> CalculateHandFlush(Card[] hand, Card cutCard)
			=> Result.Try(() =>
				hand.All(c => c.Suit == hand[0].Suit)
					? hand
						.Append(cutCard)
						.All(c => c.Suit == hand[0].Suit)
						? hand.Length + 1
						: hand.Length
					: 0)
			.MapOnFailure(ex => GameLogicError.Create($"Error calculating a flush in the hand", ex, ErrorCodes.HandErrorCode.Create("Flush")));

		private Result<int, ApplicationError> CalculateCribFlush(Card[] cards)
			=> Result.Try(() =>
				cards.All(c => c.Suit == cards[0].Suit)
					? cards.Length
					: 0)
			.MapOnFailure(ex => GameLogicError.Create($"Error calculating a flush in the crib", ex, ErrorCodes.HandErrorCode.Create("Flush")));
	}
}
