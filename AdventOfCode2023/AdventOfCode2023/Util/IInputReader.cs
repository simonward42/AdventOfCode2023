using System.Diagnostics.CodeAnalysis;

namespace AdventOfCode2023.Util
{
	public interface IInputReader : IDisposable
	{
		bool TryReadLine([NotNullWhen(true)] out string? line);
		void Rewind();
	}
}