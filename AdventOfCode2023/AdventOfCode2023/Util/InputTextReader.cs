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

		public string[] ReadUntilEmptyLine()
		{
			var nonEmptyLines = new List<string>();

			var line = ReadLine();

			while (line != string.Empty)
			{
				nonEmptyLines.Add(line);
				line = ReadLine();
			}
			return nonEmptyLines.ToArray();
		}

		public abstract void Rewind();

		public void Dispose() => Reader.Dispose();
	}
}