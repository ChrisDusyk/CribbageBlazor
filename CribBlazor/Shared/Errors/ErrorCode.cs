namespace CribBlazor.Shared.Errors
{
	public abstract class ErrorCode
	{
		protected ErrorCode(string type)
			=> Type = type;

		public string Type { get; }

		public abstract object Information { get; }
	}
}
