﻿using System;

namespace CribBlazor.Server.Models.GameSession
{
	public class GameSession
	{
		private GameSession(Guid id)
		{
			Id = id;
		}

		public Guid Id { get; }

		public static GameSession Create(Guid id) => new GameSession(id);
	}
}
