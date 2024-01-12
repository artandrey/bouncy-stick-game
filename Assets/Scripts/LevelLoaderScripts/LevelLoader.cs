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

    [SerializeField]
    private int levelNumber = -1;

    private GameObject currentLevel;
    private int roomIndex;

    private bool isInitialLoad = true;

    private void Start()
    {
        if (levelNumber == -1) throw new UnityException("Please provide level number to Level Number field");
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
        roomIndex = index;
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

        RoomControl level = levels[roomIndex];
        player.DispatchAlive();
        cameraScript.Reset();
        player.transform.position = level.StartPoint.position;
        player.transform.rotation = level.StartPoint.rotation;
        player.rigidbody.isKinematic = false;
        player.rigidbody.velocity = Vector2.zero;
        currentLevel = Instantiate(levels[roomIndex].gameObject, levelPoint);
        currentLevel.GetComponent<RoomControl>().OnRoomComplited += Next;
        if (!isInitialLoad)
        {
            _loadScreenControl.ScreenOff();
        }
        isInitialLoad = false;
    }

    public void Next()
    {
        roomIndex += 1;
        if (roomIndex >= levels.Count)
        {
            BackToMenu();
            LevelService.SetLevelCompleted(levelNumber);
            return;
        }
        LoadLevel(roomIndex);
    }

    public void Previous()
    {
        roomIndex -= 1;
        LoadLevel(roomIndex);
    }

    public void Restart()
    {
        LoadLevel(roomIndex);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}