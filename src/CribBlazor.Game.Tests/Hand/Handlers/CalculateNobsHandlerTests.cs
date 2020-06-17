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
	public class CalculateNobsHandlerTests
	{
		[Theory]
		[ClassData(typeof(HandCombinations))]
		public void Handler_WhenCalled_ShouldCalculateNobsPoints(Card[] hand, Card cutCard, int expectedPoints)
		{
			var sut = new CalculateNobsHandler();

			var results = sut.Calculate(hand, cutCard);

			results.AssertSuccess();
			results.Success().ValueOrDefault().Should().Be(expectedPoints);
		}

		private class HandCombinations : IEnumerable<object[]>
		{
			public IEnumerator<object[]> GetEnumerator()
			{
				// Nobs
				yield return new object[]
				{
					new Card[4]
					{
						Card.Create(Suits.Diamonds, Faces.Five),
						Card.Create(Suits.Spades, Faces.Five),
						Card.Create(Suits.Clubs, Faces.Jack),
						Card.Create(Suits.Hearts, Faces.King),
					},
					Card.Create(Suits.Clubs, Faces.Ten),
					1
				};

				// Jack but no Nobs
				yield return new object[]
				{
					new Card[4]
					{
						Card.Create(Suits.Diamonds, Faces.Five),
						Card.Create(Suits.Spades, Faces.Five),
						Card.Create(Suits.Clubs, Faces.Jack),
						Card.Create(Suits.Hearts, Faces.King),
					},
					Card.Create(Suits.Hearts, Faces.Ten),
					0
				};

				// No Jack at all
				yield return new object[]
				{
					new Card[4]
					{
						Card.Create(Suits.Diamonds, Faces.Five),
						Card.Create(Suits.Spades, Faces.Five),
						Card.Create(Suits.Clubs, Faces.Ace),
						Card.Create(Suits.Hearts, Faces.King),
					},
					Card.Create(Suits.Hearts, Faces.Ten),
					0
				};
			}

			IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		}
	}
}
