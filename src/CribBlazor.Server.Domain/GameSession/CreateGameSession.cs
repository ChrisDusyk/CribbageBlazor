using CribBlazor.Shared.Errors;
using Functional;
using System.Threading;
using System.Threading.Tasks;
using GameSessionModel = CribBlazor.Server.Models.GameSession.GameSession;

namespace CribBlazor.Server.Domain.GameSession
{
	public delegate Task<Result<GameSessionModel, ApplicationError>> CreateGameSession(CancellationToken cancellationToken);
}
