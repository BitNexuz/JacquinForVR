using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Highscore : MonoBehaviour
{
    // Start is called before the first frame update
    public Text hs, ht;
    public float highscore = 0; 
    public float     HighTime = 0;
    void Start()
    {
        highscore = PlayerPrefs.GetFloat("Hscore");
        HighTime = PlayerPrefs.GetFloat("Htime");
    }

    // Update is called once per frame
    void Update()
    {
        hs.text = highscore.ToString("F2") + " R$";
        ht.text = HighTime.ToString("F0") + " s";
    }
}
