using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Vector3 initialVelocity = Vector3.up;
    Rigidbody body;
    AudioSource thud;
    void Start()
    {
        thud = GetComponent<AudioSource>();
        body = GetComponent<Rigidbody>();
        body.velocity = initialVelocity;
    }
    void OnCollisionEnter(Collision c)
    {
        thud.Play();
    }
}
