using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{

    public Text[] highscoreFields;
    public Text playerscoreField;
    ScoreBoard highscoresManager;

    void Start()
    {
        for (int i = 0; i < highscoreFields.Length; i++)
        {
            highscoreFields[i].text = i + 1 + ". Fetching...";
        }


        highscoresManager = GetComponent<ScoreBoard>();
        StartCoroutine("RefreshHighscores");
    }

    public void OnHighscoresDownloaded(Highscore[] highscoreList)
    {
        for (int i = 0; i < highscoreFields.Length; i++)
        {
            highscoreFields[i].text = i + 1 + ". ";
            if (i < highscoreList.Length)
            {
                highscoreFields[i].text += highscoreList[i].username + " -  " + highscoreList[i].score + " -  " + convertsecondtoformat(highscoreList[i].time);
            }
        }

      


    }


    public void DisplayPlayerRank(Playerscore PlayerscoresList)
    {

        
            
      playerscoreField.text = "Your are on "+PlayerscoresList.rank + " Place :" +PlayerscoresList.username + " -  " + PlayerscoresList.score + " -  " + convertsecondtoformat(PlayerscoresList.time);
            
        



    }

    public string convertsecondtoformat(int counter)
    {
        int hours = 0;
        int minutes = 0;
        int seconds = 0;
        string timeformat = "";

        hours = counter / 3600;
        minutes = (counter % 3600) / 60;
        seconds = (counter % 3600) % 60;

        timeformat = hours + "h : " + minutes + " m: " + seconds +" s ";

        return timeformat;
    }

    IEnumerator RefreshHighscores()
    {
        while (true)
        {
            highscoresManager.DownloadHighscores();
            yield return new WaitForSeconds(30);
        }
    }
}