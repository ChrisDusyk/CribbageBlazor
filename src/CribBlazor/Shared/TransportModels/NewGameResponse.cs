using System;

namespace CribBlazor.Shared.TransportModels
{
	public class NewGameResponse
	{
		public Guid GameId { get; }

		public NewGameResponse(Guid gameId)
		{
			GameId = gameId;
		}
	}
}
