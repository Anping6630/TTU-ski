using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private Singleton singleton;
    private PlayerInputManager InputManager;

    [SerializeField]
    [Header("StopMenu")]
    private GameObject menu;

    private float holdingTimer;

    void Start()
    {
        singleton = Singleton.singleton;
        InputManager = singleton.playerInputManager;

        GameResume();
    }

    void Update()
    {
        if (InputManager.Controller_Left <= 0.05f && InputManager.Controller_Right <= 0.05f)
        {
            holdingTimer += 1;
            if(holdingTimer == 450)
            {
                GamePause();
            }
            
        }
        else
        {
            holdingTimer = 0;
        }

        if (Input.GetKeyDown("Escape"))
        {
            GamePause();
        }
    }

    public void GameResume()
    {
        menu.SetActive(false);
        Time.timeScale = 1f;
        holdingTimer = 0;
    }

    public void GamePause()
    {
        menu.SetActive(true);
        Time.timeScale = 0f;
        holdingTimer = 0;
    }
}
