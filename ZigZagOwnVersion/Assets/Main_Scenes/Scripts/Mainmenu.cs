using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public AudioSource myfx;
    public AudioClip hoversound;
    public AudioClip clicksound;

    private bool showlevel = false;

   

    public void playgame()
    {


        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void quitgame()
    {
        Application.Quit();

    }

    public void gorankscene()
    {
        //Application.LoadLevel("rankscene");
        SceneManager.LoadScene("ScoreBoard");
    }

    public void playhoversound()
    {
        myfx.PlayOneShot(hoversound);
    }

    public void playclicksound()
    {
        myfx.PlayOneShot(clicksound);
    }

    public void playlevelOne()
    {


        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void playlevelTwo()
    {


        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void playlevelThree()
    {


        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);

    }

    public void playlevelFour()
    {


        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +4);

    }

    public void playlevelFive()
    {


        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 5);
    }

    public void gomenuscene()
    {
        //Application.LoadLevel("rankscene");
        SceneManager.LoadScene("Menu");
    }
}
