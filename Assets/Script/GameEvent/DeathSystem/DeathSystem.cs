using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class DeathSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject DeathMenu;
    [SerializeField]
    private GameObject FrostEffect;
    [Header("DeathAnimationPlayTime")]
    [SerializeField]
    private int deathTime;
    public async void PlayerDies()
    {
        Debug.Log("ª±®a¦º¤`");
        FrostEffect.SetActive(true);
        await Task.Delay(deathTime * 1000);
        OpenMenu();
    }
    private void OpenMenu()
    {
        DeathMenu.SetActive(true);
        Time.timeScale = 0;
    }
}
