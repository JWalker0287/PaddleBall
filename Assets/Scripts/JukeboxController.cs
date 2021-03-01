using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JukeboxController : MonoBehaviour
{
    public BreakoutGameController gameController;
    public AudioSource track1;
    public AudioSource track2;
    public AudioSource track3;
    public AudioSource track4;
    void Start()
    {
        track1.volume = 1;
    }
    void Update()
    {
        if (gameController.numBricks <= 5)
        {
            track2.volume = 1;
            track3.volume = 0;
            track4.volume = 1;
        }
        else if (gameController.numBricks <= 19)
        {
            track2.volume = 0;
            track3.volume = 0;
            track4.volume = 1;
        }
        else if (gameController.numBricks <= 39)
        {
            track2.volume = 0;
            track3.volume = 1;
            track4.volume = 0;
        }
        else if (gameController.numBricks <= 58)
        {
            track2.volume = 1;
            track3.volume = 0;
            track4.volume = 0;
        }
        else
        {
            track2.volume = 0;
            track3.volume = 0;
            track4.volume = 0;
        }
    }

}
