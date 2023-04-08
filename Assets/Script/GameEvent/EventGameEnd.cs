using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventGameEnd : MonoBehaviour
{
    private bool Trigger;
    [SerializeField]
    private UserInterfaceSystem UISystem;
    [SerializeField]
    private GameObject Teacher;
    [SerializeField]
    private GameObject Player;
    [Header("Camera")]
    [SerializeField]
    private GameObject Camera_0;
    [SerializeField]
    private GameObject Camera_1;
    [SerializeField]
    private GameObject Camera_2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameEnd();
        }
    }
    public void GameEnd()
    {
        Player.SetActive(false);
        UISystem.PlayMovie();
        OpenNewCamera_12();
        StartCoroutine(waitAndTriggerEvent());

    }
    private IEnumerator waitAndTriggerEvent()
    {
        yield return new WaitForSeconds(1.5f);
        Teacher.SetActive(true);

        yield return new WaitForSeconds(2.0f);
        OPenNewCamera_23();
    }

    private void OpenNewCamera_12()
    {
        Camera_0.SetActive(false);
        Camera_1.SetActive(true);
    }
    private void OPenNewCamera_23()
    {
        Camera_1.SetActive(false);
        Camera_2.SetActive(true);
    }
}
