using AdventOfCode2023.Util;

namespace AdventOfCode2023.Tests.Util;

public class StringInputReaderTests
{
	readonly string _testInput =
		$"first line\r\n" +
		$"second line";

	readonly string[] _expectedLines = new string[]
	{
		"first line",
		"second line"
	};

	[Test]
	public void TestTryReadLine()
	{
		var sut = new InputStringReader(_testInput);

		var firstLineRead = sut.TryReadLine(out var firstLine);
		firstLineRead.Should().BeTrue();
		firstLine.Should().Be(_expectedLines[0]);

		var secondLineRead = sut.TryReadLine(out var secondLine);
		secondLineRead.Should().BeTrue();
		secondLine.Should().Be(_expectedLines[1]);

		var thirdLineRead = sut.TryReadLine(out var thirdLine);
		thirdLineRead.Should().BeFalse();
		thirdLine.Should().BeNull();
	}

	[Test]
	public void TestRewind()
	{
		var sut = new InputStringReader(_testInput);

		_ = sut.TryReadLine(out var firstLine);

		sut.Rewind();

		_ = sut.TryReadLine(out var nextLine);
		nextLine.Should().Be(firstLine);
	}
}