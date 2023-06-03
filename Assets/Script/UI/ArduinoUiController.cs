using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ArduinoUiController : MonoBehaviour
{
    private Singleton singleton;
    private PlayerInputManager InputManager;

    [SerializeField]
    private Button[] selection;
    [SerializeField]
    private int index;
    [SerializeField]
    private float selectColldown;

    private float cooldownTimer;

    void Start()
    {
        singleton = Singleton.singleton;
        InputManager = singleton.playerInputManager;

        SelectFix();
    }

    void Update()
    {
        cooldownTimer += 1;

        if(cooldownTimer >= selectColldown)
        {
            if (InputManager.Controller_Left >= 0.8f)
            {
                SelectLeft();
            }
            if (InputManager.Controller_Right >= 0.8f)
            {
                SelectRight();
            } 
            if (InputManager.Controller_Left >= 0.6f && InputManager.Controller_Right >= 0.6f)
            {
                Confirm();
            }
        }
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
        cooldownTimer = 0;
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
        cooldownTimer = 0;
        EventSystem.current.SetSelectedGameObject(selection[index].gameObject);
    }

    void Confirm()
    {
        cooldownTimer = 0;
        EventSystem.current.currentSelectedGameObject.GetComponent<Button>().onClick.Invoke();
    }

    public void SelectFix()
    {
        EventSystem.current.SetSelectedGameObject(selection[index].gameObject);
    }
}
