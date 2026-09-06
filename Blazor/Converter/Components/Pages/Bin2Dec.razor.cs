namespace Converter.Components.Pages;

public partial class Bin2Dec
{
	string input = "1010";
	string result = "10";

	void Calculate()
	{
		result = NumberSystems.Bin2Dec(input);
	}
}
