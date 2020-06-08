using System;
using System.Collections.Generic;
using System.Linq;

namespace CribBlazor.Shared.Errors
{
	public class GameLogicError : ApplicationError
	{
		private GameLogicError(string message, IEnumerable<ErrorCode> errorCodes, Exception innerException) : base(message, innerException)
			=> ErrorCodes = errorCodes ?? Enumerable.Empty<ErrorCode>();

		public override T Match<T>(Func<GameLogicError, T> gameLogicError)
			=> gameLogicError(this);

		public override string ErrorType { get; } = "GameLogic";

		public override IEnumerable<ErrorCode> ErrorCodes { get; }

		public static ApplicationError Create(string message, Exception innerException, params ErrorCode[] errorCodes)
			=> new GameLogicError(message, errorCodes, innerException);

		public static ApplicationError Create(string message, params ErrorCode[] errorCodes)
			=> new GameLogicError(message, errorCodes, null);
	}
}
