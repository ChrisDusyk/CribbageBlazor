namespace CribBlazor.Shared.Cards
{
	public static class FacesExtensions
	{
		public static int GetFaceValue(this Faces face)
		{
			switch (face)
			{
				case Faces.Ace:
					return 1;
				case Faces.Jack:
				case Faces.Queen:
				case Faces.King:
					return 10;
				default:
					return (int)face;
			}
		}
	}
}
