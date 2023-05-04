using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArduinoRemapUI : MonoBehaviour
{
    [SerializeField]
    private GameObject textTop,textBottom;

    void Update()
    {
        textTop.GetComponent<Text>().text = "當前最高數值："+PlayerPrefs.GetFloat("topValue").ToString();
        textBottom.GetComponent<Text>().text = "當前最低數值："+PlayerPrefs.GetFloat("bottomValue").ToString();
    }
}
