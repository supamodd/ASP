namespace Converter.Components.Pages;

public partial class Hex2Dec
{
	string input = "FF";
	string result = "255";

	void Calculate()
	{
		result = NumberSystems.Hex2Dec(input);
	}
}
