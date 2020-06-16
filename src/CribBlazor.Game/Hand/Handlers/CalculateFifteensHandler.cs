using System;
using System.Collections.Generic;
using System.Text;
using Functional;
using CribBlazor.Shared.Cards;
using CribBlazor.Shared.Errors;
using System.Linq;
using CribBlazor.Shared.Errors.ErrorCodes;

namespace CribBlazor.Game.Hand.Handlers
{
	public class CalculateFifteensHandler
	{
		public Result<int, ApplicationError> Calculate(Card[] cards)
			=> from countOfFifteens in CountFifteens(cards)
			   select countOfFifteens * 2;

		private Result<int, ApplicationError> CountFifteens(Card[] cards)
			=> Result.Try(() =>
				Enumerable.Range(0, 1 << cards.Length)
					.Select(o => Enumerable.Range(0, cards.Length)
						.Where(p => (o & (1 << p)) != 0)
						.Select(q => cards[q]))
					.Where(s => s.Sum(r => r.Face.GetFaceValue()) == 15).Count())
			.MapOnFailure(ex => GameLogicError.Create($"Error counting 15s: {ex.Message}", ex, ErrorCodes.HandErrorCode.Create("15s")));
	}
}
