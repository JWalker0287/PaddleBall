using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakoutGameController : MonoBehaviour
{
    public BallController ball;
    Camera gameCamera;

    void Start()
    {
        gameCamera = Camera.main;
    }
    void Update()
    {
        Vector3 view = gameCamera.WorldToViewportPoint(ball.transform.position);
        if (view.y < 0)
        {
            ball.transform.position = Vector3.zero;
        }
    }
}
