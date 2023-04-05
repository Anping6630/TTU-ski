using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSki : MonoBehaviour
{
    private Singleton singleton;
    private PlayerInputManager playerInput;
    private GameObject skiBoard;
    [SerializeField]
    private Rigidbody rb;
    private float skiController_Left;
    private float skiController_Right;
    private float skirotation;
    [Header("滑雪調整")]
    [SerializeField]
    private float moveForce;
    private float moveSpeed;
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private float MaxSpeed;
    [Header("抓地測試")]
    [SerializeField]
    private GameObject RotationAD;
    [SerializeField]
    private GameObject RotationWS;
    void Start()
    {
        //rb = this.GetComponent<Rigidbody>();
        singleton = Singleton.singleton;
        playerInput = singleton.playerInputManager;
        skiBoard = this.gameObject;
    }

    void Update()
    {
        rotationCalculate();
        BoardSuck();
        skiRotate();
        setControllerValue();
        moveForward();
        speedLimiter();
    }
    void moveForward()
    {
        moveCalculate();
        rb.AddForce(transform.forward * moveSpeed, ForceMode.Force);
    }
    void moveCalculate()
    {
        moveSpeed = moveForce * (skiController_Left + skiController_Right);
    }
    void BoardSuck()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(ray, out hit))
        {
            RotationWS.transform.up = hit.normal;
        }
    }
    void rotationCalculate()
    {
        skirotation = skiController_Left - skiController_Right;
    }
    void skiRotate()
    {
        RotationAD.transform.Rotate(Vector3.up, skirotation * rotationSpeed * Time.deltaTime);
    }
    void speedLimiter()
    {
        float velocity_X = rb.velocity.x;
        float velocity_Y = rb.velocity.y;
        float velocity_Z = rb.velocity.z;
        if (rb.velocity.x > MaxSpeed) velocity_X = MaxSpeed;
        if (rb.velocity.y > MaxSpeed) velocity_Y = MaxSpeed;
        if (rb.velocity.z > MaxSpeed) velocity_Z = MaxSpeed;
        rb.velocity = new Vector3(velocity_X, velocity_Y, velocity_Z);

    }
  
    void setControllerValue()
    {
        skiController_Left = playerInput.Controller_Left;
        skiController_Right = playerInput.Controller_Right;
    }

}
