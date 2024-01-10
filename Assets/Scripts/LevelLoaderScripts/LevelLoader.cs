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

    private GameObject currentLevel;
    private int levelIndex;

    private void Start()
    {
        _loadScreenControl.onScreenOffEnded += TimeOn;
        player.OnPlayerDeath += Restart;
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

        TimeOff();
        _loadScreenControl.ScreenOn();
        if (currentLevel != null)
        {
            Destroy(currentLevel);
        }

        levelIndex = index;
        LevelControl level = levels[index];
        player.DispatchAlive();
        player.transform.position = level.StartPoint.position;
        currentLevel = Instantiate(levels[index].gameObject, levelPoint);
        _loadScreenControl.ScreenOff();

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