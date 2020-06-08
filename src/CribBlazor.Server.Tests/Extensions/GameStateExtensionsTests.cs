using CribBlazor.Server.Extensions;
using FluentAssertions;
using System;
using Xunit;

namespace CribBlazor.Server.Tests.Extensions
{
	public class GameStateExtensionsTests
	{
		[Fact]
		public void Models_HaveCorrectProperties()
		{
			typeof(Shared.GameState.GameState).GetProperties().Length.Should().Be(1);
			typeof(Models.GameState.GameState).GetProperties().Length.Should().Be(1);
		}

		[Fact]
		public void InternalModel_MapsSuccessfully_ToOutputModel()
		{
			var sut = Models.GameState.GameState.Create(Guid.NewGuid());
			var result = sut.ToOutputModel();

			result.Id.Should().Be(sut.Id);
		}

		[Fact]
		public void OutputModel_MapsSuccessfully_ToInternalModel()
		{
			var sut = Shared.GameState.GameState.Create(Guid.NewGuid());
			var result = sut.ToInternalModel();

			result.Id.Should().Be(sut.Id);
		}
	}
}
