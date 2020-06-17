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
	public class CalculatePairsHandlerTests
	{
		[Theory]
		[ClassData(typeof(HandCombinations))]
		public void Handler_WhenCalled_ShouldCalculatePairsPoints(Card[] cards, int expectedPoints)
		{
			var sut = new CalculatePairsHandler();

			var results = sut.CalculatePairs(cards);

			results.AssertSuccess();
			results.Success().ValueOrDefault().Should().Be(expectedPoints);
		}

		private class HandCombinations : IEnumerable<object[]>
		{
			public IEnumerator<object[]> GetEnumerator()
			{
				// pair
				yield return new object[]
				{
					new Card[5]
					{
						Card.Create(Suits.Diamonds, Faces.Five),
						Card.Create(Suits.Spades, Faces.Five),
						Card.Create(Suits.Clubs, Faces.Jack),
						Card.Create(Suits.Hearts, Faces.King),
						Card.Create(Suits.Hearts, Faces.Ten)
					},
					2
				};

				// triple
				yield return new object[]
				{
					new Card[5]
					{
						Card.Create(Suits.Diamonds, Faces.Five),
						Card.Create(Suits.Spades, Faces.Five),
						Card.Create(Suits.Clubs, Faces.Five),
						Card.Create(Suits.Hearts, Faces.Jack),
						Card.Create(Suits.Hearts, Faces.Ten)
					},
					6
				};

				// triple and double
				yield return new object[]
				{
					new Card[5]
					{
						Card.Create(Suits.Diamonds, Faces.Five),
						Card.Create(Suits.Spades, Faces.Five),
						Card.Create(Suits.Clubs, Faces.Five),
						Card.Create(Suits.Hearts, Faces.Eight),
						Card.Create(Suits.Spades, Faces.Eight)
					},
					8
				};

				// quadruple
				yield return new object[]
				{
					new Card[5]
					{
						Card.Create(Suits.Diamonds, Faces.Five),
						Card.Create(Suits.Spades, Faces.Five),
						Card.Create(Suits.Clubs, Faces.Five),
						Card.Create(Suits.Hearts, Faces.Five),
						Card.Create(Suits.Spades, Faces.Eight)
					},
					12
				};
			}

			IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		}
	}
}
