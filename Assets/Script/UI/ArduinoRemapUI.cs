using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArduinoRemapUI : MonoBehaviour
{
    [SerializeField]
    private GameObject textTopL, textBottomL, textTopR, textBottomR;
    [SerializeField]
    private GameObject portNameInputField;

    void Update()
    {
        textTopL.GetComponent<Text>().text = "左最高數值："+PlayerPrefs.GetFloat("topCalibrationL").ToString();
        textBottomL.GetComponent<Text>().text = "左最低數值："+PlayerPrefs.GetFloat("bottomCalibrationL").ToString();

        textTopR.GetComponent<Text>().text = "右最高數值：" + PlayerPrefs.GetFloat("topCalibrationR").ToString();
        textBottomR.GetComponent<Text>().text = "右最低數值：" + PlayerPrefs.GetFloat("bottomCalibrationR").ToString();
    }

    public void SavePortName()
    {
        PlayerPrefs.SetString("portName", portNameInputField.GetComponent<InputField>().text);
        print(PlayerPrefs.GetString("portName"));
    }
}
