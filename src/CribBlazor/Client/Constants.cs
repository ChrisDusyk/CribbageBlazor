using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CribBlazor.Client
{
	public static class AnimationDuration
	{
		public static TimeSpan DefaultTransition = TimeSpan.FromMilliseconds(250);
		public static TimeSpan PageTransition = TimeSpan.FromMilliseconds(50);
	}
}
