using AdventOfCode2023.Util;

namespace AdventOfCode2023.Day3;

public class Solution : Puzzle<int>
{
	public Solution(IInputReader? reader = null) : base(3, reader)
	{
	}
	private int _solutionPart1 = 0;
	private int _solutionPart2 = 0;

	//Input is a representation of an engine schematic, consisting of numbers, symbols (e.g. '*', '$'), separated by periods '.'.
	//A number represents a *part number* if it is adjacent (even diagonally) to a symbol.
	//Find the sum of all part numbers in the schematic. 
	protected override int SolvePart1()
	{
		//while (InputReader!.TryReadLine(out string? currentLine))
		//{

		//}

		var partNumbers = ParsePartNumbers();

		return _solutionPart1;
	}

	internal IReadOnlyCollection<int> ParsePartNumbers()
	{
		var parsedNumbers = new List<int>();
		var partNumbers = new List<int>();
		while (InputReader!.TryReadLine(out string? currentLine))
		{

		}
		return partNumbers;
	}

	//...
	protected override int SolvePart2()
	{
		//while (InputReader!.TryReadLine(out string? currentLine))
		//{

		//}
		return _solutionPart2;
	}
}
