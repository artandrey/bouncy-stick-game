using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelSelector : MonoBehaviour
{
    public int level;
    public Text levelText;

    private bool isLevelCompleted = false;

    private Image image;

    private Color initialColor;

    private readonly Color disabledColor = new Color(116f / 255f, 116f / 255f, 116f / 255f);
    void Start()
    {
        levelText.text = level.ToString();
        image = GetComponent<Image>();
        initialColor = image.color;
        isLevelCompleted = LevelService.IsLevelCompleted(level);
        if (!isLevelCompleted) image.color = disabledColor;
    }

    public void OpenScene()
    {
        if (!isLevelCompleted) return;
        SceneManager.LoadScene("Game Level " + level.ToString());
    }
}
