using CribBlazor.Shared.Cards;
using CribBlazor.Shared.Errors;
using CribBlazor.Shared.Errors.ErrorCodes;
using Functional;
using System.Linq;

namespace CribBlazor.Game.Hand.Handlers
{
	internal class CalculatePairsHandler
	{
		public Result<int, ApplicationError> CalculatePairs(Card[] cards)
			=> from duplicates in CreateArrayOfDuplicates(cards)
			   from sum in SumPairs(duplicates)
			   select sum;

		private Result<int[], ApplicationError> CreateArrayOfDuplicates(Card[] cards)
			=> Result.Try(() =>
			{
				var duplicates = new int[14];
				for (var i = 0; i < duplicates.Length; ++i)
					duplicates[i] = 0;

				foreach (var card in cards)
					duplicates[(int)card.Face]++;

				return duplicates;
			})
			.MapOnFailure(ex => GameLogicError.Create($"Error creating array of duplicates: {ex.Message}", ex, ErrorCodes.HandErrorCode.Create("Pairs")));

		private Result<int, ApplicationError> SumPairs(int[] duplicates)
			=> Result.Try(() => duplicates.Sum(d => d * (d - 1)))
			.MapOnFailure(ex => GameLogicError.Create($"Error summing points for pairs: {ex.Message}", ex, ErrorCodes.HandErrorCode.Create("Pairs")));
	}
}
