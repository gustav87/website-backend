﻿using System.Collections.Generic;

namespace W3ChampionsStatisticService.Services;

public class SeasonMapInformation(IReadOnlyDictionary<string, string> mapNames)
{
    public static readonly SeasonMapInformation Empty = new(new Dictionary<string, string>());

    private readonly IReadOnlyDictionary<string, string> _mapNames = mapNames;

    public string GetMapName(string map)
    {
        if (_mapNames.TryGetValue(map, out var mapName))
        {
            return mapName;
        }

        return null;
    }
}
