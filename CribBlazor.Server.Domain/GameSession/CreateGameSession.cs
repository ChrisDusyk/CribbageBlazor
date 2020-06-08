using CribBlazor.Shared.Errors;
using Functional;
using GameSessionModel = CribBlazor.Server.Models.GameSession.GameSession;

namespace CribBlazor.Server.Domain.GameSession
{
	public delegate Result<GameSessionModel, GameLogicError> CreateGameSession();
}
