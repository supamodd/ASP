namespace MyAcademy.Models
{
	// Расшифровка битовой маски дней занятий (Groups.weekdays)
	public static class Week
	{
		private static readonly string[] DAYNAMES = { "\u041f\u043d", "\u0412\u0442", "\u0421\u0440", "\u0427\u0442", "\u041f\u0442", "\u0421\u0431", "\u0412\u0441" };

		public static string Decode(int? mask)
		{
			List<string> days = new();
			for (int i = 0; i < DAYNAMES.Length; i++)
			{
				if (((mask ?? 0) & (1 << i)) != 0)
				{
					days.Add(DAYNAMES[i]);
				}
			}
			return days.Count == 0 ? "-" : string.Join(", ", days);
		}
	}
}
