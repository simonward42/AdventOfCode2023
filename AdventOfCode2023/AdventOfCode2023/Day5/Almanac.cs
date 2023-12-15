using System.Text.RegularExpressions;

namespace AdventOfCode2023.Day5;

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

	private readonly Dictionary<MapType, Dictionary<long, long>> _maps = new()
	{
		{ MapType.SeedToSoil, new() },
		{ MapType.SoilToFertilizer, new() },
		{ MapType.FertilizerToWater, new() },
		{ MapType.WaterToLight, new() },
		{ MapType.LightToTemperature, new() },
		{ MapType.TemperatureToHumidity, new() },
		{ MapType.HumidityToLocation, new() }
	};

	private readonly Dictionary<MapType, Dictionary<long, (long, long)>> _mapsRedo = new()
	{
		{ MapType.SeedToSoil, new() },
		{ MapType.SoilToFertilizer, new() },
		{ MapType.FertilizerToWater, new() },
		{ MapType.WaterToLight, new() },
		{ MapType.LightToTemperature, new() },
		{ MapType.TemperatureToHumidity, new() },
		{ MapType.HumidityToLocation, new() }
	};

	public Dictionary<long, long> SeedToSoil => _maps[MapType.SeedToSoil];

	public long GetLocationForSeed(long seed)
	{
		var source = seed;
		long dest = 0;
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
			var destStart = long.Parse(mapMatch.Groups[_dest].Value);
			var srcStart = long.Parse(mapMatch.Groups[_src].Value);
			var rangeLen = long.Parse(mapMatch.Groups[_rng].Value);

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


	private long _GetDestination(MapType mapType, long source)
	{
		if (_maps[mapType].TryGetValue(source, out long dest))
			return dest;

		return source;
	}
}

public partial class RangedMap
{
	private List<(ulong src, ulong dest, ulong range)> _mappedValues = new();

	public bool IsMapped(ulong source)
	{
		return _mappedValues.Any(x => x.src <= source && source < x.src + x.range);
	}

	public ulong GetDestination(ulong source)
	{
		var dest = source;
		foreach (var x in _mappedValues)
		{
			var offset = (long)(source - x.src);
			if (0 <= offset && offset < (long)x.range)
			{
				dest = x.dest + (ulong)offset;
				break;
			}
		}
		return dest;
	}

	public void Add(ulong sourceStart, ulong destStart, ulong range)
	{
		_mappedValues.Add((sourceStart, destStart, range));
	}

	public RangedMap(string[] input)
	{
		_FillMap(input);
	}

	private const string _dest = "dest";
	private const string _src = "src";
	private const string _rng = "rng";

	[GeneratedRegex(@$"(?<{_dest}>\d+) (?<{_src}>\d+) (?<{_rng}>\d+)")]
	private static partial Regex _MapLine();

	private void _FillMap(string[] input)
	{
		//for each line expect:"xxx yyy zzz", where
		// xxx = destination range start
		// yyy = source range start
		// zzz = range length

		foreach (var line in input)
		{
			var mapMatch = _MapLine().Match(line);
			var destStart = ulong.Parse(mapMatch.Groups[_dest].Value);
			var srcStart = ulong.Parse(mapMatch.Groups[_src].Value);
			var rangeLen = ulong.Parse(mapMatch.Groups[_rng].Value);

			_mappedValues.Add((srcStart, destStart, rangeLen));
		}
	}
}
