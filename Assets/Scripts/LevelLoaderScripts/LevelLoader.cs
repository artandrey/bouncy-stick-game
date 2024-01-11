using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    [SerializeField]
    private LoadScreenControl _loadScreenControl;

    [SerializeField]
    private List<LevelControl> levels;

    [SerializeField]
    private Transform levelPoint;


    [SerializeField]

    private Player player;

    [SerializeField]
    private CameraScript cameraScript;

    private GameObject currentLevel;
    private int levelIndex;

    private bool isInitialLoad = true;

    private void Start()
    {
        _loadScreenControl.onScreenOffEnded += TimeOn;
        _loadScreenControl.onSreenOnEnded += LoadNewLevel;
        player.OnPlayerDeath += Restart;
        player.OnPlayerDeathStart += cameraScript.ScaleUp;
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
        _loadScreenControl.onSreenOnEnded -= LoadNewLevel;
        player.OnPlayerDeath -= Restart;
        player.OnPlayerDeathStart -= cameraScript.ScaleUp;
    }

    private void StartLevelLoad()
    {
        TimeOff();
        _loadScreenControl.ScreenOn();
    }

    private void LoadLevel(int index)
    {
        levelIndex = index;
        if (isInitialLoad)
        {
            LoadNewLevel();
            return;
        }
        StartLevelLoad();

    }

    private void LoadNewLevel()
    {
        if (currentLevel != null)
        {
            Destroy(currentLevel);
        }

        LevelControl level = levels[levelIndex];
        player.DispatchAlive();
        cameraScript.Reset();
        player.transform.position = level.StartPoint.position;
        currentLevel = Instantiate(levels[levelIndex].gameObject, levelPoint);
        if (!isInitialLoad)
        {
            _loadScreenControl.ScreenOff();
        }
        isInitialLoad = false;
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

    public void Restart()
    {
        LoadLevel(levelIndex);
    }
}