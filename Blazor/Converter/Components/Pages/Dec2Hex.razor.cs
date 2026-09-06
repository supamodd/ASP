namespace Converter.Components.Pages;

public partial class Dec2Hex
{
	string input = "255";
	string result = "FF";

	void Calculate()
	{
		result = NumberSystems.Dec2Hex(input);
	}
}
