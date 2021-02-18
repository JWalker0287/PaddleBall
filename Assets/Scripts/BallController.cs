using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 10;
    public Vector3 direction = Vector3.up;
    Rigidbody body;
    AudioSource placeHolderSound;
    void Start()
    {
        placeHolderSound = GetComponent<AudioSource>();
        body = GetComponent<Rigidbody>();
        SetVelocity();
    }
    public void SetDirection(Vector3 diff)
    {
        diff = diff.normalized;
        body.velocity = diff * speed;
    }
    void OnCollisionEnter(Collision c)
    {
        placeHolderSound.Play();
    }
    public void SetVelocity()
    {
        body.velocity = speed * direction;
    }
}
