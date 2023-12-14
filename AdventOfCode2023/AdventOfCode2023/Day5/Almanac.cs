using System.Text.RegularExpressions;

namespace AdventOfCode2023.Day5
{
	public partial class Almanac
	{
		public enum MapType
		{
			SeedToSoil,
			SoilToFertilizer,
			FertilizerToWater,
			WaterToLight,
			LightToTemperature,
			TemperatureToHumidity,
			HumidityToLocation
		}

		private readonly Dictionary<MapType, Dictionary<int, int>> _maps = new()
		{
			{ MapType.SeedToSoil, new() },
			{ MapType.SoilToFertilizer, new() },
			{ MapType.FertilizerToWater, new() },
			{ MapType.WaterToLight, new() },
			{ MapType.LightToTemperature, new() },
			{ MapType.TemperatureToHumidity, new() },
			{ MapType.HumidityToLocation, new() }
		};

		public Dictionary<int, int> SeedToSoil => _maps[MapType.SeedToSoil];

		public int GetLocationForSeed(int seed)
		{
			var source = seed;
			int dest = 0;
			foreach (var mapType in Enum.GetValues<MapType>())
			{
				dest = _GetDestination(mapType, source);
				source = dest;
			}

			return dest;
		}

		public void FillMap(MapType mapType, string[] input)
		{
			//for each line expect:"xxx yyy zzz", where
			// xxx = destination range start
			// yyy = source range start
			// zzz = range length

			var mapToFill = _maps[mapType];

			foreach (var line in input)
			{
				var mapMatch = _MapLine().Match(line);
				//TODO factor out the raw regex matching
				var destStart = int.Parse(mapMatch.Groups[_dest].Value);
				var srcStart = int.Parse(mapMatch.Groups[_src].Value);
				var rangeLen = int.Parse(mapMatch.Groups[_rng].Value);

				for (var i = 0; i < rangeLen; i++)
				{
					mapToFill.Add(srcStart + i, destStart + i);
				}
			}
		}

		private const string _dest = "dest";
		private const string _src = "src";
		private const string _rng = "rng";

		[GeneratedRegex(@$"(?<{_dest}>\d+) (?<{_src}>\d+) (?<{_rng}>\d+)")]
		private static partial Regex _MapLine();


		private int _GetDestination(MapType mapType, int source)
		{
			if (_maps[mapType].TryGetValue(source, out int dest))
				return dest;

			return source;
		}
	}
}
