using CribBlazor.Game.Hand.Handlers;
using CribBlazor.Shared.Cards;
using CribBlazor.Tests;
using FluentAssertions;
using Functional;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CribBlazor.Game.Tests.Hand.Handlers
{
	public class CalculateRunsHandlerTests
	{
		[Theory]
		[ClassData(typeof(HandCombinations))]
		public void Handler_WhenCalledWithHand_CalculatesPointsFromRuns(Card[] cards, int expectedPoints)
		{
			var sut = new CalculateRunsHandler();
			var result = sut.Calculate(cards);

			result.AssertSuccess();
			result.Success().ValueOrDefault().Should().Be(expectedPoints);
		}

		private class HandCombinations : IEnumerable<object[]>
		{
			public IEnumerator<object[]> GetEnumerator()
			{
				// Single run of 3
				yield return new object[]
				{
					new Card[5]
					{
						Card.Create(Suits.Diamonds, Faces.Five),
						Card.Create(Suits.Spades, Faces.Queen),
						Card.Create(Suits.Clubs, Faces.Jack),
						Card.Create(Suits.Hearts, Faces.King),
						Card.Create(Suits.Clubs, Faces.Ace)
					},
					3
				};

				// Single run of 4
				yield return new object[]
				{
					new Card[5]
					{
						Card.Create(Suits.Diamonds, Faces.Ace),
						Card.Create(Suits.Spades, Faces.Two),
						Card.Create(Suits.Clubs, Faces.Three),
						Card.Create(Suits.Hearts, Faces.Four),
						Card.Create(Suits.Hearts, Faces.Ten)
					},
					4
				};

				// Single run of 5
				yield return new object[]
				{
					new Card[5]
					{
						Card.Create(Suits.Diamonds, Faces.Ace),
						Card.Create(Suits.Spades, Faces.Two),
						Card.Create(Suits.Clubs, Faces.Three),
						Card.Create(Suits.Hearts, Faces.Four),
						Card.Create(Suits.Hearts, Faces.Five)
					},
					5
				};

				// Double run of 3
				yield return new object[]
				{
					new Card[5]
					{
						Card.Create(Suits.Diamonds, Faces.Ace),
						Card.Create(Suits.Clubs, Faces.Ace),
						Card.Create(Suits.Clubs, Faces.Two),
						Card.Create(Suits.Diamonds, Faces.Three),
						Card.Create(Suits.Diamonds, Faces.Ten)
					},
					6
				};

				// Double run of 4
				yield return new object[]
				{
					new Card[5]
					{
						Card.Create(Suits.Diamonds, Faces.Ace),
						Card.Create(Suits.Spades, Faces.Two),
						Card.Create(Suits.Clubs, Faces.Three),
						Card.Create(Suits.Hearts, Faces.Four),
						Card.Create(Suits.Hearts, Faces.Ace)
					},
					8
				};

				// Triple run of 3
				yield return new object[]
				{
					new Card[5]
					{
						Card.Create(Suits.Diamonds, Faces.Ten),
						Card.Create(Suits.Spades, Faces.Ten),
						Card.Create(Suits.Clubs, Faces.Ten),
						Card.Create(Suits.Hearts, Faces.Jack),
						Card.Create(Suits.Hearts, Faces.Queen)
					},
					9
				};

				// Double-Double run of 3
				yield return new object[]
				{
					new Card[5]
					{
						Card.Create(Suits.Diamonds, Faces.Four),
						Card.Create(Suits.Spades, Faces.Four),
						Card.Create(Suits.Clubs, Faces.Five),
						Card.Create(Suits.Hearts, Faces.Five),
						Card.Create(Suits.Hearts, Faces.Six)
					},
					12
				};
			}

			IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		}
	}
}
