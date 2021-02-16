using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
public GameObject prefab;
    public int width;
    public int height;
    public float horizontalSpacing;
    public float verticalSpacing;
    public float bricksXPos;
    public float bricksYPos;
    MeshRenderer color;
    public void SpawnBricks()
    {
        for(int i = 0;i < width; i++)
        {
            for (int j = 0;j < height; j++)
            {
                GameObject g = Instantiate(prefab);
                g.transform.position = new Vector3(i * horizontalSpacing + bricksXPos,j*verticalSpacing + bricksYPos, 0);
                color = g.GetComponentInChildren<MeshRenderer>();
                if(j >= 5)
                {
                    color.material.SetColor("_Color",Color.red);

                }
                else if (j >= 4)
                {
                    //color = g.GetComponent<MeshRenderer>();
                    color.material.SetColor("_Color",Color.yellow);
                }
                else if (j >= 2)
                {
                    //color = g.GetComponent<MeshRenderer>();
                    color.material.SetColor("_Color",Color.green);
                }
            }
        }
    }
    public void DestroyBricks()
    {
        for(int i = 0;i < 78; i++)
        {
            BrickController d = GameObject.FindObjectOfType<BrickController>();;
            Destroy(d);
            Debug.Log("Brick Destroyed");
        }
    }

}
