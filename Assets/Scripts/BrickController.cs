using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour
{
    Rigidbody body;
    public GameObject brick;
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }
    void OnCollisionExit(Collision c)
    {
        brick.SetActive(false);
    }

}
