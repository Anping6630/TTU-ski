using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ArduinoUiControllTest : MonoBehaviour
{
    private Singleton singleton;
    private PlayerInputManager InputManager;

    public Button[] Selection;
    public int index;

    void Start()
    {
        singleton = Singleton.singleton;
        InputManager = singleton.playerInputManager;

        EventSystem.current.SetSelectedGameObject(Selection[index].gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown("o"))
        {
            if (index == 0)
            {
                index = Selection.Length-1;
            }
            else
            {
                index -= 1;
            }
            EventSystem.current.SetSelectedGameObject(Selection[index].gameObject);
        }
        if (Input.GetKeyDown("p"))
        {
            if (index == Selection.Length - 1)
            {
                index = 0;
            }
            else
            {
                index += 1;
            }
            EventSystem.current.SetSelectedGameObject(Selection[index].gameObject);
        }
        if (Input.GetKeyDown("l") || InputManager.Controller_Right >= 0.8f)
        {
            Confirm();
        }
    }

    public void Ahoy(int i)
    {
        print("Ahoy!"+i);
    }

    public void Confirm()
    {
        EventSystem.current.currentSelectedGameObject.GetComponent<Button>().onClick.Invoke();
    }
}
