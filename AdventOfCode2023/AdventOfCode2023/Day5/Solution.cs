using AdventOfCode2023.Util;

namespace AdventOfCode2023.Day5;

public partial class Solution : Puzzle<ulong>
{
	public const int day = 5;
	public Solution(IInputReader? reader = null) : base(day, reader)
	{
	}

	//hard to summarize... just read https://adventofcode.com/2023/day/5#part1 !
	protected override ulong SolvePart1()
	{
		//1. parse seeds to input into almanac later
		//2. parse maps into almanac's dictionaries
		//3. feed seeds through almanac to get locations
		//4. return minimum location

		var seedLine = InputReader.ReadLine();
		var seeds = _GetSeeds(seedLine);

		_ = InputReader.ReadLine(); //throw away line break

		var almanac = new Almanac();

		_FillAlmanacMaps(almanac);

		var seedLocations = seeds.Select(s => almanac.GetLocationForSeed(s));

		return seedLocations.Min();
	}

	private void _FillAlmanacMaps(Almanac almanac)
	{
		_ = InputReader.ReadLine(); //seed-to-soil map:
		var mapInput = InputReader.ReadUntilEmptyLine();
		almanac.InitializeMap(Almanac.MapType.SeedToSoil, mapInput);

		_ = InputReader.ReadLine(); //soil-to-fertilizer map:
		mapInput = InputReader.ReadUntilEmptyLine();
		almanac.InitializeMap(Almanac.MapType.SoilToFertilizer, mapInput);

		_ = InputReader.ReadLine(); //fertilizer-to-water map:
		mapInput = InputReader.ReadUntilEmptyLine();
		almanac.InitializeMap(Almanac.MapType.FertilizerToWater, mapInput);

		_ = InputReader.ReadLine(); //water-to-light map:
		mapInput = InputReader.ReadUntilEmptyLine();
		almanac.InitializeMap(Almanac.MapType.WaterToLight, mapInput);

		_ = InputReader.ReadLine(); //light-to-temperature map:
		mapInput = InputReader.ReadUntilEmptyLine();
		almanac.InitializeMap(Almanac.MapType.LightToTemperature, mapInput);

		_ = InputReader.ReadLine(); //temperature-to-humidity map:
		mapInput = InputReader.ReadUntilEmptyLine();
		almanac.InitializeMap(Almanac.MapType.TemperatureToHumidity, mapInput);

		_ = InputReader.ReadLine(); //humidity-to-location map:
		mapInput = InputReader.ReadUntilEmptyLine();
		almanac.InitializeMap(Almanac.MapType.HumidityToLocation, mapInput);
	}

	private static ulong[] _GetSeeds(string seedLine)
	{
		var seedNumbers = seedLine.Split(':')[1].Trim();
		return seedNumbers.Split(' ').Select(ulong.Parse).ToArray();
	}

	//...
	protected override ulong SolvePart2()
	{
		return 0;
	}
}
