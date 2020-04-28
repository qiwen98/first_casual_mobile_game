using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public bool gameover;
    public bool recovered;
    AudioClip gameOverClip;
    private bool soundplayed;



    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gameover = false;
        recovered = false;
        soundplayed = false;
        gameOverClip = Resources.Load<AudioClip>("game_over_14");
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    public void Gamestart()
    {

        Debug.Log("start");
        if(!recovered)
        {
            ScoreManager.instance.startscore();
        }
        UIManager.instance.Gamestart();
        
        PlatformSpawner.instance.startspawning();
    }

    public void Gamerecover()
    {
        recovered = true;
        Debug.Log("recover");
        
        UIManager.instance.GameRecovery();
        PlatformSpawner.instance.stopspawning();
        

        // PlatformSpawner.instance.startspawning();
    }

    public void Gameover()
    {
        
        ScoreManager.instance.stopscore();
        UIManager.instance.Gameover();
        gameover = true;
        if(!soundplayed)

        {
            SoundManager.instance.playsound(gameOverClip);
            soundplayed = true;
        }

      


    }
}
