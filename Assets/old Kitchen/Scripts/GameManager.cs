
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum EnumPlayerState
{
    LIG_LIG,
    DESL_LIG,
    DESL_DESL,
}


public class GameManager : MonoBehaviour
{
    public bool statusFreezer, statusGame;
    public bool f1 = true, f2 = true;
    public Slider slider;
    public Text _dindinText;
    Timer tempo;
    public EnumPlayerState state;
    public float score = 0;

    
    // Start is called before the first frame update
    void Start()
    {
        statusFreezer = true;
        statusGame = true;
        tempo = FindObjectOfType<Timer>();
        
        state = EnumPlayerState.LIG_LIG;
        _dindinText.text = score.ToString("F2");
        
        

    }

    // Update is called once per frame
    void Update()
    {
        
        if(slider.value == 0)
        {
            gameOver();
        }
        switch(state)
        {
            case EnumPlayerState.LIG_LIG:
                statusFreezer = true;
                slider.value -= 1 * Time.deltaTime;
                if(f1 == false || f2 == false)
                {
                    state = EnumPlayerState.DESL_LIG;
                }
                break;

            case EnumPlayerState.DESL_LIG:
                statusFreezer = false; 
                score += 0.5f * Time.deltaTime;
                slider.value -= 1 * Time.deltaTime / 2;
                _dindinText.text = score.ToString("F2");
                if (f1 == true && f2 == true)
                {
                    state = EnumPlayerState.LIG_LIG;
                }
                if (f1 == false && f2 == false)
                {
                    state = EnumPlayerState.DESL_DESL;
                }
                break;

            case EnumPlayerState.DESL_DESL:
                 statusFreezer = false;
                 score += 0.5f * Time.deltaTime * 2;
                 _dindinText.text = score.ToString("F2");
                if(f1 == true || f2 == true)
                {
                    state = EnumPlayerState.DESL_LIG;
                }
                break;

        }
        
    }
    public void gameOver()
    {
        Highscores();
        SceneManager.LoadScene("gameOver1");

    }
    public void toMenu()
    {

        SceneManager.LoadScene("Menu");
    }
    public void playAgain()
    {

        SceneManager.LoadScene("HelloVR");
    }
    public void end()
    {
        Application.Quit();
    }
    public void Highscores()
    {
        if (score > PlayerPrefs.GetFloat("Hscore"))
        {
            PlayerPrefs.SetFloat("Hscore", score);
        }
        if(tempo.timer > PlayerPrefs.GetFloat("Htime"))
        {
            PlayerPrefs.SetFloat("Htime", tempo.timer);
        }
    }
}
