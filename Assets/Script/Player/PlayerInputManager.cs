using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerInputManager : MonoBehaviour
{
    [Header("W and S")]
    public float Vertical;
    [Header("A and D")]
    public float Horizontal;
    public event Action OnSpacePressed;


    private void Update()
    {
        vertical();
        horizontal();
        SpacePressed();
    }
    private void vertical()
    {
        Vertical   = Input.GetAxis("Vertical");
    }
    private void horizontal()
    {
        Horizontal = Input.GetAxis("Horizontal");
    }

    private void SpacePressed()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            OnSpacePressed?.Invoke();
            Debug.Log("SpacePressed");
        }
    }
}
