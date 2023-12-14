using System.Diagnostics.CodeAnalysis;

namespace AdventOfCode2023.Util
{
	public abstract class InputTextReader : IDisposable
	{
		protected abstract TextReader Reader { get; }

		public bool TryReadLine([NotNullWhen(true)] out string? line)
		{
			line = Reader.ReadLine();
			return line != null;
		}

		public string ReadLine()
		{
			var line = Reader.ReadLine();
			return line ?? throw new EndOfInputException();
		}

		public string ReadUntilEmptyLine()
		{
			var accumulatedString = string.Empty;

			var line = Reader.ReadLine();

			while (line != string.Empty)
			{
				accumulatedString += line;
				line = Reader.ReadLine();
			}
			return accumulatedString;
		}

		public abstract void Rewind();

		public void Dispose() => Reader.Dispose();
	}
}