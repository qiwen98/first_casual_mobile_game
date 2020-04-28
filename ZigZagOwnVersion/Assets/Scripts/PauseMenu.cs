using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public bool gameispaused = false;
    public GameObject pausemenu_UI;
    private float time = 0f;
    
    void Update()
    {
        time += 1;
      

        if (Input.GetButton("Cancel")&&time>10 )
        {
            time = 0f;

           

            if (gameispaused )
            {
               
                resume();
               
               
            }

            else
            {
                
                pause();
               
            }
        }
    }


    public void pause()
    {
        
        pausemenu_UI.SetActive(true);
        Time.timeScale = 0f;
        gameispaused = true;
        //Debug.Log("gameispaused");
      
    }

    public void resume()
    {
        
        pausemenu_UI.SetActive(false);
        Time.timeScale = 1f;
        gameispaused = false;
    }

     public void quit()
    {
        Application.Quit();
    }


    public void gomenuscene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");

    }
}
