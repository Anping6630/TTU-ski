using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityTestTool : MonoBehaviour
{
    [SerializeField]
    private bool timeTest;
    [SerializeField]
    private bool StopTime;

    private void Update()
    {
        toTimeTest();
        timeSystem();
    }

    void toTimeTest()
    {
        if(timeTest)
        {
            Debug.Log("realTime:"+Time.realtimeSinceStartup);
            Debug.Log("unscaledDeltatime" + Time.unscaledDeltaTime);
        }
    }    
    void timeSystem()
    {
        toStopTime();
        ActiveTime();
    }
    void toStopTime()
    {
        if(StopTime)
        {
            Time.timeScale = 0;
        }
    }
    void ActiveTime()
    {
        if(!StopTime)
        {
            Time.timeScale = 1;
            Debug.Log("ActiveTime");
        }
    }
}
