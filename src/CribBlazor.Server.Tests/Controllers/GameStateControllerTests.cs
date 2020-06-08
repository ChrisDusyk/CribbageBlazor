using CribBlazor.Server.Controllers;
using CribBlazor.Server.Domain.GameState;
using CribBlazor.Server.Models.GameState;
using CribBlazor.Tests;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CribBlazor.Server.Tests.Controllers
{
	public class GameStateControllerTests
	{
		[Fact]
		public async Task CreateGameSession_ReturnsNewGameSession()
		{
			var id = Guid.NewGuid();
			var sut = new GameStateController(Helpers.CreateDelegate<CreateNewGame>(GameState.Create(id).AsSuccessTaskResult()));

			var result = (OkObjectResult)await sut.CreateNewGameAsync(CancellationToken.None);

			result.StatusCode.Should().Be(200);

			var responseObject = result.Value as Shared.GameState.GameState;
			responseObject.Id.Should().Be(id);
		}
	}
}
