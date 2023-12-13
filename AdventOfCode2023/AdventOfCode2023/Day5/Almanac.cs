using System.Text.RegularExpressions;

using AdventOfCode2023.Util;

namespace AdventOfCode2023.Day5
{
	public partial class Almanac
	{
		private readonly Dictionary<int, int> _seedToSoil = new();
		private readonly Dictionary<int, int> _soilToFertilizer = new();
		private readonly Dictionary<int, int> _fertilizerToWater = new();
		private readonly Dictionary<int, int> _waterToLight = new();
		private readonly Dictionary<int, int> _lightToTemperature = new();
		private readonly Dictionary<int, int> _temperatureToHumidity = new();
		private readonly Dictionary<int, int> _humidityToLocation = new();

		public Dictionary<int, int> SeedToSoil => _seedToSoil;

		public void FillSeedToSoilMap(string inputString)
		{
			_FillMap(inputString, _seedToSoil);
		}

		public void FillSoilToFertilizerMap(string inputString)
		{
			_FillMap(inputString, _soilToFertilizer);
		}

		public void FillFertilizerToWaterMap(string inputString)
		{
			_FillMap(inputString, _fertilizerToWater);
		}

		public void FillWaterToLightMap(string inputString)
		{
			_FillMap(inputString, _waterToLight);
		}

		public void FillLightToTemperatureMap(string inputString)
		{
			_FillMap(inputString, _lightToTemperature);
		}

		public void FillTemperatureToHumidity(string inputString)
		{
			_FillMap(inputString, _temperatureToHumidity);
		}

		public void FillHumidityToLocation(string inputString)
		{
			_FillMap(inputString, _humidityToLocation);
		}

		private void _FillMap(string input, Dictionary<int, int> mapToFill)
		{
			//for each line expect:"xxx yyy zzz", where
			// xxx = destination range start
			// yyy = source range start
			// zzz = range length

			var reader = new InputStringReader(input);
			while (reader.TryReadLine(out var line))
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
	}
}
