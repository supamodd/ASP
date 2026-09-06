using System.Numerics;
using Converter.Services;
using Microsoft.AspNetCore.Components;

namespace Converter.Components.Pages
{
	public partial class BaseConverter
	{
		string value = "255";
		string direction = "dec2bin";
		string? result;
		string? error;
		string? hint;
		int ToBasis;
		string decimalSum = "";
		List<(int Position, string Digit, string Weight, string Product)> breakdown = new();
		List<(string Name, string Value)> quick = new();

		(string Key, string Title, int From, int To) Selected =>
			NumberConverter.Directions.First(d => d.Key == direction);

		string FromName => NameOf(Selected.From);
		string ToName => NameOf(Selected.To);

		static string NameOf(int basis) => basis switch
		{
			2 => "Двоичная (2)",
			10 => "Десятичная (10)",
			16 => "Шестнадцатеричная (16)",
			_ => $"Система с основанием {basis}"
		};

		string Clean => (value ?? "").Trim().Replace("_", "").Replace(" ", "");

		string placeholder => Selected.From switch
		{
			2 => "0b11111111 или 11111111",
			16 => "0xFF или FF",
			_ => "255"
		};

		[Inject] NavigationManager? Nav { get; set; }

		protected override void OnInitialized()
		{
			// направление можно задать и адресной строкой: /converter?dir=hex2dec
			string? dir = null;
			if (Nav is not null)
			{
				dir = System.Web.HttpUtility.ParseQueryString(new Uri(Nav.Uri).Query)["dir"];
			}

			if (NumberConverter.Directions.Any(d => d.Key == dir))
			{
				direction = dir!;
				value = Selected.From switch { 2 => "11111111", 16 => "FF", _ => "255" };
			}

			Calculate();
		}

		void OnDirectionChanged()
		{
			// при смене направления меняем и основание входа - старое значение может быть невалидным
			if (Selected.From == 10) value = "255";
			else if (Selected.From == 2) value = "11111111";
			else value = "FF";
			Calculate();
		}

		void Calculate()
		{
			error = null;
			result = null;
			hint = null;
			breakdown = new();
			quick = new();
			decimalSum = "";

			var (key, title, from, to) = Selected;
			string input = Clean;

			if (input.Length == 0)
			{
				error = "Введите число.";
				return;
			}

			try
			{
				// вызывается ровно та функция, которая выбрана в списке направлений
				result = key switch
				{
					"dec2bin" => NumberConverter.Dec2Bin(input),
					"dec2hex" => NumberConverter.Dec2Hex(input),
					"bin2dec" => NumberConverter.Bin2Dec(input),
					"hex2dec" => NumberConverter.Hex2Dec(input),
					_ => throw new ArgumentException("Неизвестное направление пересчёта.")
				};
			}
			catch (ArgumentException ex)
			{
				error = ex.Message;
				return;
			}

			ToBasis = to;

			// контроль: обратно читаем результат в его системе - должно получиться исходное число
			bool ok = NumberConverter.Verify(input, from, result, to);
			BigInteger number = NumberConverter.FromBase(input, from);
			decimalSum = NumberConverter.ToString(BigInteger.Abs(number), 10);

			var digits = NumberConverter.DigitsOf(BigInteger.Abs(number), to);
			for (int i = 0; i < digits.Count; i++)
			{
				int position = digits.Count - 1 - i;
				BigInteger weight = BigInteger.Pow(to, position);
				breakdown.Add((position, digits[i].Char.ToString(), weight.ToString(),
					(weight * digits[i].Value).ToString()));
			}

			hint = $"{title}: {digits.Count} разрядов, обратное чтение результата {result} " +
				$"в {NumberConverter.BaseName(to)} системе - {(ok ? "совпало" : "ОШИБКА")}.";

			// одно и то же число (в десятичном виде) прогоняем через все четыре функции
			string dec = decimalSum;
			string bin = Safe(() => NumberConverter.Dec2Bin(dec));
			string hex = Safe(() => NumberConverter.Dec2Hex(dec));
			quick = new()
			{
				($"Dec2Bin({dec})", bin),
				($"Dec2Hex({dec})", hex),
				($"Bin2Dec({bin})", Safe(() => NumberConverter.Bin2Dec(bin))),
				($"Hex2Dec({hex})", Safe(() => NumberConverter.Hex2Dec(hex))),
			};
		}

		static string Safe(Func<string> f)
		{
			try
			{
				return f();
			}
			catch (ArgumentException)
			{
				return "—";
			}
		}
	}
}
