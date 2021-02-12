using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BreakoutGameController : MonoBehaviour
{
    public Text promptText;
    public int numBricks = 78;
    public BallController ball;
    Camera gameCamera;

    void Start()
    {
        gameCamera = Camera.main;
        promptText.enabled = false;
    }
    void Update()
    {
        Vector3 view = gameCamera.WorldToViewportPoint(ball.transform.position);
        if (view.y < 0)
        {
            ball.transform.position = Vector3.zero;
        }
        if (numBricks == 0)
        {
            Win();
        }
    }
    void Win()
    {
        promptText.enabled = true;
        ball.enabled = false;
    }
}
