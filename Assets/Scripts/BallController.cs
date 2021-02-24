using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public ParticleSystem bounceParticles;
    public float speed = 10;
    public float initialSpeed = 10;
    public float speedIncrease = 0;
    public Vector3 direction = Vector3.up;
    Rigidbody body;
    Animator anim;
    AudioSource placeHolderSound;
    void Start()
    {
        placeHolderSound = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody>();
        SetVelocity();
    }
    void Update()
    {
        anim.SetFloat("Speed", body.velocity.magnitude / 50);
        transform.right = body.velocity.normalized * speed;
    }
    public void SetDirection(Vector3 diff)
    {
        body.velocity = diff.normalized * speed;
    }
    public void Launch()
    {

    }
    public void Stop()
    {
        body.velocity = Vector3.zero;
    }
    void OnCollisionEnter(Collision c)
    {
        anim.SetTrigger("impact");

        //float frac;
        //placeHolderSound.pitch = Random.Range(1.0f,1.5f);
        placeHolderSound.Play();
    }
    public void SetVelocity()
    {
        body.velocity = speed * direction;
    }
}
