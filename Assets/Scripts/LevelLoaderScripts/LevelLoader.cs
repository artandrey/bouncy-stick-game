using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField]
    private LoadScreenControl _loadScreenControl;

    [SerializeField]
    private List<RoomControl> levels;

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
            currentLevel.GetComponent<RoomControl>().OnRoomComplited -= Next;
            Destroy(currentLevel);
        }

        RoomControl level = levels[levelIndex];
        player.DispatchAlive();
        cameraScript.Reset();
        player.transform.position = level.StartPoint.position;
        player.transform.rotation = level.StartPoint.rotation;
        player.rigidbody.isKinematic = false;
        player.rigidbody.velocity = Vector2.zero;
        currentLevel = Instantiate(levels[levelIndex].gameObject, levelPoint);
        currentLevel.GetComponent<RoomControl>().OnRoomComplited += Next;
        if (!isInitialLoad)
        {
            _loadScreenControl.ScreenOff();
        }
        isInitialLoad = false;
    }

    public void Next()
    {
        levelIndex += 1;
        if (levelIndex >= levels.Count)
        {
            BackToMenu();
        }
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

    public void BackToMenu()
    {
        SceneManager.LoadScene("LevelChoose");
    }
}