using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PongGameController : MonoBehaviour
{
    public Text player1ScoreText;
    public Text player2ScoreText;
    public Color red;
    public Color blue;
    public Text promptText;
    public BallController ball;
    public int player1Score;
    public int player2Score;
    public Animator anim;
    bool preGame = true;
    Camera gameCamera;
    public AudioSource gameSound;


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
        preGame = true;
        //ball.Launch();
        DisplayScore();
    }
    void Update ()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            SceneManager.LoadScene("Menu");
        }
        if (preGame && player1Score < 7 && player2Score < 7 && ball.gameObject.activeSelf)
        {
            UpdatePreGame();
        }
        else if (player1Score < 7 && player2Score < 7 && ball.gameObject.activeSelf)
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
            anim.SetTrigger("Player2Scored");
            ball.direction.x = 1;
            DisplayScore();
        }
        else if (view.x > 1)
        {
            player1Score ++;
            anim.SetTrigger("Player1Scored");
            ball.direction.x = -1;
            DisplayScore();
        }

    }
    void UpdateGameOver()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Setup();   
            player1Score = 0;
            player1Score = 0;
            Debug.Log("here");
        }
        else
        {
        if(player1Score == 7)
        {
            promptText.color = blue;
            promptText.text = "PLAYER 1 WINS!";
            ResetScore();
        }
        else if(player2Score == 7)
        {
            promptText.color = red;
            promptText.text = "PLAYER 2 WINS!";
            ResetScore();
        }
        }
    }
    void DisplayScore()
    {
        player1ScoreText.text = player1Score.ToString();
        player2ScoreText.text = player2Score.ToString();
        ball.transform.position = Vector3.zero;
        ball.body.velocity = Vector3.zero;
        preGame = true;
        //ball.Launch();
    }
    void UpdatePreGame()
    {
        if (Input.GetButtonDown("Jump"))
        {
            ball.Launch();
            preGame = false;
            gameSound.Play();
        }
    }
    void ResetScore()
    {
        player1Score = 0;
        player2Score = 0;
        promptText.enabled = true;
        ball.gameObject.SetActive(false);
    }
}
