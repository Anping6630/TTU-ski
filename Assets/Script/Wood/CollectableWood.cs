using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableWood: MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerProgress.wood += 1;
            this.gameObject.SetActive(false);
        }
    }
}
