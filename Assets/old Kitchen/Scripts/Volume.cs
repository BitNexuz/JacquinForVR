using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volume : MonoBehaviour
{
    public Move player;
    AudioSource audioS;
    int Cp;

    public void Start()
    {
        audioS = GetComponent<AudioSource>();
    }
    public void Update()
    {
        if(player.Currentpoint == 0 || player.Currentpoint == 4)
        {
            audioS.volume = 0f;
        }
        if (player.Currentpoint == 1 || player.Currentpoint == 3)
        {
            audioS.volume = 0.2f;
        }
        if (player.Currentpoint == 2)
        {
            audioS.volume = 1;
        }
        
    }
}
