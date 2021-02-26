using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    public GameObject me;
    Camera gameCamera;
    public MeshRenderer color;
    public Color red;
    public Color purple;
    public string powerupType = "";
    void Awake()
    {
        //int r = Random.Range(1,10);

        gameCamera = Camera.main;
        //if (r <= 2)
        //{
            color.material.SetColor("_Color", red);
            powerupType = "xtraLife";
        //}
        //else
        //{
          //  color.material.SetColor("_Color", purple);
          //  powerupType = "normalPowerUp";
        //}
    }
    void Update()
    {
        Vector3 view = gameCamera.WorldToViewportPoint(me.transform.position);
        if (view.y < 0)
        {
            Destroy(me);
        }
    }

    
}
