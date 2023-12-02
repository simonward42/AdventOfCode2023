using System.Diagnostics.CodeAnalysis;

namespace AdventOfCode2023.Util;

public class InputReader : IDisposable
{
	private StreamReader _inputStream;

	public InputReader(string inputPath)
	{
		_inputStream = new StreamReader(inputPath);
	}

	public void Dispose()
	{
		_inputStream.Dispose();
	}

	public bool TryReadLine([NotNullWhen(true)] out string? line)
	{
		line = _inputStream.ReadLine();
		return line != null;
	}
}
