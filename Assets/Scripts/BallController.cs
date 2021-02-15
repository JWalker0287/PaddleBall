using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 10;
    public Vector3 direction = Vector3.up;
    Rigidbody body;
    AudioSource thud;
    void Start()
    {
        thud = GetComponent<AudioSource>();
        body = GetComponent<Rigidbody>();
        body.velocity = speed * direction;
    }
    public void SetDirection(Vector3 diff)
    {
        diff = diff.normalized;
        body.velocity = diff * speed;
    }
    void OnCollisionEnter(Collision c)
    {
        thud.Play();
    }
    void BallIdleState()
    {
        
    }
}
