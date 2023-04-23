using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WoodUI : MonoBehaviour
{
    [SerializeField]
    private GameObject woodText;

    void Update()
    {
        woodText.GetComponent<Text>().text = PlayerProgress.wood.ToString();
    }
}
