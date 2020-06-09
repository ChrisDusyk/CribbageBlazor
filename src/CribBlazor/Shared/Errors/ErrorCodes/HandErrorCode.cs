namespace CribBlazor.Shared.Errors.ErrorCodes
{
	public abstract partial class ErrorCodes
	{
		public class HandErrorCode : ErrorCode
		{
			private HandErrorCode(string message) : base("Hand")
				=> Message = message;

			protected string Message { get; }
			public override object Information => new { Message };

			public static ErrorCode Create(string message) => new HandErrorCode(message);
		}
	}
}
