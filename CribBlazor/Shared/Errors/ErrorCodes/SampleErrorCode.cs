namespace CribBlazor.Shared.Errors.ErrorCodes
{
	public abstract partial class ErrorCodes
	{
		public class SampleErrorCode : ErrorCode
		{
			private SampleErrorCode(string message) : base("Sample")
			{
				Message = message;
			}

			protected string Message { get; }

			public override object Information => new { Message };

			public static SampleErrorCode Create(string message) => new SampleErrorCode(message);
		}
	}
}
