using System.Diagnostics.CodeAnalysis;

namespace AdventOfCode2023.Util;

public class InputFileReader : IDisposable, IInputReader
{
	private readonly string _inputPath;
	private StreamReader _reader;

	public InputFileReader(string inputPath)
	{
		_inputPath = inputPath;
		_reader = new StreamReader(_inputPath);
	}

	public bool TryReadLine([NotNullWhen(true)] out string? line)
	{
		line = _reader.ReadLine();
		return line != null;
	}

	public void Rewind()
	{
		_reader.Dispose();
		_reader = new StreamReader(_inputPath);
	}

	public void Dispose()
	{
		_reader.Close();
		GC.SuppressFinalize(this);
	}
}
