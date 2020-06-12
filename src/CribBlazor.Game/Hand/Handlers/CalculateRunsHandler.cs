using CribBlazor.Shared.Cards;
using CribBlazor.Shared.Errors;
using CribBlazor.Shared.Errors.ErrorCodes;
using Functional;
using System;
using System.Collections.Generic;
using System.Text;

namespace CribBlazor.Game.Hand.Handlers
{
	public class CalculateRunsHandler
	{
		public Result<int, ApplicationError> Calculate(Card[] cards)
			;

		private Result<int, ApplicationError> GetMaxRunLength(Card[] cards)
			=> Result.Try(() =>
			{
				int lastCardValue = -1;
				int runCount = 0;
				int maxRunCount = 0;

				for (var i = 0; i < cards.Length; ++i)
				{
					var card = cards[i];
					if ((int)card.Face == lastCardValue + 1)
					{
						runCount += 1;
					}
					else if ((int)card.Face == lastCardValue)
					{
						break;
					}
					else
					{
						runCount = 1;
					}

					maxRunCount = Math.Max(maxRunCount, runCount);
					lastCardValue = (int)card.Face;
				}


				return maxRunCount;
			})
			.MapOnFailure(ex => GameLogicError.Create($"Error calculating max run length: {ex.Message}", ex, ErrorCodes.HandErrorCode.Create("Runs")));


	}
}
