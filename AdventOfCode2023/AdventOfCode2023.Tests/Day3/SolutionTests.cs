using AdventOfCode2023.Day3;
using AdventOfCode2023.Util;

namespace AdventOfCode2023.Tests.Day3;

public class SolutionTests
{
	//In this schematic, two numbers are not part numbers because they are not adjacent to a symbol:
	//114 (top right) and 58 (middle right).
	//Every other number is adjacent to a symbol and so is a part number; their sum is 4361.
	readonly string _testInput =
		"467..114..\r\n" +
		"...*......\r\n" +
		"..35..633.\r\n" +
		"......#...\r\n" +
		"617*......\r\n" +
		".....+.58.\r\n" +
		"..592.....\r\n" +
		"......755.\r\n" +
		"...$.*....\r\n" +
		".664.598..";

	const int _expectedSum = 4361;
	InputStringReader? _reader;

	[SetUp]
	public void SetUp()
	{
		_reader = new InputStringReader(_testInput);
	}

	[Test]
	public void TestPartNumberParsing()
	{
		var parsedPartNumbers = new Solution(_reader).ParsePartNumbers();

		parsedPartNumbers.Sum().Should().Be(_expectedSum);
	}

	[Test]
	public void TestPart1()
	{
		//var expectedAnswer = 2207;

		//var solution = new Solution();

		//var actualAnswer = solution.GetPart1Answer();

		//actualAnswer.Should().Be(expectedAnswer);
	}

	[Test]
	public void TestPart2()
	{
		//var expectedAnswer = 62241;

		//var solution = new Solution();

		//var actualAnswer = solution.GetPart2Answer();

		//actualAnswer.Should().Be(expectedAnswer);
	}
}