using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class ArduinoRead : MonoBehaviour
{
    public SerialPort sp;
    float i;

    void Start()
    {
        sp = new SerialPort("COM6",9600);//根據裝置調整
        try
        {
            sp.Open();
            print("成功打開");
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
                    float.TryParse(sp.ReadExisting(), out i); //轉成float
                    Debug.Log(value);
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
