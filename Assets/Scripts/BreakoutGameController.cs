using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public int level = 1;
    public int lives = 3;
    public int score = 0;
    public int highScore = 0;
    public int numBricks;
    public float startingBricks;
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
    public AudioClip brickBreak;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("highScore");
        highScoreText.text = "Highscore: "+ highScore.ToString();
        gameCamera = Camera.main;
        //SetLevel();
        //SpawnBricks();
        //Setup();
        timesPlayed = 0;
        promptText.enabled = false;
        ball.gameObject.SetActive(true);
        preGame = true;
        numBricks = bricks.Length;
        SetLevel();
        SpawnBricks();
        //BrickReset();
        //SpawnBricks();
        UpdateLives();
    }
    void Setup()
    {
        //bricks.DestroyBricks();
        timesPlayed = 0;
        promptText.enabled = false;
        ball.gameObject.SetActive(true);
        preGame = true;
        numBricks = bricks.Length;
        BrickReset();
        SetLevel();
        SpawnBricks();
        UpdateLives();
        //numBricks = 0;
    }
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            SceneManager.LoadScene("Menu");
        }
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
            ball.speed = 0;
            ball.body.velocity = Vector3.zero;
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
            PlayerPrefs.SetInt("highScore", highScore);
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
            level ++;
            Setup();
        }
    }
    void Lose()
    {
        promptText.color = red;
        promptText.text = "You    Lose";
        promptText.enabled = true;
        ball.gameObject.SetActive(false);
        if (Input.GetButtonDown("Jump"))
        {
            lives = 3;
            level = 1;
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
            ball.Launch();
            gameSound.clip = startNoise;
            gameSound.Play();
        }
        Vector3 paddlePos = paddle.transform.position;
        paddlePos.y = -7.8f;
        ball.transform.position = paddlePos;
    }
    void SpawnBricks()
    {
        int count = 0;
        for(int i = 0;i < width; i++)
        {
            for (int j = 0;j < height; j++)
            {
                BrickController g = Instantiate<BrickController>(prefab);
                g.transform.position = new Vector3(i * horizontalSpacing + bricksXPos,j*verticalSpacing + bricksYPos, 0);
                color = g.GetComponentInChildren<MeshRenderer>();
                bricks[count] = g;
                count ++;
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

        //bricks = FindObjectsOfType<BrickController>();
        //numBricks = bricks.Length;
    }
    void BrickReset()
    {
        for(int i = 0;i < bricks.Length;i++)
        {
            bricks[i].ResetBricks();
        }
        //SpawnBricks();
    }
    void UpdateLives()
    {
        lifeText.text = "";
        for(int i = 0; i < lives; i ++)
        {
            lifeText.text += " B";
        }
    }
    void SetLevel()
    {
        if(level == 1)
        {
            height = 2;
            width = 4;
            bricksXPos = -6;
        }
        else if (level == 2)
        {
            height = 2;
            width = 13;
            bricksXPos = -18;
        }
        else if (level == 3)
        {
            height = 4;
            width = 13;
            bricksXPos = -18;
        }
        else if (level == 4)
        {
            height = 5;
            width = 13;
            bricksXPos = -18;
        }
        else if (level >= 5)
        {
            height = 6;
            width = 13;
            bricksXPos = -18;
        }
        numBricks = height * width;
        startingBricks = numBricks;
        bricks = new BrickController[numBricks];
    }
    public void BrickBreakSound()
    {
        gameSound.clip = brickBreak;
        gameSound.Play();
    }
}
