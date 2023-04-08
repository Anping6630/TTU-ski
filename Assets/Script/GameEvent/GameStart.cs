using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    [SerializeField]
    private PlayerInputManager PlayerInput;
    private Animator StartAnimation;
    private bool start;
    private bool playerControl;
    [SerializeField]
    private PlayerSki playerSkiSystem;
    private void Awake()
    {
        StartAnimation = GetComponent<Animator>();
    }
    private void Update()
    {
        waitStart();
        timeSystem();
    }
    private void waitStart()
    {
        if(!playerControl)
        {
            playAnimation();
        }
    }
    private void playAnimation()
    {
        if (PlayerInput.Controller_Left != 0.5f || PlayerInput.Controller_Right != 0.5f)
        {
            StartAnimation.Play("GameStart");
        }
    }
    
    public void StartGame()
    {
        start = true;
        playerControl = true;
    }

    private void timeSystem()
    {
        stopTime();
        activeTime();
    }
    private void stopTime()
    {
        if(!start)
        {
            Time.timeScale = 0;
            playerSkiSystem.enabled = false;
        }
    }
    private void activeTime()
    {
        if(start)
        {
            Time.timeScale = 1;
            playerSkiSystem.enabled = true ;
        }
    }
}
