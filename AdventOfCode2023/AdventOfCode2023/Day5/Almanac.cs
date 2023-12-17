using System.Runtime.Serialization;
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

	private readonly Dictionary<MapType, RangedMap?> _maps = new()
	{
		{ MapType.SeedToSoil, null },
		{ MapType.SoilToFertilizer, null },
		{ MapType.FertilizerToWater, null },
		{ MapType.WaterToLight, null },
		{ MapType.LightToTemperature, null },
		{ MapType.TemperatureToHumidity, null },
		{ MapType.HumidityToLocation, null }
	};

	public ulong GetLocationForSeed(ulong seed)
	{
		var source = seed;
		ulong dest = 0;
		foreach (var mapType in Enum.GetValues<MapType>())
		{
			dest = _GetDestination(mapType, source);
			source = dest;
		}

		return dest;
	}

	public void InitializeMap(MapType mapType, string[] input)
	{
		_maps[mapType] = new RangedMap(input);
	}

	private ulong _GetDestination(MapType mapType, ulong source)
	{
		return _maps[mapType]?.GetDestination(source) ?? throw new UninitializedMapException();
	}
}

public partial class RangedMap
{
	public RangedMap(string[] input)
	{
		_FillMap(input);
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

	private List<(ulong src, ulong dest, ulong range)> _mappedValues = new();

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

[Serializable]
internal class UninitializedMapException : Exception
{
	public UninitializedMapException()
	{
	}

	public UninitializedMapException(string? message) : base(message)
	{
	}

	public UninitializedMapException(string? message, Exception? innerException) : base(message, innerException)
	{
	}

	protected UninitializedMapException(SerializationInfo info, StreamingContext context) : base(info, context)
	{
	}
}
