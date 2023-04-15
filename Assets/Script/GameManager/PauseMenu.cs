using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    [Header("StopMenu")]
    private GameObject menu;

    private bool isGamePause;

    void Start()
    {
         GameResume();
    }

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (isGamePause)
            {
                GameResume();
            }
            else
            {
                GamePause();
            }
        }
    }

    public void GameResume()
    {
        isGamePause = false;
        menu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void GamePause()
    {
        isGamePause = true;
        menu.SetActive(true);
        Time.timeScale = 0f;
    }
}
