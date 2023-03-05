using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpeedTest : MonoBehaviour
{
    private Singleton singleton;
    private GameObject player;
    private Rigidbody playerRigidbody;
    [SerializeField]
    private PlayerInputManager playerInput;

    private void Awake()
    {
        player = this.gameObject;
        playerRigidbody = GetComponent<Rigidbody>();
        singleton = Singleton.singleton;
        playerInput = singleton.playerInputManager;
    }

    private void Update()
    {
        MoveForwardTest();
    }
    private void MoveForwardTest()
    {
        playerRigidbody.velocity = player.transform.forward * playerInput.Vertical;
    }
}
