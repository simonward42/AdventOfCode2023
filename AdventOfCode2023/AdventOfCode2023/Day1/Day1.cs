namespace AdventOfCode2023.Day1;

public class Day1 : Puzzle<string>
{
	private int _solution = 0;

	public Day1() : base(1)
	{
	}

	//for each line of input, find the first and last digit (they may be the same char)
	//these form a two-digit number for each line - the 'calibration value';
	//return the sum of all such numbers
	public override string Solve()
	{
		string? currentLine = null;
		while (InputReader.TryReadLine(out currentLine))
		{
			var digits = currentLine
				.Where(x => Char.IsDigit(x))
				.Select(x => int.Parse(x.ToString()));

			var calibrationVal = (digits.First() * 10) + digits.Last();
			_solution += calibrationVal;
		}



		return _solution.ToString();
	}
}
