using System.Text.RegularExpressions;

namespace AdventOfCode2023.Util;

public static partial class StringExtensions
{
	public static string ReplaceWordyDigits(this string str)
	{
		str = OneRegex().Replace(str, "1");
		str = TwoRegex().Replace(str, "2");
		str = ThreeRegex().Replace(str, "3");
		str = FourRegex().Replace(str, "4");
		str = FiveRegex().Replace(str, "5");
		str = SixRegex().Replace(str, "6");
		str = SevenRegex().Replace(str, "7");
		str = EightRegex().Replace(str, "8");
		return NineRegex().Replace(str, "9");
	}

	public static IEnumerable<int> GetDigits(this string currentLine)
	{
		return currentLine
			.Where(char.IsDigit)
			.Select(x => int.Parse(x.ToString()));
	}

	[GeneratedRegex("one")]
	public static partial Regex OneRegex();
	[GeneratedRegex("two")]
	public static partial Regex TwoRegex();
	[GeneratedRegex("three")]
	public static partial Regex ThreeRegex();
	[GeneratedRegex("four")]
	public static partial Regex FourRegex();
	[GeneratedRegex("five")]
	public static partial Regex FiveRegex();
	[GeneratedRegex("six")]
	public static partial Regex SixRegex();
	[GeneratedRegex("seven")]
	public static partial Regex SevenRegex();
	[GeneratedRegex("eight")]
	public static partial Regex EightRegex();
	[GeneratedRegex("nine")]
	public static partial Regex NineRegex();
}
