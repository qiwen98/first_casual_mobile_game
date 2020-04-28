 using UnityEngine;
using System.Collections;

public class ScoreBoard : MonoBehaviour
{

    const string privateCode = "7cTUmkVed0i7ZZpoemBfXQLu3hM2krWkWxDzKhGF1H-A";
    const string publicCode = "5e32492ffe22df1a24dfc073";
    const string webURL = "http://dreamlo.com/lb/";

    DisplayScore highscoreDisplay;
    public Highscore[] highscoresList;
    public Playerscore PlayerscoresList;
    static ScoreBoard instance;

    void Awake()
    {
        highscoreDisplay = GetComponent<DisplayScore>();
        
            instance = this;
        
      

       
    }

    public static void AddNewHighscore(string username, int score, int time)
    {
        instance.StartCoroutine(instance.UploadNewHighscore(username, score, time));
    }

    IEnumerator UploadNewHighscore(string username, int score, int time)
    {
        WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score+ "/" + time);
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            print("Upload Successful");
            //DownloadHighscores();
        }
        else
        {
            print("Error uploading: " + www.error);
        }
    }

    public void DownloadHighscores()
    {
        StartCoroutine("DownloadHighscoresFromDatabase");
    }

    IEnumerator DownloadHighscoresFromDatabase()
    {
        WWW www = new WWW(webURL + publicCode + "/pipe/");
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            FormatHighscores(www.text);
            highscoreDisplay.OnHighscoresDownloaded(highscoresList);
        }
        else
        {
            print("Error Downloading: " + www.error);
        }
    }

    void FormatHighscores(string textStream)
    {
        string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        highscoresList = new Highscore[entries.Length];
        

        for (int i = 0; i < entries.Length; i++)
        {
            string[] entryInfo = entries[i].Split(new char[] { '|' });
            string username = entryInfo[0];
            int score = int.Parse(entryInfo[1]);
            int time = int.Parse(entryInfo[2]);
           
            highscoresList[i] = new Highscore(username, score, time);
          

            print(highscoresList[i].username + ": " + highscoresList[i].score+ ": " + highscoresList[i].time);

            if(highscoresList[i].username ==ScoreManager.playername)
            {
                
                int rank = i+1;
                PlayerscoresList = new Playerscore(rank, username, score, time);
                Debug.Log(PlayerscoresList.username + "is found");
                highscoreDisplay.DisplayPlayerRank(PlayerscoresList);
            }
            else
            {
               // print("Error on finding" );
            }
        }
    }

   

}

public struct Highscore
{
    public string username;
    public int score;
    public int time;

    public Highscore(string _username, int _score, int _time)
    {
        username = _username;
        score = _score;
        time = _time;
    }

}

public struct Playerscore
{
    public int rank;
    public string username;
    public int score;
    public int time;
   

    public Playerscore(int _rank,string _username, int _score, int _time)
    {
        rank = _rank;
        username = _username;
        score = _score;
        time = _time;
    }

}