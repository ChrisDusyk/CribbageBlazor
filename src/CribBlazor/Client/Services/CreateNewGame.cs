using CribBlazor.Shared.Errors;
using Functional;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CribBlazor.Client.Services
{
	public delegate Task<Result<Guid, ApplicationError>> CreateNewGame(CancellationToken cancellationToken);
}
