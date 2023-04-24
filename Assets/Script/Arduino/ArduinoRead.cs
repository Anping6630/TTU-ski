using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class ArduinoRead : MonoBehaviour
{
    [Header("ArduinoPort")]
    public string portName;
    [Header("BaudRate")]
    public int baud;

    SerialPort sp;

    public float valueL;
    public float valueR;

    void Start()
    {
        sp = new SerialPort(portName,baud);
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
                print(value);
                if (value != "")
                {
                    string[] sArray = value.Split("~");
                    float.TryParse(sArray[0], out valueL);
                    float.TryParse(sArray[1], out valueR);
                }
            }
        }
        catch (System.Exception)
        {

        }
    }

    void OnApplicationQuit()
    {
        sp.Close();
    }
}
