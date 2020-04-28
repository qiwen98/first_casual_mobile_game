using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject startPanel;
    public GameObject GameOverPanel;
    public GameObject Taptexttostart;
    public GameObject Healthimage;
    public Transform Healthimage_parent;
    public Text Score;
    public Text HighScore;
    public Text HighScoreTextAtBack;
    public Text ShowScore;
    float imagesize=40;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        HighScore.text = "Personal High Score: "+PlayerPrefs.GetFloat("highscore").ToString();
        
    }

    public void GameRecovery()
    {
        Taptexttostart.GetComponent<Animator>().Play("RecoveryAnim");
    }

    public void Gamestart()
    {
       
        Taptexttostart.GetComponent<Animator>().Play("TextToDown");
        startPanel.GetComponent<Animator>().Play("PanelGoUP");
    }

    public void Gameover()
    {
        Score.text = PlayerPrefs.GetFloat("score").ToString();
        HighScore.text = PlayerPrefs.GetFloat("highscore").ToString();
        HighScoreTextAtBack.text = PlayerPrefs.GetFloat("highscore").ToString();
        GameOverPanel.SetActive(true);
        DrawHeart();
    }

    public void reset()
    {
        SceneManager.LoadScene("level 1");
    }

    public void GoToRankScene()
    {
        SceneManager.LoadScene("ScoreBoard");
    }

    public void GoToMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }

    public void DrawHeart()
    {
        /*Healthimage_parent =GameObject.Find("/Canvas").transform.GetChild(0).transform;
       
        Instantiate(Healthimage, new Vector3(200, 750, 0), Quaternion.identity, Healthimage_parent);*/

        Healthimage_parent = GameObject.Find("/Canvas").transform.GetChild(0).transform;
        //destroy all child;
        foreach (Transform child in Healthimage_parent)
        {
            Destroy(child.gameObject);
        }

        
      
        
        for (int i=1;i<ScoreManager.instance.Health+1;i++)
        {
            
            Debug.Log("heart"+i);
            Instantiate(Healthimage, new Vector3(160+(imagesize* i), 755, 0), Quaternion.identity, Healthimage_parent);
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        if(BallMove.instance.started)
        {
            ShowScore.text = ": " + ScoreManager.instance.Score.ToString();

            
        }
        
       

       
    }
}
