using CribBlazor.Shared.Cards;
using System.Threading.Tasks;

namespace CribBlazor.Server.Hubs
{
	public interface ICardHub
	{
		Task ReceiveCard(string player, string card);
	}
}
