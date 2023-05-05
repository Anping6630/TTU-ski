using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class ArduinoRead : MonoBehaviour
{
    public float originL, originR;
    public float valueL,valueR;
    SerialPort sp;

    void Start()
    {
        sp = new SerialPort(PlayerPrefs.GetString("portName"),9600);
        try
        {
            sp.Open();
            print("open");
        }
        catch (System.Exception)
        {

        }
    }

    void FixedUpdate()
    {
        try
        {
            if (sp.IsOpen)
            {
                string value = sp.ReadExisting();
                if (value != "")
                {
                    string[] sArray = value.Split("~");
                    float.TryParse(sArray[0], out originL);
                    float.TryParse(sArray[1], out originR);

                    if(RemapL(originL) > 0 && RemapL(originL) < 1)
                    {
                        valueL = RemapL(originL);
                    }
                    if (RemapR(originR) > 0 && RemapR(originR) < 1)
                    {
                        valueR = RemapR(originR);
                    }
                }
            }
        }
        catch (System.Exception)
        {

        }
    }

    void Update()
    {
        CalibrationSave();
    }

    float RemapL(float x)
    {
        return (x - PlayerPrefs.GetFloat("bottomCalibrationL")) / (PlayerPrefs.GetFloat("topCalibrationL") - PlayerPrefs.GetFloat("bottomCalibrationL"));
    }
    float RemapR(float x)
    {
        return (x - PlayerPrefs.GetFloat("bottomCalibrationR")) / (PlayerPrefs.GetFloat("topCalibrationR") - PlayerPrefs.GetFloat("bottomCalibrationR"));
    }

    void CalibrationSave()
    {
        if (Input.GetKeyDown("q"))
        {
            PlayerPrefs.SetFloat("topCalibrationL", originL);
            PlayerPrefs.SetFloat("topCalibrationR", originR);
        }
        if (Input.GetKeyDown("w"))
        {
            PlayerPrefs.SetFloat("bottomCalibrationL", originL);
            PlayerPrefs.SetFloat("bottomCalibrationR", originR);
        }
    }
    void OnApplicationQuit()
    {
        sp.Close();
    }
}
