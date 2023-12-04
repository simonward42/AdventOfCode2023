using System.Diagnostics.CodeAnalysis;

namespace AdventOfCode2023.Util;

public class InputReader : IDisposable
{
	private readonly string _inputPath;
	private readonly StreamReader _inputStream;

	public InputReader(string inputPath)
	{
		_inputPath = inputPath;
		_inputStream = new StreamReader(_inputPath);
	}

	public bool TryReadLine([NotNullWhen(true)] out string? line)
	{
		line = _inputStream.ReadLine();
		return line != null;
	}

	public void Dispose()
	{
		_inputStream.Close();
		GC.SuppressFinalize(this);
	}
}
