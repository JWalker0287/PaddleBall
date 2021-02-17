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
        Setup();
    }
    void Setup()
    {
        promptText.enabled = false;
        player1Score = 0;
        player2Score = 0;
        ball.gameObject.SetActive(true);
        ball.SetVelocity();
        DisplayScore();
    }
    void Update ()
    {
        if (ball.gameObject.activeSelf)
        {
            UpdatePlaying();
        }
        else
        {
            UpdateGameOver();
        }
    }
    void UpdatePlaying()
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
    void UpdateGameOver()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Setup();
        }
    }
    void DisplayScore()
    {
        if(player1Score == 7)
        {
            promptText.color = Color.blue;
            promptText.text = "PLAYER 1 WINS!";
            ResetScore();
        }
        else if(player2Score == 7)
        {
            promptText.color = Color.red;
            promptText.text = "PLAYER 2 WINS!";
            ResetScore();
        }
        scoreText.text = player1Score.ToString() + " - " + player2Score.ToString();
        ball.transform.position = Vector3.zero;
        ball.SetVelocity();
    }
    void ResetScore()
    {
        player1Score = 0;
        player2Score = 0;
        promptText.enabled = true;
        ball.gameObject.SetActive(false);
    }
}
