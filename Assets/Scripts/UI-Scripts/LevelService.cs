using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelService : MonoBehaviour
{
    static public void SetLevelCompleted(int levelNumber)
    {
        PlayerPrefs.SetInt("CompletedLevelsCount", levelNumber);
    }

    static public bool IsLevelCompleted(int levelNumber)
    {
        if (levelNumber == 1) return true;
        return PlayerPrefs.GetInt("CompletedLevelsCount") >= levelNumber;
    }
}
