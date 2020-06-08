using CribBlazor.Shared.Errors;
using Functional;
using System;
using System.Threading;
using System.Threading.Tasks;
using GameSessionModel = CribBlazor.Server.Models.GameState.GameState;

namespace CribBlazor.Server.Persistence.GameState
{
	public class CreateNewGameHandler
	{
		public Task<Result<GameSessionModel, ApplicationError>> CreateMockedSession(CancellationToken cancellationToken)
			=> Task.FromResult(Result.Success<GameSessionModel, ApplicationError>(GameSessionModel.Create(Guid.NewGuid())));
	}
}
