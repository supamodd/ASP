namespace Converter.Components.Pages;

public partial class Dec2Bin
{
	string input = "10";
	string result = "1010";

	void Calculate()
	{
		result = NumberSystems.Dec2Bin(input);
	}
}
