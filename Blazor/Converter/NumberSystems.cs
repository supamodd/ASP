using System.Numerics;
using System.Text;

namespace Converter;

public static class NumberSystems
{
	const string Digits = "0123456789ABCDEF";

	public static string Dec2Bin(string input) => FromDec(input, 2);
	public static string Dec2Hex(string input) => FromDec(input, 16);
	public static string Bin2Dec(string input) => ToDec(input, 2);
	public static string Hex2Dec(string input) => ToDec(input, 16);

	static string FromDec(string input, int toBase)
	{
		if (!TryParseDec(input, out BigInteger value))
			return "Invalid input";

		return ToBase(value, toBase);
	}

	static string ToDec(string input, int fromBase)
	{
		if (!TryParseInBase(input, fromBase, out BigInteger value))
			return "Invalid input";

		return value.ToString();
	}

	static bool TryParseDec(string? input, out BigInteger value)
	{
		value = 0;
		if (string.IsNullOrWhiteSpace(input))
			return false;

		return BigInteger.TryParse(input.Trim(), out value);
	}

	static bool TryParseInBase(string? input, int fromBase, out BigInteger value)
	{
		value = 0;
		if (string.IsNullOrWhiteSpace(input))
			return false;

		string text = input.Trim();
		if (fromBase == 16 && text.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
			text = text[2..];
		if (fromBase == 2 && text.StartsWith("0b", StringComparison.OrdinalIgnoreCase))
			text = text[2..];

		text = text.Replace(" ", "");
		if (text.Length == 0)
			return false;

		bool negative = false;
		if (text[0] == '+' || text[0] == '-')
		{
			negative = text[0] == '-';
			text = text[1..];
			if (text.Length == 0)
				return false;
		}

		BigInteger result = 0;
		foreach (char raw in text)
		{
			int digit = Digits.IndexOf(char.ToUpperInvariant(raw));
			if (digit < 0 || digit >= fromBase)
				return false;

			result = result * fromBase + digit;
		}

		value = negative ? -result : result;
		return true;
	}

	static string ToBase(BigInteger value, int toBase)
	{
		if (value == 0)
			return "0";

		bool negative = value.Sign < 0;
		value = BigInteger.Abs(value);

		var sb = new StringBuilder();
		while (value > 0)
		{
			int digit = (int)(value % toBase);
			sb.Insert(0, Digits[digit]);
			value /= toBase;
		}

		if (negative)
			sb.Insert(0, '-');

		return sb.ToString();
	}
}
