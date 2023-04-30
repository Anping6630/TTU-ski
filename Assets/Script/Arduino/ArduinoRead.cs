using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class ArduinoRead : MonoBehaviour
{
    [Header("ArduinoPort"),SerializeField]
    string portName;
    public float valueL;
    public float oldL;
    public float valueR;
    SerialPort sp;
    [SerializeField]
    CalibrationData calibrationData;

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
                    //string[] sArray = value.Split("~");
                    //float.TryParse(sArray[0], out valueL);
                    //float.TryParse(sArray[1], out valueR);
                    float.TryParse(value, out oldL);
                    if(Remap(oldL)>0&& Remap(oldL) < 1)
                    {
                        valueL = Remap(oldL);
                    }
                    //Remap(valueR);
                    print(valueL);
                }
            }
        }
        catch (System.Exception)
        {

        }
    }

    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            PlayerPrefs.SetFloat("topValue", oldL) ;
            print("紀錄高位置" + oldL);
        }
        if (Input.GetKeyDown("w"))
        {
            PlayerPrefs.SetFloat("bottomValue", oldL);
            print("紀錄低位置" + oldL);
        }
    }

    float Remap(float x)
    {
        return (x-PlayerPrefs.GetFloat("topValue"))/(PlayerPrefs.GetFloat("bottomValue")- PlayerPrefs.GetFloat("topValue"));
    }

    void OnApplicationQuit()
    {
        sp.Close();
    }

    void CalibrationSave()
    {
        PlayerPrefs.SetFloat("topValue", calibrationData.topValue);
        PlayerPrefs.SetFloat("bottomValue", calibrationData.bottomValue);
    }

    [System.Serializable]
    public class CalibrationData
    {
        public float topValue;
        public float bottomValue;
    }
}
