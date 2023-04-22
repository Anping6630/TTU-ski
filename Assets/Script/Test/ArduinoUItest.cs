using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ArduinoUItest : MonoBehaviour
{
    private Singleton singleton;
    private PlayerInputManager InputManager;

    public GameObject a;

    void Start()
    {
        singleton = Singleton.singleton;
        InputManager = singleton.playerInputManager;

        EventSystem.current.SetSelectedGameObject(a);
    }

    void Update()
    {
        if (Input.GetKeyDown("p") || InputManager.Controller_Right >= 0.8f)
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
