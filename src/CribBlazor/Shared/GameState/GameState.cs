using System;

namespace CribBlazor.Shared.GameState
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
