using System;
using System.Collections.Generic;
using System.Linq;

namespace CribBlazor.Shared.Errors
{
	public class RestError : ApplicationError
	{
		private RestError(string message, IEnumerable<ErrorCode> errorCodes, Exception innerException) : base(message, innerException)
			=> ErrorCodes = errorCodes ?? Enumerable.Empty<ErrorCode>();

		public override T Match<T>(
			Func<GameLogicError, T> gameLogicError,
			Func<RestError, T> restError)
			=> restError(this);

		public override string ErrorType => "Rest";

		public override IEnumerable<ErrorCode> ErrorCodes { get; }

		public static ApplicationError Create(string message, Exception innerException, params ErrorCode[] errorCodes)
			=> new RestError(message, errorCodes, innerException);

		public static ApplicationError Create(string message, params ErrorCode[] errorCodes)
			=> new RestError(message, errorCodes, null);
	}
}
