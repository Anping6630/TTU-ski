using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class ArduinoRead : MonoBehaviour
{
    [Header("ArduinoPort"),SerializeField]
    string portName;
    public float originL, originR;
    public float valueL,valueR;
    SerialPort sp;

    void Start()
    {
        sp = new SerialPort(portName,9600);
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

                    if(Remap(originL) > 0 && Remap(originL) < 1)
                    {
                        valueL = Remap(originL);
                    }
                    if (Remap(originR) > 0 && Remap(originR) < 1)
                    {
                        valueL = Remap(originR);
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

    float Remap(float x)
    {
        return (x-PlayerPrefs.GetFloat("topValue"))/(PlayerPrefs.GetFloat("bottomValue")- PlayerPrefs.GetFloat("topValue"));
    }

    void CalibrationSave()
    {
        if (Input.GetKeyDown("q"))
        {
            PlayerPrefs.SetFloat("topValue", originL);
        }
        if (Input.GetKeyDown("w"))
        {
            PlayerPrefs.SetFloat("bottomValue", originR);
        }
    }
    void OnApplicationQuit()
    {
        sp.Close();
    }
}
