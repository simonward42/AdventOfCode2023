﻿using System.Diagnostics.CodeAnalysis;

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

		public string? ReadLine()
		{
			return Reader.ReadLine();
		}

		public string[] ReadUntilEmptyLine()
		{
			var nonEmptyLines = new List<string>();

			var line = ReadLine();

			while (!string.IsNullOrEmpty(line))
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