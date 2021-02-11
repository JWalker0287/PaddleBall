using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongGameController : MonoBehaviour
{
    public BallController ball;
    public int player1Score;
    public int player2Score;
    Camera gameCamera;


    void Start ()
    {
        gameCamera = Camera.main;
    }
    void Update ()
    {
        Vector3 view = gameCamera.WorldToViewportPoint(ball.transform.position);
        if (view.x < 0)
        {
            player2Score ++;
            Debug.Log("Player 2 Scored");
            ball.transform.position = Vector3.zero;
        }
        else if (view.x > 1)
        {
            player1Score ++;
            Debug.Log("Player 1 Scored");
            ball.transform.position = Vector3.zero;
        }
    }
}
