using CribBlazor.Shared;
using CribBlazor.Shared.Errors;
using CribBlazor.Shared.Errors.ErrorCodes;
using CribBlazor.Shared.TransportModels;
using Functional;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace CribBlazor.Client.Services.Handlers
{
	public class CreateNewGameHandler
	{
		private HttpClient HttpClient { get; }

		public CreateNewGameHandler(HttpClient httpClient)
			=> HttpClient = httpClient;

		public Task<Result<Guid, ApplicationError>> CreateNewGameAsync(CancellationToken cancellationToken)
			=> from results in CallEndpoint(cancellationToken)
			   select results.GameId;

		private Task<Result<NewGameResponse, ApplicationError>> CallEndpoint(CancellationToken cancellationToken)
			=> Result.TryAsync(async () =>
			{
				var response = await HttpClient.PostAsync("/api/gamesession", new StringContent(""), cancellationToken);
				var result = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<NewGameResponse>(result);
			})
			.MapOnFailure(ex => RestError.Create($"Error dealing with endpoint: {ex.Message}", ex, ErrorCodes.RestCommunicationErrorCode.Create(ApiEndpoints.GameState)));
	}
}
