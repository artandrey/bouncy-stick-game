using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SettingsClass
{

    private static SeasonButtonClass.SeasonButtonInfo currentSeason;

    public static void SetSeasonButtonInfo(SeasonButtonClass.SeasonButtonInfo seasonInfo)
    {
        currentSeason = seasonInfo;
    }

    public static SeasonButtonClass.SeasonButtonInfo GetInfo()
    {
        return currentSeason;
    }
}
