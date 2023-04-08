using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacherMoveFoward : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private float Force;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        rb.AddForce(this.transform.forward * Force);
    }
}
