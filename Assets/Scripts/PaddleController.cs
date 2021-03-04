using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{

    public string axisName = "Horizontal";
    public Vector3 velocity = Vector3.right;
    Vector3 pos1;
    Vector3 pos2;
    Vector3 arbitraryName;
    BallController ball;
    public bool autoPlay = false;
    Camera gameCamera;
    public BreakoutGameController carl;
    public AudioSource paddleSound;
    Animator anim;
    Rigidbody body;
    void Start()
    {
        body = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        ball = FindObjectOfType<BallController>();
        gameCamera = Camera.main;
    }
    void Update()
    {
        float dir = 0;
        if (autoPlay)
        {
            Vector3 diff = ball.transform.position - transform.position;
            dir = Vector3.Dot(diff.normalized, velocity.normalized);
        }
        else
        {
            dir = Input.GetAxisRaw(axisName);
        }
        pos1 = transform.position;
        transform.position += velocity * dir * Time.deltaTime;
        pos2 = transform.position;
        arbitraryName = pos2-pos1;
        anim.SetFloat("Speed", arbitraryName.magnitude * 4);
        //Debug.Log(arbitraryName.magnitude);

        Vector3 view = gameCamera.WorldToViewportPoint(transform.position);
        if (view.y > 0.95f)
        {
            view.y = 0.95f;
        }
        else if (view.y < 0.05f)
        {
            view.y = 0.05f;
        }
         if (view.x > 0.95f)
        {
            view.x = 0.95f;
        }
        else if (view.x < 0.05f)
        {
            view.x = 0.05f;
        }
        transform.position = gameCamera.ViewportToWorldPoint(view);
    }
    void OnCollisionEnter(Collision c)
    {
        BallController ball = c.gameObject.GetComponent<BallController>();
        if (ball == null) return;

        anim.SetTrigger("Collision");
        Vector3 diff = ball.transform.position * 5 - transform.position *5;
        ball.SetDirection(diff + ball.GetVelocity());
    }
    void OnTriggerEnter(Collider c)
    {
        PowerUpController powerUp = c.gameObject.GetComponent<PowerUpController>();
        if (powerUp == null) return;
        if (powerUp.powerupType == "xtraLife")
        {
            carl.lives ++;
        }
        Destroy(c.gameObject);
        paddleSound.Play();
    }
}