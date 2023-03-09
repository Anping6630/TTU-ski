using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSki : MonoBehaviour
{
    private Rigidbody rb;
    private Singleton singleton;
    private PlayerInputManager inputManager;
    private Vector3 playerPosition;
    private Vector3 raycastDirection;
    private Ray ray;
    private RaycastHit hit;

    [Header("Jump")]
    public float JumpForce;
    public bool IsGround;
    public float MaxDistanceLength;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        singleton = Singleton.singleton;
        inputManager = singleton.playerInputManager;
        inputManager.OnSpacePressed += jump;

    }

    private void Update()
    {
        checkGround();
        getPlayerPosition();
    }
    private void jump()
    {
        Vector3 jumpDirection = this.transform.position + transform.up;
        if(IsGround==true)
        {
            rb.AddForce(jumpDirection * JumpForce, ForceMode.Impulse);
            Debug.Log("Player joumping");
        }
    }
    private bool checkGround()
    {
        checkGroundRay();
        if (Physics.Raycast(ray,out hit))
        {
            if(hit.collider.CompareTag("ground"))
            {
                IsGround = true;
                return true;
            }
        }
        IsGround = false;
        return false;
    }
    private void checkGroundRay()
    {
        raycastDirection = playerPosition + Vector3.down;
        ray = new Ray(playerPosition, raycastDirection* MaxDistanceLength);
    }
    private void getPlayerPosition()
    {
        playerPosition = transform.position;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down*MaxDistanceLength);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.forward);

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, this.transform.position + transform.up);
    }
}
