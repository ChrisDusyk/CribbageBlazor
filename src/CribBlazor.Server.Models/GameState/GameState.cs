using System;

namespace CribBlazor.Server.Models.GameState
{
	public class GameState
	{
		private GameState(Guid id)
		{
			Id = id;
		}

		public Guid Id { get; }

		public static GameState Create(Guid id) => new GameState(id);
	}
}
