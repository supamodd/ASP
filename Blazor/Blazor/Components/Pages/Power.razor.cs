using System.Numerics;

namespace Blazor.Components.Pages
{
	public partial class Power
	{
		int n = 0;    // основание (число, которое возводим)
		int exp = 0;  // степень
		BigInteger result = 0;

		void Calculate()
		{
			result = BigInteger.Pow(n, exp);
		}
	}
}
