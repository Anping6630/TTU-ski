using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGame : MonoBehaviour
{
    [SerializeField]
    private PlayerInputManager playerInput;
    private GameObject Aim;
    private RectTransform AimRect;
    private float ViewportPoint_X;
    private float ViewportPoint_Y;

    private void Awake()
    {
        Aim = GameObject.Find("Aim");
        AimRect = Aim.GetComponent<RectTransform>();
    }
    private void Update()
    {
        getPlayerInput();
        AimController();    
    }

    private void getPlayerInput()
    {
        ViewportPoint_X = playerInput.Controller_Left;
        ViewportPoint_Y = playerInput.Controller_Right;
    }
    private void AimController()
    {
        Vector3 NewViewpoint = new Vector3(ViewportPoint_X - 0.5f, ViewportPoint_Y - 0.5f, 0);
        AimRect.anchoredPosition = Camera.main.ViewportToScreenPoint(NewViewpoint);
    }
}
