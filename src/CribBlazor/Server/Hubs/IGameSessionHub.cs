using System.Threading.Tasks;

namespace CribBlazor.Server.Hubs
{
	public interface IGameSessionHub
	{
		Task CardPlayed(string playerId, string card);

		Task PlayerJoinedGame(string player);
	}
}
