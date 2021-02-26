using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BreakoutGameController : MonoBehaviour
{
    public BrickController prefab;
    public Color red;
    public Color green;
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
    public Text highScoreText;
    public int lives = 3;
    public int score = 0;
    int highScore = 0;
    public int numBricks;
    int timesPlayed = 0;
    public BallController ball;
    public PaddleController paddle;
    Camera gameCamera;
    public bool preGame = true;
    public Animator canvasAnim;
    public AudioSource gameSound;
    public AudioClip loseLife;
    public AudioClip winNoise;
    public AudioClip startNoise;

    void Start()
    {
        gameCamera = Camera.main;
        SpawnBricks();
        Setup();
    }
    void Setup()
    {
        //bricks.DestroyBricks();
        timesPlayed = 0;
        promptText.enabled = false;
        ball.gameObject.SetActive(true);
        preGame = true;
        numBricks = bricks.Length;
        UpdateLives();
        BrickReset();
    }
    void Update()
    {
        if (lives == 0)
        {
           Lose();
        }
        else if (numBricks == 0)
        {
            Win();
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
            canvasAnim.SetTrigger("LifeLost");
            gameSound.clip = loseLife;
            gameSound.Play();
        }
        UpdateLives();

    }
    void UpdateScore()
    {
        scoreText.text = "Score: " + score.ToString();
        if(score >= highScore)
        {
            highScore = score;
        }
            highScoreText.text = "Highscore: " + highScore.ToString();
    }
    void Win()
    {
        if (timesPlayed == 0)
        {
            gameSound.clip = winNoise;
            gameSound.Play();
            timesPlayed ++;
        }
        promptText.color = green;
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
        promptText.color = red;
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
            gameSound.clip = startNoise;
            gameSound.Play();
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
                else
                {
                    color.material.SetColor("_Color",Color.blue);
                    g.scorePerBrick = 50;
                }
            }
        }
        bricks = FindObjectsOfType<BrickController>();
        numBricks = bricks.Length;
    }
    void BrickReset()
    {
        for(int i = 0;i < bricks.Length;i++)
        {
            bricks[i].ResetBricks();
        }
    }
    void UpdateLives()
    {
        lifeText.text = "";
        for(int i = 0; i < lives; i ++)
        {
            lifeText.text += " B";
        }
    }
}
