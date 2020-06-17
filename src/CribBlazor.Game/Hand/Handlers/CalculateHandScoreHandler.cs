using CribBlazor.Shared.Cards;
using CribBlazor.Shared.Errors;
using CribBlazor.Shared.Errors.ErrorCodes;
using Functional;
using System.Linq;

namespace CribBlazor.Game.Hand.Handlers
{
	internal class CalculateHandScoreHandler
	{
		private readonly CalculateFifteens _calculateFifteens;
		private readonly CalculateFlush _calculateFlush;
		private readonly CalculateNobs _calculateNobs;
		private readonly CalculatePairs _calculatePairs;
		private readonly CalculateRuns _calculateRuns;

		public CalculateHandScoreHandler(
			CalculateFifteens calculateFifteens,
			CalculateFlush calculateFlush,
			CalculateNobs calculateNobs,
			CalculatePairs calculatePairs,
			CalculateRuns calculateRuns)
		{
			_calculateFifteens = calculateFifteens;
			_calculateFlush = calculateFlush;
			_calculateNobs = calculateNobs;
			_calculatePairs = calculatePairs;
			_calculateRuns = calculateRuns;
		}

		public Result<int, ApplicationError> Calculate(Card[] hand, Card cutCard, bool isCrib)
			=> from allCards in CombineCards(hand, cutCard)
			   from fifteens in _calculateFifteens(allCards)
			   from flush in _calculateFlush(hand, cutCard, isCrib)
			   from runs in _calculateRuns(allCards)
			   from pairs in _calculatePairs(allCards)
			   from nobs in _calculateNobs(hand, cutCard)
			   select fifteens + flush + runs + pairs + nobs;

		private Result<Card[], ApplicationError> CombineCards(Card[] hand, Card cutCard)
			=> Result.Try(() => hand.Append(cutCard).ToArray())
			.MapOnFailure(ex => GameLogicError.Create($"Error combining hand and cut cards: {ex.Message}", ex, ErrorCodes.HandErrorCode.Create(ex.Message)));
	}
}
