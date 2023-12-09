using AdventOfCode2023.Util;

namespace AdventOfCode2023.Day3
{
	internal class NumberPosition : Point2d
	{
		public int Value { get; set; } = 0;

		public int Width { get => Value.ToString().Length; }
	}
}
