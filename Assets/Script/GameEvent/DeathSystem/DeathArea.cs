using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathArea : MonoBehaviour
{
    private DeathSystem deathSystem;
    private void Awake()
    {
        deathSystem = GameObject.Find("UISystem").GetComponent<DeathSystem>();
        Debug.Log("FindObject");
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            deathSystem.PlayerDies();
        }
    }
}
