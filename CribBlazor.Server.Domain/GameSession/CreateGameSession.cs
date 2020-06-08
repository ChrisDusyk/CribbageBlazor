using CribBlazor.Shared.Errors;
using Functional;
using System;
using System.Collections.Generic;
using System.Text;

namespace CribBlazor.Server.Domain.GameSession
{
	public delegate Result<object, GameLogicError> CreateGameSession();
}
