using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static int wood;
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
