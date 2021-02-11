using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PongGameController : MonoBehaviour
{
    public Text scoreText;
    public Text promptText;
    public BallController ball;
    public int player1Score;
    public int player2Score;
    Camera gameCamera;


    void Start ()
    {
        gameCamera = Camera.main;
        promptText.enabled = false;
        DisplayScore();
    }
    void Update ()
    {
        Vector3 view = gameCamera.WorldToViewportPoint(ball.transform.position);
        if (view.x < 0)
        {
            player2Score ++;
            DisplayScore();
        }
        else if (view.x > 1)
        {
            player1Score ++;
            DisplayScore();
        }
    }
    void DisplayScore()
    {
        if(player1Score == 7)
        {
            promptText.text = "PLAYER 1 WINS!";
            promptText.enabled = true;
            ball.gameObject.SetActive(false);
        }
        else if(player2Score == 7)
        {
            promptText.text = "PLAYER 2 WINS!";
            promptText.enabled = true;
            ball.gameObject.SetActive(false);
        }
        scoreText.text = player1Score.ToString() + " -" + player2Score.ToString();
        ball.transform.position = Vector3.zero;
    }
}
