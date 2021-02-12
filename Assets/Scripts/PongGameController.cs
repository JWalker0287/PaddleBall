using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PongGameController : MonoBehaviour
{
    public Button playAgain;
    public Text scoreText;
    public Text promptText;
    public BallController ball;
    public int player1Score;
    public int player2Score;
    Camera gameCamera;


    void Start ()
    {
        gameCamera = Camera.main;
        DisplayScore();
        promptText.enabled = false;
        playAgain.gameObject.SetActive(false);
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
            ResetScore();
        }
        else if(player2Score == 7)
        {
            promptText.text = "PLAYER 2 WINS!";
            ResetScore();
        }
        scoreText.text = player1Score.ToString() + " - " + player2Score.ToString();
        ball.transform.position = Vector3.zero;
    }
    void ResetScore()
    {
        player1Score = 0;
        player2Score = 0;
        promptText.enabled = true;
         playAgain.gameObject.SetActive(true);
        ball.gameObject.SetActive(false);
    }
}
