using CribBlazor.Game.Hand;
using CribBlazor.Game.Hand.Handlers;
using CribBlazor.Shared.Cards;
using CribBlazor.Tests;
using FluentAssertions;
using Functional;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace CribBlazor.Game.Tests.Hand.Handlers
{
	public class CalculateHandScoreHandlerTests
	{
		[Theory]
		[ClassData(typeof(HandCombinations))]
		public void Handler_WhenAllTypesOfScoringSucceed_CalculatesTheCorrectScore(Card[] hand, Card cutCard, bool isCrib, int expectedPoints)
		{
			// TODO
		}

		private class HandCombinations : IEnumerable<object[]>
		{
			public IEnumerator<object[]> GetEnumerator()
			{
				yield return new object[]
				{
					new Card[4]
					{
						Card.Create(Suits.Clubs, Faces.Five),
						Card.Create(Suits.Clubs, Faces.Queen),
						Card.Create(Suits.Clubs, Faces.Jack),
						Card.Create(Suits.Clubs, Faces.King)
					},
					Card.Create(Suits.Hearts, Faces.Ten),
					false,
					4
				};

				yield return new object[]
				{
					new Card[4]
					{
						Card.Create(Suits.Clubs, Faces.Five),
						Card.Create(Suits.Clubs, Faces.Queen),
						Card.Create(Suits.Clubs, Faces.Jack),
						Card.Create(Suits.Clubs, Faces.King)
					},
					Card.Create(Suits.Clubs, Faces.Ten),
					false,
					5
				};

				// Crib must use all 5 cards to score a flush
				yield return new object[]
				{
					new Card[4]
					{
						Card.Create(Suits.Clubs, Faces.Five),
						Card.Create(Suits.Clubs, Faces.Queen),
						Card.Create(Suits.Clubs, Faces.Jack),
						Card.Create(Suits.Clubs, Faces.King)
					},
					Card.Create(Suits.Hearts, Faces.Ten),
					true,
					0
				};

				yield return new object[]
				{
					new Card[4]
					{
						Card.Create(Suits.Clubs, Faces.Five),
						Card.Create(Suits.Clubs, Faces.Queen),
						Card.Create(Suits.Clubs, Faces.Jack),
						Card.Create(Suits.Clubs, Faces.King)
					},
					Card.Create(Suits.Clubs, Faces.Ten),
					true,
					5
				};

				yield return new object[]
				{
					new Card[4]
					{
						Card.Create(Suits.Hearts, Faces.Five),
						Card.Create(Suits.Clubs, Faces.Queen),
						Card.Create(Suits.Clubs, Faces.Jack),
						Card.Create(Suits.Clubs, Faces.King)
					},
					Card.Create(Suits.Hearts, Faces.Ten),
					false,
					0
				};
			}

			IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		}
	}
}
