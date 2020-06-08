using CribBlazor.Shared.Errors;
using Functional;
using System.Threading;
using System.Threading.Tasks;
using GameSessionModel = CribBlazor.Server.Models.GameState.GameState;

namespace CribBlazor.Server.Domain.GameState
{
	public delegate Task<Result<GameSessionModel, ApplicationError>> CreateNewGame(CancellationToken cancellationToken);
}
