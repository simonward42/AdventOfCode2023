using AdventOfCode2023.Util;

namespace AdventOfCode2023;

public abstract class Puzzle<TAnswer> : IDisposable
{
	const string _inputFile = "input.txt";
	readonly string _inputPath;
	readonly int _day;

	public InputReader InputReader;

	public Puzzle(int day)
	{
		_day = day;
		_inputPath = $"Day{_day}/{_inputFile}";
		InputReader = new InputReader(_inputPath);
	}

	public string SolvePretty()
	{
		TAnswer part1;
		TAnswer part2;

		using (InputReader = new InputReader(_inputPath))
		{
			part1 = SolvePart1();
		}

		using (InputReader = new InputReader(_inputPath))
		{
			part2 = SolvePart2();
		}

		return $"+++ Day {_day}\n" +
			$"---- Part 1: {part1}\n" +
			$"---- Part 2: {part2}\n";
	}

	public TAnswer GetPart1Answer()
	{
		TAnswer part1;
		using (InputReader = new InputReader(_inputPath))
		{
			part1 = SolvePart1();
		}

		return part1;
	}

	public TAnswer GetPart2Answer()
	{
		TAnswer part2;
		using (InputReader = new InputReader(_inputPath))
		{
			part2 = SolvePart2();
		}

		return part2;
	}

	protected abstract TAnswer SolvePart1();
	protected abstract TAnswer SolvePart2();

	public void Dispose() => InputReader.Dispose();
}