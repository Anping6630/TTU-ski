using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System.Threading.Tasks;
public class UserInterfaceSystem : MonoBehaviour
{
    [SerializeField]
    private PlayerInputManager playerInput;
    [SerializeField]
    private Animator CurtainAnimator;
    [SerializeField]
    private GameObject PlayerUI;
    [SerializeField]
    private GameObject GameStart;
    [Header("Camera")]
    [SerializeField]
    private GameObject playerCamera;
    [SerializeField]
    private GameObject newCamera;
    [Header("Time")]
    [SerializeField]
    private TMP_Text TimeText;
    [SerializeField]
    private int CountDownSecond;
    private int CountDownMinute;
    private bool stopCountDown;
    private bool startCountDown;
    private void Start()
    {
        ActiveGameStartSystem();
    }
    private void Update()
    {
        displayTime();
    }
    public void PlayMovie()
    {
        CancelPlayerControl();
        CancelPlayerUI();
        OpenCurtain();
    }
    private void CancelPlayerControl()
    {
        playerInput.enabled = false;
    }
    private void OpenCurtain()
    {
        CurtainAnimator.Play("ToOpen");
    }
    private void CloseCurtain()
    {
        CurtainAnimator.Play("ToClose");
    }
    private void CancelPlayerUI()
    {
        PlayerUI.SetActive(false);
    }
    private void ActiveGameStartSystem()
    {
        GameStart.SetActive(true);
    }
    public async void CountDownSystem()
    {
        if(!startCountDown)
        {
            int allSecond = CountDownSecond;
            CountDownCaculate();
            ToCountDown();
            await Task.Delay(allSecond * 1000);
            CountDownFinish();
            startCountDown = true;
        }
    }
    private void CountDownCaculate()
    {
        CountDownMinute = CountDownSecond / 60;
        CountDownSecond = CountDownSecond % 60;
    }
    private async void ToCountDown()
    {
        while(CountDownMinute > 0 || CountDownSecond > 0)
        {
            ToCountDownCarry();
            CountDownSecond -= 1;
            await Task.Delay(1000);
        }
    }
    private void ToCountDownCarry()
    {
        if (CountDownSecond <= 0 && CountDownMinute > 0)
        {
            CountDownSecond = 60;
            CountDownMinute -= 1;
        }
    }
    private void CountDownFinish()
    {
        Debug.Log("GameEnd");
    }
    private void displayTime()
    {
        string second = "";
        string minute = "";
        if (CountDownSecond <  10) second = "0" + CountDownSecond.ToString("");
        if (CountDownSecond >= 10) second = CountDownSecond.ToString("");
        if (CountDownMinute <  10) minute = "0" + CountDownMinute.ToString("");
        if (CountDownMinute >= 10) minute = CountDownMinute.ToString("");
        TimeText.text = minute + " : " + second;
    }

}
