using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CribBlazor.Shared.Cards
{
	public static class CardExtensions
	{
		public static string SerializeToJson(this Card card)
			=> JsonConvert.SerializeObject(card);
	}
}
