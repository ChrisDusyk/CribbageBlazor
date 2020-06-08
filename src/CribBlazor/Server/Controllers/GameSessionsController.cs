using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CribBlazor.Shared;
using CribBlazor.Server.Domain.GameSession;
using System.Threading;
using Functional;
using CribBlazor.Server.Extensions;

namespace CribBlazor.Server.Controllers
{
	[Route(ApiEndpoints.GameSessions)]
	[ApiController]
	public class GameSessionsController : ControllerBase
	{
		private CreateGameSession CreateGameSession { get; }

		public GameSessionsController(CreateGameSession createGameSession)
			=> CreateGameSession = createGameSession;

		public async Task<ActionResult> CreateGameSessionAsync(CancellationToken cancellationToken)
			=> (await CreateGameSession(cancellationToken))
				.Match(
					success => (ActionResult)Ok(success.ToOutputModel()),
					failure => BadRequest(failure));
	}
}
