using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BreakoutGameController : MonoBehaviour
{
    public Text promptText;
    public Text lifeText;
    public Text loseText;
    public int lives = 3;
    public int numBricks = 78;
    public BallController ball;
    public PaddleController paddle;
    Camera gameCamera;
    bool preGame = true;


    void Start()
    {
        gameCamera = Camera.main;
        Setup();
    }
    void Setup()
    {
        promptText.enabled = false;
        loseText.enabled = false;
        lives = 3;
        lifeText.text = "Lives: " + lives;
        ball.gameObject.SetActive(true);
        preGame = true;
    }
    void Update()
    {
        if (preGame)
        {
            PreGame();
        }
        else
        {
            if (lives > 0)
            {
                UpdatePlaying();
            }
            else
            {
                Lose();
            }
        }
    }
    void UpdatePlaying()
    {
        Vector3 view = gameCamera.WorldToViewportPoint(ball.transform.position);
        if (view.y < 0)
        {
            ball.transform.position = Vector3.zero;
            preGame = true;
            lives --;
            lifeText.text = "Lives: " + lives.ToString();
        }
        if (numBricks == 0)
        {
            Win();
        }

    }
    void Win()
    {
        promptText.enabled = true;
        ball.gameObject.SetActive(false);
        if (Input.GetButtonDown("Jump"))
        {
            Setup();
        }
    }
    void Lose()
    {
        promptText.text = "You Lose ;(";
        promptText.enabled = true;
        ball.gameObject.SetActive(false);
        if (Input.GetButtonDown("Jump"))
        {
            Setup();
        }
    }
    void PreGame()
    {
        if (Input.GetButtonDown("Jump"))
        {
            preGame = false;
        }
        Vector3 paddlePos = paddle.transform.position;
        paddlePos.y = -5;
        ball.transform.position = paddlePos;
    }
}
