using System;

namespace CribBlazor.Shared.Cards
{
	public static class EnumHelper
	{
		public static T[] EnumerateEnum<T>()
			=> (T[])Enum.GetValues(typeof(T));
	}
}
