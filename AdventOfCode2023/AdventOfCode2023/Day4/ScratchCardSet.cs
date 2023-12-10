namespace AdventOfCode2023.Day4
{
	/// <summary>
	/// Represents a set of copies of the same scratch card
	/// </summary>
	internal class ScratchCardSet
	{
		private int _count;
		public int Count => _count;
		public ScratchCard ScratchCard { get; }

		public ScratchCardSet(ScratchCard card)
		{
			ScratchCard = card;
			_count = 1;
		}

		public void AddToSet(int numberOfCards)
		{
			_count += numberOfCards;
		}
	}
}
