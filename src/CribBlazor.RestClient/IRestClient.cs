using CribBlazor.Shared.Errors;
using Functional;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CribBlazor.RestClient
{
	public interface IRestClient
	{
		Task<Result<TSuccess, ApplicationError>> GetFromJsonAsync<TSuccess>(string uri, CancellationToken cancellationToken);

		Task<Result<TSuccess, ApplicationError>> PostJsonAsync<TBody, TSuccess>(string uri, TBody body, CancellationToken cancellationToken);
	}
}
