using System.Numerics;

namespace Blazor.Components.Pages
{
	public partial class Fibonacci
	{
		int n = 0;                     // сколько чисел вывести
		List<BigInteger> sequence = new();  // сам ряд Фибоначчи

		void Calculate()
		{
			sequence.Clear();

			BigInteger a = 0, b = 1;
			for (int i = 0; i < n; i++)
			{
				sequence.Add(a);

				BigInteger next = a + b;
				a = b;
				b = next;
			}
		}
	}
}
