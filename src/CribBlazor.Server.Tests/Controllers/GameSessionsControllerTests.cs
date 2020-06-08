using CribBlazor.Server.Controllers;
using CribBlazor.Server.Domain.GameSession;
using CribBlazor.Server.Models.GameSession;
using CribBlazor.Tests;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CribBlazor.Server.Tests.Controllers
{
	public class GameSessionsControllerTests
	{
		[Fact]
		public async Task CreateGameSession_ReturnsNewGameSession()
		{
			var id = Guid.NewGuid();
			var sut = new GameSessionsController(Helpers.CreateDelegate<CreateGameSession>(GameSession.Create(id).AsSuccessTaskResult()));

			var result = (OkObjectResult)await sut.CreateGameSessionAsync(CancellationToken.None);

			result.StatusCode.Should().Be(200);

			var responseObject = result.Value as Shared.GameSession.GameSession;
			responseObject.Id.Should().Be(id);
		}
	}
}
