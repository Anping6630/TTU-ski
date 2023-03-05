using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    //use Singleton.singleton to call.
    #region
    public static Singleton singleton;
    private void Awake()
    {
        singleton = GetComponent<Singleton>();
    }
    #endregion

    public PlayerInputManager playerInputManager;
}
