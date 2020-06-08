using CribBlazor.Shared.Errors;
using Functional;
using System;
using System.Threading;
using System.Threading.Tasks;
using GameSessionModel = CribBlazor.Server.Models.GameSession.GameSession;

namespace CribBlazor.Server.Persistence.GameSession
{
	public class CreateGameSessionHandler
	{
		public Task<Result<GameSessionModel, ApplicationError>> CreateMockedSession(CancellationToken cancellationToken)
			=> Task.FromResult(Result.Success<GameSessionModel, ApplicationError>(GameSessionModel.Create(Guid.NewGuid())));
	}
}
