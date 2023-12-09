using System.Text.RegularExpressions;

using AdventOfCode2023.Util;

namespace AdventOfCode2023.Day3;

public partial class Solution : Puzzle<int>
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
		_solutionPart1 = ParsePartNumbers().Sum();
		return _solutionPart1;
	}

	internal IReadOnlyCollection<int> ParsePartNumbers()
	{
		var symbolPositions = new Dictionary<int /*line number*/, List<int> /*char positions*/>();
		var numberPositions = new Dictionary<int /*line number*/, List<NumberPosition>>();

		var lineNumber = 0;
		while (InputReader.TryReadLine(out string? currentLine))
		{
			symbolPositions[lineNumber] = new List<int>();
			numberPositions[lineNumber] = new List<NumberPosition>();

			symbolPositions[lineNumber].AddRange(_ParseSymbols(currentLine));
			numberPositions[lineNumber].AddRange(_ParseNumbers(currentLine));

			lineNumber++;
		}

		var partNumbers = _FindNumbersAdjacentToSymbols(numberPositions, symbolPositions);
		return partNumbers;
	}

	private IReadOnlyCollection<int> _FindNumbersAdjacentToSymbols(
		Dictionary<int, List<NumberPosition>> numberPositions,
		Dictionary<int, List<int>> symbolPositions)
	{
		var numbersAdjacentSymbol = new List<int>();
		foreach (var numberLine in numberPositions)
		{
			var symbolPositionsForAdjacentLines = new List<int>();
			for (int i = -1; i <= 1; i++)
			{
				if (symbolPositions.TryGetValue(numberLine.Key + i, out var symbolLine))
				{
					symbolPositionsForAdjacentLines.AddRange(symbolLine);
				}
			}

			numbersAdjacentSymbol
				.AddRange(numberLine.Value
					.Where(number => symbolPositionsForAdjacentLines.Any(x =>
						(x >= number.X - 1) && (x <= number.X + number.Width)
					))
					.Select(number => number.Value));
		}

		return numbersAdjacentSymbol;
	}

	[GeneratedRegex(@"([^\d.])")] //neither a digit or a period
	private static partial Regex _symbolRegex();

	private IEnumerable<int> _ParseSymbols(string currentLine)
	{
		var symbolMatches = _symbolRegex().Matches(currentLine);

		return symbolMatches.Select(symbol => symbol.Index);
	}

	[GeneratedRegex(@"(\d+)")] //one or more digit
	private static partial Regex _numberRegex();

	private IEnumerable<NumberPosition> _ParseNumbers(string currentLine)
	{
		var numberMatches = _numberRegex().Matches(currentLine);

		return numberMatches.Select(number => new NumberPosition
		{
			Value = int.Parse(number.Value),
			X = number.Index
		});
	}

	//...
	protected override int SolvePart2()
	{
		//while (InputReader.TryReadLine(out string? currentLine))
		//{

		//}
		return _solutionPart2;
	}
}
