using System.Text.RegularExpressions;

namespace AdventOfCode2023.Day4
{
	public partial class ScratchCard
	{
		public ScratchCard(string cardInput)
		{
			var cardMatch = _CardRegex().Match(cardInput);
			CardId = int.Parse(cardMatch.Groups[1].Value);

			var winningNumbers = cardMatch.Groups[2].Value;
			WinningNumbers = winningNumbers
				.Split(" ")
				.Where(x => !string.IsNullOrWhiteSpace(x))
				.Select(int.Parse)
				.ToArray();

			var yourNumbers = cardMatch.Groups[3].Value;
			YourNumbers = yourNumbers
				.Split(" ")
				.Where(x => !string.IsNullOrWhiteSpace(x))
				.Select(int.Parse)
				.ToArray();
		}

		internal ScratchCard(int id, int[] winningNumbers, int[] yourNumbers)
		{
			CardId = id;
			WinningNumbers = winningNumbers;
			YourNumbers = yourNumbers;
		}

		public int CardId { get; } = 0;
		public IReadOnlyCollection<int> WinningNumbers { get; } = new List<int>();
		public IReadOnlyCollection<int> YourNumbers { get; } = new List<int>();

		public int PointValue => (int)Math.Pow(2, WinningMatches - 1);

		public int WinningMatches => YourNumbers.Intersect(WinningNumbers).Count();

		[GeneratedRegex(@"Card[ ]+(\d+): ([\d ]+) \| ([\d ]+)")]
		private static partial Regex _CardRegex();
	}
}
