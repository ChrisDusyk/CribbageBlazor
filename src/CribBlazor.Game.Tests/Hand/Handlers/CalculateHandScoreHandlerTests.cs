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
			// Generally I would isolate CalculateHandScoreHandler by mocking each of the sub counters, however that's not overly valuable right now IMO
			// This will test the entire handler with its actual sub-handlers to validate scoring
			var sut = new CalculateHandScoreHandler(
				new CalculateFifteensHandler().Calculate,
				new CalculateFlushHandler().Calculate,
				new CalculateNobsHandler().Calculate,
				new CalculatePairsHandler().CalculatePairs,
				new CalculateRunsHandler().Calculate);

			var result = sut.Calculate(hand, cutCard, isCrib);

			result.AssertSuccess();
			result.Success().ValueOrDefault().Should().Be(expectedPoints);
		}

		private class HandCombinations : IEnumerable<object[]>
		{
			public IEnumerator<object[]> GetEnumerator()
			{
				yield return new object[]
				{
					new Card[4]
					{
						Card.Create(Suits.Diamonds, Faces.Five),
						Card.Create(Suits.Spades, Faces.Queen),
						Card.Create(Suits.Clubs, Faces.Jack),
						Card.Create(Suits.Hearts, Faces.King)
					},
					Card.Create(Suits.Clubs, Faces.Ace),
					false,
					10
				};

				yield return new object[]
				{
					new Card[4]
					{
						Card.Create(Suits.Clubs, Faces.Eight),
						Card.Create(Suits.Diamonds, Faces.Ace),
						Card.Create(Suits.Clubs, Faces.Ten),
						Card.Create(Suits.Hearts, Faces.Six)
					},
					Card.Create(Suits.Spades, Faces.Seven),
					false,
					7
				};

				yield return new object[]
				{
					new Card[4]
					{
						Card.Create(Suits.Clubs, Faces.Ace),
						Card.Create(Suits.Diamonds, Faces.Six),
						Card.Create(Suits.Clubs, Faces.Five),
						Card.Create(Suits.Clubs, Faces.Ten)
					},
					Card.Create(Suits.Clubs, Faces.Eight),
					true,
					4
				};

				yield return new object[]
				{
					new Card[4]
					{
						Card.Create(Suits.Clubs, Faces.Two),
						Card.Create(Suits.Clubs, Faces.Three),
						Card.Create(Suits.Diamonds, Faces.Three),
						Card.Create(Suits.Diamonds, Faces.Four)
					},
					Card.Create(Suits.Spades, Faces.Three),
					false,
					17
				};

				yield return new object[]
				{
					new Card[4]
					{
						Card.Create(Suits.Clubs, Faces.Two),
						Card.Create(Suits.Clubs, Faces.Four),
						Card.Create(Suits.Clubs, Faces.Ten),
						Card.Create(Suits.Clubs, Faces.Eight)
					},
					Card.Create(Suits.Spades, Faces.Six),
					false,
					4
				};

				yield return new object[]
				{
					new Card[4]
					{
						Card.Create(Suits.Clubs, Faces.Two),
						Card.Create(Suits.Clubs, Faces.Four),
						Card.Create(Suits.Clubs, Faces.Ten),
						Card.Create(Suits.Clubs, Faces.Eight)
					},
					Card.Create(Suits.Clubs, Faces.Six),
					false,
					5
				};

				yield return new object[]
				{
					new Card[4]
					{
						Card.Create(Suits.Clubs, Faces.Two),
						Card.Create(Suits.Clubs, Faces.Four),
						Card.Create(Suits.Clubs, Faces.Ten),
						Card.Create(Suits.Clubs, Faces.Eight)
					},
					Card.Create(Suits.Spades, Faces.Six),
					true,
					0
				};

				yield return new object[]
				{
					new Card[4]
					{
						Card.Create(Suits.Clubs, Faces.Two),
						Card.Create(Suits.Clubs, Faces.Four),
						Card.Create(Suits.Clubs, Faces.Ten),
						Card.Create(Suits.Clubs, Faces.Eight)
					},
					Card.Create(Suits.Clubs, Faces.Six),
					true,
					5
				};

				yield return new object[]
				{
					new Card[4]
					{
						Card.Create(Suits.Diamonds, Faces.Six),
						Card.Create(Suits.Hearts, Faces.Jack),
						Card.Create(Suits.Hearts, Faces.Four),
						Card.Create(Suits.Spades, Faces.Seven)
					},
					Card.Create(Suits.Hearts, Faces.Five),
					false,
					9
				};

				yield return new object[]
				{
					new Card[4]
					{
						Card.Create(Suits.Clubs, Faces.Two),
						Card.Create(Suits.Hearts, Faces.Two),
						Card.Create(Suits.Spades, Faces.Three),
						Card.Create(Suits.Diamonds, Faces.Four)
					},
					Card.Create(Suits.Spades, Faces.Nine),
					false,
					12
				};

				// 29 - the biggest hand possible
				yield return new object[]
				{
					new Card[4]
					{
						Card.Create(Suits.Hearts, Faces.Five),
						Card.Create(Suits.Clubs, Faces.Five),
						Card.Create(Suits.Spades, Faces.Five),
						Card.Create(Suits.Diamonds, Faces.Jack)
					},
					Card.Create(Suits.Diamonds, Faces.Five),
					false,
					29
				};
			}

			IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		}
	}
}
