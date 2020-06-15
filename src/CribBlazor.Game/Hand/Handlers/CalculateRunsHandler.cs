using CribBlazor.Shared.Cards;
using CribBlazor.Shared.Errors;
using CribBlazor.Shared.Errors.ErrorCodes;
using Functional;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CribBlazor.Game.Hand.Handlers
{
	public class CalculateRunsHandler
	{
		public Result<int, ApplicationError> Calculate(Card[] cards)
			=> from pointsTuple in GetMaxRunAndMultiplier(cards)
			   select pointsTuple.MaxLength * pointsTuple.Multiplier;

		private Result<(int MaxLength, int Multiplier), ApplicationError> GetMaxRunAndMultiplier(Card[] cards)
			=> Result.Try(() =>
			{
				int chain = 1;
				int best = 1;
				int multiplier = 1;

				for (int i = 1; i < cards.Length; ++i)
				{
					if ((int)cards[i - 1].Face == (int)cards[i].Face - 1)
					{
						chain++;
						if (chain > best) best = chain;
					}
					else if (cards[i - 1].Face == cards[i].Face)
					{
						if (i >= 2 && cards[i - 2].Face == cards[i].Face)
						{
							multiplier++;
						}
						else
						{
							multiplier *= 2;
						}
					}
					else
					{
						chain = 1;
					}
				}

				return (best > 2 ? best : 0, multiplier);
			})
			.MapOnFailure(ex => GameLogicError.Create($"Error calculating max run length: {ex.Message}", ex, ErrorCodes.HandErrorCode.Create("Runs")));


	}
}
