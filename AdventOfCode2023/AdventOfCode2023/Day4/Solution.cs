using AdventOfCode2023.Util;

namespace AdventOfCode2023.Day4;

public partial class Solution : Puzzle<int>
{
	public const int day = 4;
	public Solution(IInputReader? reader = null) : base(day, reader)
	{
	}

	//Our input represents a pile of scratch cards, with each line representing a single card, e.g.:
	//"Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53"
	//A card consists of two sets of numbers separated by a vertical bar '|':
	// set 1: the winning numbers for this card
	// set 2: the numbers you have to match against the winners.
	//A card's point value is determined by the number of winning numbers you have in your set:
	// 1 for the first match, doubled by each subsequent match. 
	//How many points is our pile of cards worth? 
	protected override int SolvePart1()
	{
		var pointSum = 0;
		while (InputReader.TryReadLine(out var currentLine))
		{
			var card = new ScratchCard(currentLine);
			pointSum += card.PointValue;
		}

		return pointSum;
	}

	//...
	protected override int SolvePart2()
	{
		return 0;
	}
}
