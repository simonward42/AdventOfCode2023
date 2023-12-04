using AdventOfCode2023.Day1;

namespace AdventOfCode2023.Tests.Day1;

public class SolutionTests
{
	Solution _sut;

	string _testInput = "threehqv2\r\n" +
		"sxoneightoneckk9ldctxxnffqnzmjqvj\r\n" +
		"1hggcqcstgpmg26lzxtltcgg\r\n" +
		"nrhoneightkmrjkd7fivesixklvvfnmhsldrc\r\n" +
		"zhlzhrkljonephkgdzsnlglmxvprlh6n\r\n" +
		"594chhplnzsxktjmkfpninefiveczfnvsctbxcfzfzjh\r\n" +
		"seven2tjf\r\n" +
		"five712\r\n" +
		"nineight1oneight";

	int[] _expectedDigitsPart1 = { 22, 99, 16, 77, 66, 54, 22, 72, 11 };
	int[] _expectedDigitsPart2 = { 32, 19, 16, 16, 16, 55, 72, 52, 98 };

	[SetUp]
	public void Setup()
	{
		_sut = new Solution();
	}

	[Test]
	public void TestPart1()
	{
		var expectedAnswer = _expectedDigitsPart1.Sum();
		var actualAnswer = _sut.GetPart1Answer();
		actualAnswer.Should().Be(expectedAnswer);
	}

	[Test]
	public void TestPart2()
	{
		var expectedAnswer = _expectedDigitsPart2.Sum();
		var actualAnswer = _sut.GetPart2Answer();
		actualAnswer.Should().Be(expectedAnswer);
	}

	[Test]
	public void TestWordyDigitReplacement()
	{
		var input = "nineight1oneight";
		var expectedDigits = 98;

		int actualDigits;

		var digits = new List<int>();

		for (int i = 0; i < input.Length; i++)
		{
			if (char.IsDigit(input[i]))
			{
				digits.Add(input[i]);
				continue;
			}
			if (input.Substring(startIndex: i).StartsWith("one"))
			{
				digits.Add(1);
				continue;
			}
			if (input.Substring(startIndex: i).StartsWith("two"))
			{
				digits.Add(2);
				continue;
			}
			if (input.Substring(startIndex: i).StartsWith("three"))
			{
				digits.Add(3);
				continue;
			}
			if (input.Substring(startIndex: i).StartsWith("four"))
			{
				digits.Add(4);
				continue;
			}
			if (input.Substring(startIndex: i).StartsWith("five"))
			{
				digits.Add(5);
				continue;
			}
			if (input.Substring(startIndex: i).StartsWith("six"))
			{
				digits.Add(6);
				continue;
			}
			if (input.Substring(startIndex: i).StartsWith("seven"))
			{
				digits.Add(7);
				continue;
			}
			if (input.Substring(startIndex: i).StartsWith("eight"))
			{
				digits.Add(8);
				continue;
			}
			if (input.Substring(startIndex: i).StartsWith("nine"))
			{
				digits.Add(9);
				continue;
			}
		}

		actualDigits = (digits.First() * 10) + digits.Last();

		actualDigits.Should().Be(expectedDigits);
	}
}