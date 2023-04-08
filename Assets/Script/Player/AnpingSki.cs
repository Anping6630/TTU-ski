using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnpingSki : MonoBehaviour
{
    Rigidbody rb;
    public bool isGround;//觸地偵測
    public float jumpForce;
    public float slideForce;
    public float moveForce;

    float currentSpeed;

    void Start()
    {
        currentSpeed = 0;
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        if (isGround)
        {
            SlideForce();
            BoardSuck();
            if (Input.GetKeyDown("space"))
            {
                rb.AddForce(transform.up * jumpForce);
            }
            if (Input.GetKey("w"))
            {
                rb.AddForce(transform.forward * moveForce);
            }
            if (Input.GetKey("a"))
            {
                rb.AddForce(transform.right * -moveForce);
            }
            if (Input.GetKey("d"))
            {
                rb.AddForce(transform.right * moveForce);
            }
        }
        else
        {
            rb.AddForce(Vector3.down*9.8f);
        }
    }

    void SlideForce()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 velocityDirec = hit.normal + Vector3.down;
            rb.AddForce(velocityDirec * slideForce * currentSpeed);
            if (velocityDirec.z < 0)
            {
                currentSpeed -= 0.1f;
            }
            else
            {
                currentSpeed += 0.1f;
            }
            print(hit.normal + Vector3.down);
            Debug.DrawLine(transform.position, hit.normal + Vector3.down, Color.blue);
        }
    }

    void BoardSuck()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(ray, out hit))
        {
            transform.up = hit.normal;
        }
        Debug.DrawLine(ray.origin, hit.point, Color.red);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isGround = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isGround = false;
        }
    }
}
