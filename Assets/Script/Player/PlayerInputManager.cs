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
    [Header("I & J")]
    public float Controller_Right;
    [SerializeField]
    private float maxRight = 1;
    [SerializeField]
    private float minRight = -1;
    [Header("R & F")]
    public float Controller_Left;
    [SerializeField]
    private float maxLeft;
    [SerializeField]
    private float minLeft;


    private void Update()
    {
        vertical();
        horizontal();
        SpacePressed();
        controller_Right();
        controller_Right_limiter();
        controller_Left();
        controller_Left_limiter();

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
    private void controller_Right()
    {
        if(Input.GetKey(KeyCode.I))
        {
            Controller_Right += Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.J))
        {
            Controller_Right -= Time.deltaTime;
        }
    }
    private void controller_Left()
    {
        if (Input.GetKey(KeyCode.R))
        {
            Controller_Left += Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.F))
        {
            Controller_Left -= Time.deltaTime;
        }
    }
    private void controller_Right_limiter()
    {
        if (Controller_Right > maxRight) Controller_Right = maxRight;
        if (Controller_Right < minRight) Controller_Right = minRight;
    }
    private void controller_Left_limiter()
    {
        if (Controller_Left > maxLeft) Controller_Left = maxLeft;
        if (Controller_Left < minLeft) Controller_Left = minLeft;
    }
}
