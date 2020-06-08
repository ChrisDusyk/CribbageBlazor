namespace CribBlazor.Shared.Errors.ErrorCodes
{
	public abstract partial class ErrorCodes
	{
		public class DeckErrorCode : ErrorCode
		{
			private DeckErrorCode(string message) : base("Deck")
				=> Message = message;

			protected string Message { get; }
			public override object Information => new { Message };

			public static DeckErrorCode Create(string message) => new DeckErrorCode(message);
		}
	}
}
