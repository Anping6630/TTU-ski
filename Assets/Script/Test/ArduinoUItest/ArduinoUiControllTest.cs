using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ArduinoUiControllTest : MonoBehaviour
{
    private Singleton singleton;
    private PlayerInputManager InputManager;

    public Button[] selection;
    public int index;
    public float selectColldown;

    private float cooldownTimer;

    void Start()
    {
        singleton = Singleton.singleton;
        InputManager = singleton.playerInputManager;

        EventSystem.current.SetSelectedGameObject(selection[index].gameObject);
    }

    void Update()
    {
        cooldownTimer += 1;

        if (InputManager.Controller_Left >= 0.8f && cooldownTimer >= selectColldown)
        {
            cooldownTimer = 0;
            SelectLeft();
        }
        if (InputManager.Controller_Right >= 0.8f && cooldownTimer >= selectColldown)
        {
            cooldownTimer = 0;
            SelectRight();
        }
        if (InputManager.Controller_Left >= 0.6f && InputManager.Controller_Right >= 0.6f && cooldownTimer >= selectColldown)
        {
            cooldownTimer = 0;
            Confirm();
        }
    }

    public void Ahoy(int i)
    {
        print(i);
    }

    void SelectLeft()
    {
        if (index == 0)
        {
            index = selection.Length - 1;
        }
        else
        {
            index -= 1;
        }
        EventSystem.current.SetSelectedGameObject(selection[index].gameObject);
    }

    void SelectRight()
    {
        if (index == selection.Length - 1)
        {
            index = 0;
        }
        else
        {
            index += 1;
        }
        EventSystem.current.SetSelectedGameObject(selection[index].gameObject);
    }

    void Confirm()
    {
        EventSystem.current.currentSelectedGameObject.GetComponent<Button>().onClick.Invoke();
    }
}
