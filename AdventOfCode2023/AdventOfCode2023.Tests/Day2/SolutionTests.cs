using AdventOfCode2023.Day2;

namespace AdventOfCode2023.Tests.Day2;

public class SolutionTests
{
	readonly string _testInput = "Game 24: 12 green, 4 red, 2 blue; 8 green, 5 blue; 8 green, 2 blue, 2 red";

	const int _expectedGameId = 24;
	const int _expectedRoundCount = 3;
	readonly Round _expectedFirstRound = new()
	{
		Green = 12,
		Red = 4,
		Blue = 2
	};

	[Test]
	public void TestGameParsing()
	{
		var game = Solution.ParseGame(_testInput);

		game.Id.Should().Be(_expectedGameId);
		game.Rounds.Should().HaveCount(_expectedRoundCount);

		var actualFirstRound = game.Rounds.First();
		actualFirstRound.Should().BeEquivalentTo(_expectedFirstRound);
	}
}