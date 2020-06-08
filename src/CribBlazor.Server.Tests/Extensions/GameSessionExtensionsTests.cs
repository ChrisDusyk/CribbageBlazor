using CribBlazor.Server.Extensions;
using FluentAssertions;
using System;
using Xunit;

namespace CribBlazor.Server.Tests.Extensions
{
	public class GameSessionExtensionsTests
	{
		[Fact]
		public void Models_HaveCorrectProperties()
		{
			typeof(Shared.GameSession.GameSession).GetProperties().Length.Should().Be(1);
			typeof(Models.GameSession.GameSession).GetProperties().Length.Should().Be(1);
		}

		[Fact]
		public void InternalModel_MapsSuccessfully_ToOutputModel()
		{
			var sut = Models.GameSession.GameSession.Create(Guid.NewGuid());
			var result = sut.ToOutputModel();

			result.Id.Should().Be(sut.Id);
		}

		[Fact]
		public void OutputModel_MapsSuccessfully_ToInternalModel()
		{
			var sut = Shared.GameSession.GameSession.Create(Guid.NewGuid());
			var result = sut.ToInternalModel();

			result.Id.Should().Be(sut.Id);
		}
	}
}
