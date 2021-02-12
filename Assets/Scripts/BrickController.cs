using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour
{
    Rigidbody body;
    public GameObject brick;
    public BreakoutGameController test;
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }
    void OnCollisionExit(Collision c)
    {
        test.numBricks --;
        brick.SetActive(false);
    }

}
