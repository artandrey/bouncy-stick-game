using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SeasonButtonClass : MonoBehaviour
{
    //For unity inspector;
    public short amountOfLevels;
    public int sceneIndex;

    private SeasonButtonInfo seasonInfo;

    private void Start()
    {
        if (amountOfLevels <= 0)
        {
            Debug.Log("NumberOfLevels < 0");
            amountOfLevels = 0;
            transform.Find("Text").GetComponent<Text>().text = "В разработке";
        }

        if(sceneIndex > 0)
        {
            seasonInfo = new SeasonButtonInfo(amountOfLevels, sceneIndex);
        }
        else
        {
            Debug.Log("Недопустимое значение индекса игрового уровня");
        }
    }

    public void OnButtonClick()
    {
        SettingsClass.SetSeasonButtonInfo(seasonInfo);
        //TEST 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public class SeasonButtonInfo
    {

        private short amountOfLevels;

        private int firstSceneIndex;

        public SeasonButtonInfo(short numOfLevel, int sceneIndex)
        {
            amountOfLevels = numOfLevel;

            firstSceneIndex = sceneIndex;
        }

        public short GetAmount()
        {
            return amountOfLevels;
        }

    }

}
