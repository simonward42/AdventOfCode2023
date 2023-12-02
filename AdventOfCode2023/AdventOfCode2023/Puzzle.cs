using AdventOfCode2023.Util;

namespace AdventOfCode2023;

public abstract class Puzzle<TAnswer> : IDisposable
{
	const string _inputFile = "input.txt";
	readonly string _inputPath;

	public InputReader InputReader;

	public Puzzle(int day)
	{
		_inputPath = $"Day{day}/{_inputFile}";
		InputReader = new InputReader(_inputPath);
	}

	public abstract TAnswer Solve();

	public void Dispose()
	{
		InputReader.Dispose();
	}
}