using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    private Singleton singleton;
    private PlayerInputManager playerInput;

    private void Awake()
    {
        singleton = Singleton.singleton;
        playerInput = singleton.playerInputManager;
    }
}
