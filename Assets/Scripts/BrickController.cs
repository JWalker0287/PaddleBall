using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour
{
    Rigidbody body;
    public GameObject brick;
    BreakoutGameController test;
    public int scorePerBrick = 50;
    void Awake()
    {
        body = GetComponent<Rigidbody>();
        test = GameObject.FindObjectOfType<BreakoutGameController>();
    }
    public void ResetBricks()
    {
        brick.SetActive(true);
    }
    void OnCollisionExit(Collision c)
    {
        test.numBricks --;
        test.score += scorePerBrick;
        brick.SetActive(false);
    }

}
