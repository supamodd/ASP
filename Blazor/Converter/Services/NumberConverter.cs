using System.Numerics;

namespace Converter.Services
{
	/// <summary>
	/// Преобразование целых чисел между системами счисления.
	/// Методы названы так же, как варианты задания: Dec2Bin, Dec2Hex, Bin2Dec, Hex2Dec.
	/// </summary>
	public static class NumberConverter
	{
		const string Digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

		/// <summary>Все допустимые направления пересчёта.</summary>
		public static readonly (string Key, string Title, int From, int To)[] Directions =
		{
			("dec2bin", "Dec2Bin  (10 → 2)", 10, 2),
			("dec2hex", "Dec2Hex  (10 → 16)", 10, 16),
			("bin2dec", "Bin2Dec  (2 → 10)", 2, 10),
			("hex2dec", "Hex2Dec  (16 → 10)", 16, 10),
		};

		/// <summary>Разрешённые символы для входа (без знака числа).</summary>
		public static string AllowedChars(int fromBase) => fromBase switch
		{
			2 => "01",
			10 => "0123456789",
			16 => "0123456789ABCDEF",
			_ => Digits[..fromBase]
		};

		public static string Dec2Bin(string decimalValue) => ToString(FromBase(decimalValue, 10), 2);

		public static string Dec2Hex(string decimalValue) => ToString(FromBase(decimalValue, 10), 16);

		public static string Bin2Dec(string binaryValue) => ToString(FromBase(binaryValue, 2), 10);

		public static string Hex2Dec(string hexValue) => ToString(FromBase(hexValue, 16), 10);

		/// <summary>Проверка результата: строка в системе <paramref name="toBase"/> должна читаться в то же число.</summary>
		public static bool Verify(string source, int sourceBase, string result, int resultBase) =>
			FromBase(source, sourceBase) == FromBase(result, resultBase);

		/// <summary>Строка в системе <paramref name="fromBase"/> -> BigInteger.</summary>
		public static BigInteger FromBase(string value, int fromBase)
		{
			string s = (value ?? string.Empty).Trim().Replace("_", "").Replace(" ", "");

			if (s.Length == 0)
			{
				throw new ArgumentException("Введите число.");
			}

			bool negative = false;
			if (s[0] is '-' or '+')
			{
				negative = s[0] == '-';
				s = s[1..];
			}

			if (s.Length == 0)
			{
				throw new ArgumentException("Введите число.");
			}

			string allowed = AllowedChars(fromBase);
			BigInteger number = 0;

			foreach (char ch in s)
			{
				char upper = char.ToUpperInvariant(ch);
				int digit = upper <= '9' ? upper - '0' : upper - 'A' + 10;

				if (digit < 0 || digit >= fromBase || digit >= allowed.Length || allowed[digit] != upper)
				{
					throw new ArgumentException(
						$"Символ '{ch}' не входит в {BaseName(fromBase)} систему счисления (допустимы: {allowed}).");
				}

				number = number * fromBase + digit;
			}

			return negative ? -number : number;
		}

		/// <summary>BigInteger -> строка в системе <paramref name="toBase"/> (делением на основание).</summary>
		public static string ToString(BigInteger number, int toBase)
		{
			if (number.IsZero)
			{
				return "0";
			}

			bool negative = number.Sign < 0;
			number = BigInteger.Abs(number);

			var chars = new List<char>();
			while (number > 0)
			{
				number = BigInteger.DivRem(number, toBase, out BigInteger remainder);
				chars.Add(Digits[(int)remainder]);
			}

			if (negative)
			{
				chars.Add('-');
			}

			chars.Reverse();
			return new string(chars.ToArray());
		}

		/// <summary>
		/// Цифры числа в системе <paramref name="toBase"/> старшими вперёд - нужно для
		/// таблицы проверки (цифра * основание^позиция).
		/// </summary>
		public static IReadOnlyList<(int Value, char Char)> DigitsOf(BigInteger number, int toBase)
		{
			string s = ToString(BigInteger.Abs(number), toBase);
			var list = new List<(int, char)>(s.Length);

			for (int i = 0; i < s.Length; i++)
			{
				int index = Digits.IndexOf(s[i]);
				list.Add((index < 0 ? 0 : index, s[i]));
			}

			return list;
		}

		public static string BaseName(int basis) => basis switch
		{
			2 => "двоичной",
			8 => "восьмеричной",
			10 => "десятичной",
			16 => "шестнадцатеричной",
			_ => $"{basis}-ичной"
		};
	}
}
