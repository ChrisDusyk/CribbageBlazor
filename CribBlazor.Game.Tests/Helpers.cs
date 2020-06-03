using FakeItEasy;
using System;

namespace CribBlazor.Game.Tests
{
	internal static class Helpers
	{
		public static T CreateUncalledDelegate<T>() where T : class
			=> CreateDelegate<T>(() => throw new Exception($"Delegate {typeof(T).Name} was called, but should not have"));

		public static T CreateDelegate<T>(object invokeResult) where T : class
			=> CreateDelegate<T>(() => invokeResult);

		public static T CreateDelegate<T>(Func<object> invokeResult) where T : class
		{
			if (!typeof(T).IsSubclassOf(typeof(Delegate)))
				throw new InvalidOperationException($"{typeof(T)} is not a delegate type");

			var fakeDelegate = A.Fake<T>();
			A.CallTo(fakeDelegate).Where(call => call.Method.Name == "Invoke").WithNonVoidReturnType().ReturnsLazily(invokeResult);
			return fakeDelegate;
		}
	}
}
