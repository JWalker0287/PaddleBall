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
    public PaddleController paddle;
    Rigidbody body;
    Animator anim;
    AudioSource ballSounds;
    public AudioClip wallHit;
    public AudioClip hitBrick;
    public AudioClip hitPaddle;
    void Start()
    {
        ballSounds = GetComponent<AudioSource>();
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
        ballSounds.pitch = Random.Range(0.9f,1.0f);
       // Debug.Log(c.gameObject);
        PaddleController thing = c.gameObject.GetComponent<PaddleController>();
        BrickController brick = c.gameObject.GetComponent<BrickController>();
        if (thing != null)
        {
            ballSounds.clip = hitPaddle;
        }
        else if(brick != null)
        {
            ballSounds.clip = hitBrick;
        }
        else
        {
            ballSounds.clip = wallHit;
        }
        bounceParticles.Play();
        ballSounds.Play();
    }
    public void SetVelocity()
    {
        body.velocity = speed * direction;
    }
}
