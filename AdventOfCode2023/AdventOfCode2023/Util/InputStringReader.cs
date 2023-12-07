using System.Diagnostics.CodeAnalysis;

namespace AdventOfCode2023.Util;

public class InputStringReader : IInputReader
{
	private StringReader _reader;
	private readonly string _input;

	public InputStringReader(string input)
	{
		_reader = new StringReader(input);
		_input = input;
	}

	public bool TryReadLine([NotNullWhen(true)] out string? line)
	{
		line = _reader.ReadLine();
		return line != null;
	}

	public void Rewind()
	{
		_reader.Dispose();
		_reader = new StringReader(_input);
	}

	public void Dispose() => _reader.Dispose();
}
