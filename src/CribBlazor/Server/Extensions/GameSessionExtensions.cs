namespace CribBlazor.Server.Extensions
{
	internal static class GameSessionExtensions
	{
		public static Shared.GameSession.GameSession ToOutputModel(this Models.GameSession.GameSession gameSession)
			=> Shared.GameSession.GameSession.Create(gameSession.Id);

		public static Models.GameSession.GameSession ToInternalModel(this Shared.GameSession.GameSession gameSession)
			=> Models.GameSession.GameSession.Create(gameSession.Id);
	}
}
