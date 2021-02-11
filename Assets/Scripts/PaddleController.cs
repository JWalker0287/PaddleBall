using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{

    public string axisName = "Horizontal";
    public Vector3 velocity = Vector3.right;
    Camera gameCamera;
    void Start()
    {
        gameCamera = Camera.main;
    }
    void Update()
    {
        float joy = Input.GetAxisRaw(axisName);
        transform.position += velocity * joy * Time.deltaTime;

        Vector3 view = gameCamera.WorldToViewportPoint(transform.position);
        if (view.y > 1)
        {
            view.y = 1;
        }
        else if (view.y < 0)
        {
            view.y = 0;
        }
         if (view.x > 1)
        {
            view.x = 1;
        }
        else if (view.x < 0)
        {
            view.x = 0;
        }
        transform.position = gameCamera.ViewportToWorldPoint(view);

    }
}
