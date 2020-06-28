using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CribBlazor.Server.Hubs
{
	public class PlayingRoundHub : Hub<IPlayingRoundHub>
	{
		public async Task PlayCard(string playerId, string gameId, string card)
		{
			await Clients.Group(gameId).CardPlayed(playerId, card);
		}
	}
}
