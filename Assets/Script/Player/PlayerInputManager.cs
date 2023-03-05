using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    [Header("W and S")]
    public float Vertical;
    [Header("A and D")]
    public float Horizontal;

    private void Update()
    {
        vertical();
        horizontal();
    }
    private void vertical()
    {
        Vertical   = Input.GetAxis("Vertical");
    }
    private void horizontal()
    {
        Horizontal = Input.GetAxis("Horizontal");
    }
}
