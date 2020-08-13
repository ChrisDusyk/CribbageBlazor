using CribBlazor.Shared.Errors;
using Functional;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Net.Http;
using System.Threading;
using CribBlazor.Shared.Errors.ErrorCodes;
using Newtonsoft.Json;

namespace CribBlazor.RestClient
{
	internal class RestClient : IRestClient
	{
		private HttpClient Client { get; }

		public RestClient(HttpClient httpClient)
			=> Client = httpClient;

		public Task<Result<TSuccess, ApplicationError>> GetFromJsonAsync<TSuccess>(string uri)
			=> Result.TryAsync(() =>
			{
				using (var source = new CancellationTokenSource())
					return Client.GetFromJsonAsync<TSuccess>(uri, source.Token);
			})
			.MapOnFailure(ex => RestError.Create(ex.Message, ex, ErrorCodes.RestCommunicationErrorCode.Create(uri)));

		public Task<Result<TSuccess, ApplicationError>> PostJsonAsync<TBody, TSuccess>(string uri, TBody body)
			=> Result.TryAsync(async () =>
			{
				using (var source = new CancellationTokenSource())
				{
					var response = await Client.PostAsJsonAsync(uri, body, source.Token);
					var responseBody = await response.Content.ReadAsStringAsync();
					return JsonConvert.DeserializeObject<TSuccess>(responseBody);
				}
			})
			.MapOnFailure(ex => RestError.Create(ex.Message, ex, ErrorCodes.RestCommunicationErrorCode.Create(uri)));
	}
}
