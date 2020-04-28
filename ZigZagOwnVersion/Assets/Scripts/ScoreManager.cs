using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public float Score;
    private float Highscore;
    [SerializeField]
    public float Health;
    
    private float maxHealth;
    private bool uploadscore = false;
    public static string playername;
    private float finaltime;

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
        Score =0;
        maxHealth = 3;
        PlayerPrefs.SetFloat("score", Score);
        playername = "playerzig" + Random.Range(1, 10000);
        finaltime = 0;
        

    }

    // Update is called once per frame
    void Update()
    {
        finaltime += 1 * Time.deltaTime;
    }

   public void incrementScore()
    {
        Score += 1;
    }

    public void incrementHealth()
    {
        if(Health<maxHealth)
        {
            Health += 1;
            UIManager.instance.DrawHeart();
        }
        
    }

    public void DecreaseHealth()
    {
        
            Health -= 1;
        UIManager.instance.DrawHeart();
    }

    public void startscore()
    {
        Score = 0;
        Health = 1;
        UIManager.instance.DrawHeart();
        // InvokeRepeating("incrementScore", 0.1f,0.5f);

    }

    public void stopscore()
    {
        // CancelInvoke("incrementScore");
        Health = 0;
        PlayerPrefs.SetFloat("score", Score);
       



        if (PlayerPrefs.HasKey("highscore"))
        {
            if(Score > PlayerPrefs.GetFloat("highscore"))
            {
                PlayerPrefs.SetFloat("highscore", Score);
            }
        }
        else
        {
            PlayerPrefs.SetFloat("highscore", Score);
        }


        if (!uploadscore)
        {
            ScoreBoard.AddNewHighscore(playername, (int)Score, (int)finaltime);
            // ScoreBoard.AddNewHighscore(playername, ScoreManager.instance.Score, finaltime);
            //Debug.Log("callinf");
            uploadscore = true;

        }
    }
}
