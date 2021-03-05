using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public ParticleSystem bounceParticles;
    public float speed = 0;
    public float initialSpeed = 10;
    public float speedIncrease = 0;
    public Vector3 direction = Vector3.up;
    public PaddleController paddle;
    public bool autoLaunch = true;
    public Rigidbody body;
    Animator anim;
    AudioSource ballSounds;
    public AudioClip wallHit;
    public AudioClip hitBrick;
    public AudioClip hitPaddle;
    const float maxSpeed = 50;
    void Awake()
    {
        ballSounds = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody>();
        if (autoLaunch) Launch();
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
        speed = initialSpeed;
        body.velocity = direction.normalized * speed;
    }
    public void Stop()
    {
        body.velocity = Vector3.zero;
    }
    public Vector3 GetVelocity()
    {
        return body.velocity;
    }
    public void IncreaseSpeed()
    {
        speed += speedIncrease;
        if (speed > maxSpeed) speed = maxSpeed;
        body.velocity = body.velocity.normalized * speed;
    }
    void OnCollisionEnter(Collision c)
    {
        anim.SetTrigger("impact");

        float frac = (speed / maxSpeed);
        ballSounds.pitch = Random.Range(0.95f,1.05f);
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
        bounceParticles.transform.forward = -c.GetContact(0).normal;
        bounceParticles.Play();
        ballSounds.Play();
        PaddleController paddle = c.gameObject.GetComponent<PaddleController>();
        if (paddle != null)
        {
            IncreaseSpeed();
        }
    }
}
