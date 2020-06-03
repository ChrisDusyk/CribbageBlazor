using CribBlazor.Shared.Cards;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace CribBlazor.Server.Hubs
{
	public class CardHub : Hub<ICardHub>
	{
		public async Task SendCard(string player, string card)
		{
			await Clients.All.ReceiveCard(player, card);
		}
	}
}
