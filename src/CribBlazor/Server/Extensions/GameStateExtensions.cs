namespace CribBlazor.Server.Extensions
{
	internal static class GameStateExtensions
	{
		public static Shared.GameState.GameState ToOutputModel(this Models.GameState.GameState gameSession)
			=> Shared.GameState.GameState.Create(gameSession.Id);

		public static Models.GameState.GameState ToInternalModel(this Shared.GameState.GameState gameSession)
			=> Models.GameState.GameState.Create(gameSession.Id);
	}
}
