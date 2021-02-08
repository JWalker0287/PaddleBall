using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{

    public string axisName = "Horizontal";
    public Vector3 velocity = Vector3.right;
    void Update()
    {
        float joy = Input.GetAxisRaw(axisName);
        transform.position += velocity * joy * Time.deltaTime;
    }
}
