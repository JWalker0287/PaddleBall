using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour
{
    Rigidbody body;
    public GameObject brick;
    BreakoutGameController test;
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
        brick.SetActive(false);
    }

}
