using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    [SerializeField]
    private LoadScreenControl _loadScreenControl;

    [SerializeField]
    private GameObject[] levels;

    [SerializeField]
    private Transform levelPoint;

    [SerializeField]
    private GameObject player;

    private GameObject currentLevel;
    private int levelIndex;

    private void Start()
    {
        _loadScreenControl.onScreenOffEnded += TimeOn;
        LoadLevel(0);
    }

    private void TimeOn()
    {
        Time.timeScale = 1;
    }

    private void TimeOff()
    {
        Time.timeScale = 0;
    }

    private void OnDestroy()
    {
        _loadScreenControl.onScreenOffEnded -= TimeOn;
    }

    private void LoadLevel(int index)
    {
        if (index >= 0 && index < levels.Length)
        {
            TimeOff();
            _loadScreenControl.ScreenOn();
            if (currentLevel != null)
            {
                Destroy(currentLevel);
            }

            levelIndex = index;
            currentLevel = Instantiate(levels[index], levelPoint);
            currentLevel.GetComponent<LevelControl>().Initialize(player);
            _loadScreenControl.ScreenOff();
            return;
        }

        Debug.LogError($"index:{index} out of bounce");
    }

    public void Next()
    {
        levelIndex += 1;
        LoadLevel(levelIndex);
    }

    public void Previous()
    {
        levelIndex -= 1;
        LoadLevel(levelIndex);
    }
}