namespace CribBlazor.Shared.Errors.ErrorCodes
{
	public abstract partial class ErrorCodes
	{
		public class RestCommunicationErrorCode : ErrorCode
		{
			private RestCommunicationErrorCode(string endpoint) : base("RestCommunication")
				=> Endpoint = endpoint;

			protected string Endpoint { get; }

			public override object Information => new { Endpoint };

			public static ErrorCode Create(string endpoint) => new RestCommunicationErrorCode(endpoint);
		}
	}
}
