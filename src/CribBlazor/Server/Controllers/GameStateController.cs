using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CribBlazor.Shared;
using CribBlazor.Server.Domain.GameState;
using System.Threading;
using Functional;
using CribBlazor.Server.Extensions;

namespace CribBlazor.Server.Controllers
{
	[Route(ApiEndpoints.GameState)]
	[ApiController]
	public class GameStateController : ControllerBase
	{
		private CreateNewGame CreateNewGame { get; }

		public GameStateController(CreateNewGame createNewGame)
			=> CreateNewGame = createNewGame;

		public async Task<ActionResult> CreateNewGameAsync(CancellationToken cancellationToken)
			=> (await CreateNewGame(cancellationToken))
				.Match(
					success => (ActionResult)Ok(success.ToOutputModel()),
					failure => BadRequest(failure));
	}
}
