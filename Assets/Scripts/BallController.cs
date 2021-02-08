using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Vector3 initialVelocity = Vector3.up;
    Rigidbody body;
    void Start()
    {
        body = GetComponent<Rigidbody>();
        body.velocity = initialVelocity;
    }
}
