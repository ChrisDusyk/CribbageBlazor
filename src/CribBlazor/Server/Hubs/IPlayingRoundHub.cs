using System.Threading.Tasks;

namespace CribBlazor.Server.Hubs
{
	public interface IPlayingRoundHub
	{
		Task CardPlayed(string playerId, string card);
	}
}
