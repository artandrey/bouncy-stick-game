using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    [SerializeField]
    private GameObject[] levels;

    [SerializeField]
    private Transform levelPoint;

    private GameObject currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        LoadLevel(0);
    }

    private void LoadLevel(int index)
    {
        if (currentLevel != null)
        {
            Destroy(currentLevel);
        }
        currentLevel = Instantiate(levels[index], levelPoint);
    }

    public void Next()
    {

    }

    public void Previous()
    {

    }
}
