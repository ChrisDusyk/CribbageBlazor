using CribBlazor.Shared.Cards;
using CribBlazor.Shared.Errors;
using Functional;

namespace CribBlazor.Game.Hand
{
	public delegate Result<int, ApplicationError> CalculateNobs(Card[] hand, Card cutCard);
}
