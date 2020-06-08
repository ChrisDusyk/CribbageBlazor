using CribBlazor.Shared.Errors;
using Functional;
using System.Threading.Tasks;

namespace CribBlazor.Tests
{
	public static class ObjectExtensions
	{
		public static Task<Result<T, ApplicationError>> AsSuccessTaskResult<T>(this T obj)
			=> Task.FromResult(Result.Success<T, ApplicationError>(obj));

		public static Task<Result<T, ApplicationError>> AsFailureTaskResult<T>(this ApplicationError applicationError)
			=> Task.FromResult(Result.Failure<T, ApplicationError>(applicationError));
	}
}
