using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelService : MonoBehaviour
{
    static public void SetLevelCompleted(int levelNumber)
    {
        PlayerPrefs.SetInt("CompletedLevelsCount", levelNumber);
    }

    static public bool IsLevelOpended(int levelNumber)
    {

        if (levelNumber == 1) return true;
        return levelNumber <= PlayerPrefs.GetInt("CompletedLevelsCount") + 1;
    }
}
