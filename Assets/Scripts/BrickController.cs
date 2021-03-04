using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour
{
    Rigidbody body;
    public GameObject brick;
    public PowerUpController powerPrefab;
    public Color red;
    public Color purple;
    BreakoutGameController gameController;
    public int scorePerBrick = 50;
    AudioSource brickBreak;
    void Awake()
    {
        brickBreak = GetComponent<AudioSource>();
        body = GetComponent<Rigidbody>();
        gameController = GameObject.FindObjectOfType<BreakoutGameController>();
    }
    public void ResetBricks()
    {
        //brick.SetActive(true);
        Destroy(brick);
    }
    void OnCollisionExit(Collision c)
    {
        gameController.BrickBreakSound();
        int i = Random.Range(1,40);
        Debug.Log(i);
        if(i == 1)
        {
           PowerUpController p = Instantiate<PowerUpController>(powerPrefab);
            p.transform.position = transform.position;
        }
        gameController.numBricks --;
        gameController.score += scorePerBrick;
        gameController.canvasAnim.SetTrigger("ScoreUp");

        brick.SetActive(false);
    }

}
