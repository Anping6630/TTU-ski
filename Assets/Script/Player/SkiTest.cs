using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkiTest : MonoBehaviour
{
    private Singleton singleton;
    private PlayerInputManager playerInput;
    private float skiController_Left;
    private float skiController_Right;
    private float skirotation;
    [Header("滑雪速度")]
    [SerializeField]
    private float rotationSpeed;

    [Header("滑雪板物件")]
    public GameObject skiBoard;

    public float moveForce;
    private float moveRotation;

    Rigidbody rb;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        singleton = Singleton.singleton;
        playerInput = singleton.playerInputManager;
    }

    void FixedUpdate()
    {
        setControllerValue();
        MoveForward_TestTool();
    }
    void Update()
    {
        rotationCalculate();
        //BoardSuck();
        skiRotate();
    }

    void BoardSuck()//滑雪板吸附地面
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(ray, out hit))
        {
            transform.up = hit.normal;
        }
    }

    
    void MoveForward_TestTool() 
    {
        rb.AddForce(transform.forward * moveForce);
    }
    void setControllerValue()
    {
        skiController_Left = playerInput.Controller_Left;
        skiController_Right = playerInput.Controller_Right;
    }
    void rotationCalculate()
    {
        skirotation = skiController_Right - skiController_Left;
    }
    void skiRotate()
    {
        this.transform.Rotate(Vector3.up, skirotation * rotationSpeed * Time.deltaTime);
    }
    #region
    void PlayerMovement()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");
        rb.AddForce(Vector3.right * xInput * moveForce);
        rb.AddForce(Vector3.forward * yInput * moveForce);
    }
    #endregion
}
