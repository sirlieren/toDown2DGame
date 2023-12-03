using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagment : MonoBehaviour
{
    public AudioSource music;
    public GameObject pauseCanvas;

    public TextMeshProUGUI closeSongTxt;

    int musicBool=1;
    bool isPaused = false;

    public charController cC;

    private void Start()
    {
       
        if(PlayerPrefs.GetInt("musicOn")==1|| PlayerPrefs.GetInt("musicOn")==0)
            musicBool = PlayerPrefs.GetInt("musicOn");
        print(musicBool);
        if (musicBool==0)
            music.enabled = false;
        else
            music.enabled = true;
    }
    public void tryAgain()
    {
        SceneManager.LoadScene(0);
    }

    public void songButton()
    {
        if (musicBool == 0)
        {
            PlayerPrefs.SetInt("musicOn", 1);
            musicBool = PlayerPrefs.GetInt("musicOn");
            music.enabled = true;
            print("musicEnable");
            closeSongTxt.text = "Music On";

        }

        else if (musicBool == 1)
        {
            PlayerPrefs.SetInt("musicOn", 0);
            musicBool = PlayerPrefs.GetInt("musicOn");
            music.enabled = false;
            print("musicDisable");
            closeSongTxt.text = "Music Off";

        }
        else
            print("w");
        

        
           

    }

    public void pauseGame()
    {
        if(isPaused)
        {
            pauseCanvas.SetActive(false);
            Time.timeScale = 1;
            isPaused = false;
        }
        else
        {
            pauseCanvas.SetActive(true);
            isPaused = true;        
            Time.timeScale = 0;
        }
    }
    
    public void startGame()
    {
        
    }

}
 