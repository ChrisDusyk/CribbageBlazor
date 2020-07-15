using System;
using System.Collections.Generic;
using System.Text;

namespace CribBlazor.Shared.Errors
{
	public abstract class ApplicationError : Exception
	{
		public abstract string ErrorType { get; }

		public abstract IEnumerable<ErrorCode> ErrorCodes { get; }

		protected ApplicationError(string message, Exception innerException) : base(message, innerException) { }

		public abstract T Match<T>(
			Func<GameLogicError, T> gameLogicError,
			Func<RestError, T> restError);
	}
}
