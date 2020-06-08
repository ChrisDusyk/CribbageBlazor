using Functional;
using System;
using System.Threading.Tasks;

namespace CribBlazor.Tests
{
	public static class OptionExtensions
	{
		public static TValue AssertSome<TValue>(this Option<TValue> value)
			=> value.Match(_ => _, () => throw new Exception("Expected Some but found None."));

		public static async Task<TValue> AssertSome<TValue>(this Task<Option<TValue>> value)
			=> (await value).Match(_ => _, () => throw new Exception("Expected Some but found None."));

		public static void AssertNone<TValue>(this Option<TValue> value)
			=> value.Match(_ => throw new Exception("Expected None but found Some."), () => 0);
	}
}
