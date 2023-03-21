using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkiTest : MonoBehaviour
{
    [Header("·Æ³·ªOª«¥ó")]
    public GameObject skiBoard;

    public float moveForce;

    Rigidbody rb;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        PlayerMovement();
    }

    void Update()
    {
        BoardSuck();
    }

    void BoardSuck()//·Æ³·ªO§lªþ¦a­±
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(ray, out hit))
        {
            transform.up = hit.normal;
        }
    }

    void PlayerMovement()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");
        rb.AddForce(Vector3.right * xInput * moveForce);
        rb.AddForce(Vector3.forward * yInput * moveForce);
    }
}
