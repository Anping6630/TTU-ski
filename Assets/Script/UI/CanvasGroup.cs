using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CanvasGroup : MonoBehaviour
{
    [SerializeField]
    private GameObject[] canvas;

    public void CanvasSwitch(int i)
    {
        for(int o = 0; o < canvas.Length; o++)
        {
            if(o != i) canvas[o].SetActive(false);
        }
        canvas[i].SetActive(true);
        canvas[i].GetComponent<ArduinoUiController>().SelectFix();
    }
}
