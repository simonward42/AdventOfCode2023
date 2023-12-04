using AdventOfCode2023.Day2;

namespace AdventOfCode2023.Tests.Day2;

public class GameTests
{
	readonly Game _game = new();

	[SetUp]
	public void Setup()
	{
		_game.Rounds.Add(new Round
		{
			Red = 4,
			Green = 0,
			Blue = 3
		});

		_game.Rounds.Add(new Round
		{
			Red = 1,
			Green = 2,
			Blue = 6
		});

		_game.Rounds.Add(new Round
		{
			Red = 0,
			Green = 2,
			Blue = 0
		});
	}

	[Test]
	public void PowerOfMinimumSet()
	{
		var expectedPower = 4 * 2 * 6;
		var actualPower = _game.PowerOfMinimumSet();

		actualPower.Should().Be(expectedPower);
	}
}