namespace AdventOfCode2023.Day2;

internal class Game
{
	public int Id { get; set; }
	public ICollection<Round> Rounds { get; set; } = new List<Round>();

	internal bool IsPossible(int maxR, int maxG, int maxB)
	{
		return Rounds.All(round =>
			round.Red <= maxR &&
			round.Green <= maxG &&
			round.Blue <= maxB);
	}
}

internal class Round
{
	public int Red { get; set; }
	public int Green { get; set; }
	public int Blue { get; set; }
}