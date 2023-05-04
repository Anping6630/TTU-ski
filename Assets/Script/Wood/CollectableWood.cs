using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableWood: MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerPrefs.SetInt("wood", PlayerPrefs.GetInt("wood")+1);
            print(PlayerPrefs.GetInt("wood"));
            this.gameObject.SetActive(false);
        }
    }
}
