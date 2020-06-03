using Functional;
using System;
using System.Threading.Tasks;

namespace CribBlazor.Game.Tests
{
	public static class ResultExtensions
	{
		public static TSuccess AssertSuccess<TSuccess, TFailure>(this Result<TSuccess, TFailure> result)
			=> result.Match(_ => _, failure => throw (failure as Exception ?? new Exception(failure.ToString())));

		public static async Task<TSuccess> AssertSuccess<TSuccess, TFailure>(this Task<Result<TSuccess, TFailure>> result)
			=> (await result).Match(_ => _, failure => throw (failure as Exception ?? new Exception(failure.ToString())));

		public static TFailure AssertFailure<TSuccess, TFailure>(this Result<TSuccess, TFailure> result)
			=> result.Match(_ => throw new Exception("Expected failure but found success."), _ => _);

		public static async Task<TFailure> AssertFailure<TSuccess, TFailure>(this Task<Result<TSuccess, TFailure>> result)
			=> (await result).Match(_ => throw new Exception("Expected failure but found success."), _ => _);
	}
}
