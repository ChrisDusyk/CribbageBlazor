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
	public class CalculateFifteensHandlerTests
	{
		[Theory]
		[ClassData(typeof(HandCombinations))]
		public void Handler_WhenCalled_CalculatesPointsFromFifteens(Card[] cards, int expectedPoints)
		{
			var sut = new CalculateFifteensHandler();

			var result = sut.Calculate(cards);

			result.AssertSuccess();
			result.Success().ValueOrDefault().Should().Be(expectedPoints);
		}

		private class HandCombinations : IEnumerable<object[]>
		{
			public IEnumerator<object[]> GetEnumerator()
			{
				yield return new object[]
				{
					new Card[5]
					{
						Card.Create(Suits.Diamonds, Faces.Five),
						Card.Create(Suits.Spades, Faces.Queen),
						Card.Create(Suits.Clubs, Faces.Jack),
						Card.Create(Suits.Hearts, Faces.King),
						Card.Create(Suits.Hearts, Faces.Ten)
					},
					8
				};

				yield return new object[]
				{
					new Card[5]
					{
						Card.Create(Suits.Diamonds, Faces.Five),
						Card.Create(Suits.Spades, Faces.Five),
						Card.Create(Suits.Clubs, Faces.Ten),
						Card.Create(Suits.Hearts, Faces.Jack),
						Card.Create(Suits.Hearts, Faces.Ten)
					},
					12
				};

				yield return new object[]
				{
					new Card[5]
					{
						Card.Create(Suits.Diamonds, Faces.Five),
						Card.Create(Suits.Spades, Faces.Five),
						Card.Create(Suits.Clubs, Faces.Five),
						Card.Create(Suits.Hearts, Faces.Ten),
						Card.Create(Suits.Hearts, Faces.Jack)
					},
					14
				};
			}

			IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		}
	}
}
