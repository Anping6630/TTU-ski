using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerUI : MonoBehaviour
{
    private Singleton singleton;
    private PlayerInputManager playerInput;
    private float UI_Controller_right;
    private float UI_Controller_left;
    [SerializeField]
    private Slider Slider_Left;
    [SerializeField]
    private Slider Slider_Right;

    
    private void Start()
    {
        singleton = Singleton.singleton;
        playerInput = singleton.playerInputManager;
    }

    private void Update()
    {
        GetPlayerInputController();
        OnSliderValueChanged_Left();
        OnSliderValueChanged_Right();
    }

    private void GetPlayerInputController()
    {
        UI_Controller_left = playerInput.Controller_Left;
        UI_Controller_right = playerInput.Controller_Right;
    }
    public void OnSliderValueChanged_Left()
    {
        Slider_Left.value = UI_Controller_left;
    }
    public void OnSliderValueChanged_Right()
    {
        Slider_Right.value = UI_Controller_right;
    }
}
