using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void WoodClean()
    {
        PlayerPrefs.SetInt("wood", 0);
    }

    public void ArduinoMode()
    {
        if (GameObject.Find("Toggle").GetComponent<Toggle>().isOn)
        {
            PlayerPrefs.SetInt("ArduinoMode", 1);
        }
        else
        {
            PlayerPrefs.SetInt("ArduinoMode", 0);
        }
    }
    public void resetTimeScale()
    {
        Time.timeScale = 1;
    }
}
