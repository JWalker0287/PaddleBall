using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BreakoutGameController : MonoBehaviour
{
    public BrickController prefab;
    public int width;
    public int height;
    public float horizontalSpacing;
    public float verticalSpacing;
    public float bricksXPos;
    public float bricksYPos;
    MeshRenderer color;
    public BrickController[] bricks;
    public Text promptText;
    public Text lifeText;
    public Text scoreText;
    public int lives = 3;
    public int score = 0;
    public int numBricks;
    public BallController ball;
    public PaddleController paddle;
    Camera gameCamera;
    public bool preGame = true;

    void Start()
    {
        gameCamera = Camera.main;
        SpawnBricks();
        Setup();
    }
    void Setup()
    {
        //bricks.DestroyBricks();
        promptText.enabled = false;
        ball.gameObject.SetActive(true);
        preGame = true;
        numBricks = bricks.Length;
        lifeText.text = "Lives: " + lives;
        Reset();
    }
    void Update()
    {
        if (lives == 0)
        {
           Lose();
        }
        else if (preGame)
        {
            PreGame();
        }
        else
        {
            UpdatePlaying();
        }
    }
    void UpdatePlaying()
    {
        UpdateScore();
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
    void UpdateScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }
    void Win()
    {
        promptText.color = Color.green;
        promptText.text = "You Won!";
        promptText.enabled = true;
        ball.transform.position = Vector3.zero;
        ball.gameObject.SetActive(false);
        if (Input.GetButtonDown("Jump"))
        {
            Setup();
        }
    }
    void Lose()
    {
        promptText.color = Color.red;
        promptText.text = "You Lose :(";
        promptText.enabled = true;
        ball.gameObject.SetActive(false);
        if (Input.GetButtonDown("Jump"))
        {
            lives = 3;
            Setup();
        }
        score = 0;
        UpdateScore();
    }
    void PreGame()
    {
        if (Input.GetButtonDown("Jump"))
        {
            preGame = false;
            ball.SetVelocity();
        }
        Vector3 paddlePos = paddle.transform.position;
        paddlePos.y = -8;
        ball.transform.position = paddlePos;
    }
    void SpawnBricks()
    {
        for(int i = 0;i < width; i++)
        {
            for (int j = 0;j < height; j++)
            {
                BrickController g = Instantiate<BrickController>(prefab);
                g.transform.position = new Vector3(i * horizontalSpacing + bricksXPos,j*verticalSpacing + bricksYPos, 0);
                color = g.GetComponentInChildren<MeshRenderer>();
                if(j >= 5)
                {
                    color.material.SetColor("_Color",Color.red);
                    g.scorePerBrick = 1000;
                }
                else if (j >= 4)
                {
                    color.material.SetColor("_Color",Color.yellow);
                    g.scorePerBrick = 500;
                }
                else if (j >= 2)
                {
                    color.material.SetColor("_Color",Color.green);
                    g.scorePerBrick = 100;
                }
            }
        }
        bricks = FindObjectsOfType<BrickController>();
        numBricks = bricks.Length;
    }
    void Reset()
    {
        for(int i = 0;i < bricks.Length;i++)
        {
            bricks[i].ResetBricks();
        }
        //SpawnBricks();
    }
}
