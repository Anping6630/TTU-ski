using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UserInterfaceSystem : MonoBehaviour
{
    [SerializeField]
    private PlayerInputManager playerInput;
    [SerializeField]
    private Animator CurtainAnimator;
    [SerializeField]
    private GameObject PlayerUI;
    [Header("Camera")]
    [SerializeField]
    private GameObject playerCamera;
    [SerializeField]
    private GameObject newCamera;
    private void Start()
    {
        //PlayMovie();
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
}
