using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreTable : MonoBehaviour
{
    const string privateCode = "VDuAQcGxeE28ukTKpSQ54g-50LOBNDsEuR7Ct0j5ucJQ";
    const string publicCode = "5f2bfe05eb371809c4b0c74e";
    const string webURL = "http://dreamlo.com/lb/";

    public Highscore[] highscoreList;
    static HighscoreTable instance;
    DisplayHighscore highscoresDisplay;

    void Start() {
        instance = this;
    	highscoresDisplay = GetComponent<DisplayHighscore> ();
    }

    public static void AddNewHighscore(string username, int score) {
    	instance.StartCoroutine(instance.UploadNewHighscore(username, score));
    }

    IEnumerator UploadNewHighscore(string username, int score) {
    	WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
    	yield return www;

    	if(string.IsNullOrEmpty(www.error)) {
            print ("Upload Successful");
            DownloadHighScores();
        }
    	else print ("Error Uploading: " + www.error);
    }

    public void DownloadHighScores() {
    	StartCoroutine("DownloadHighScoresFromDatabase");
    }

    IEnumerator DownloadHighScoresFromDatabase() {
    	WWW www = new WWW(webURL + privateCode + "/pipe/");
    	yield return www;

    	if(string.IsNullOrEmpty(www.error)) {
            FormatHighscores(www.text);
            highscoresDisplay.OnHighscoresDownloaded(highscoreList);
        }
    	else print ("Error Downloading: " + www.error);
    }

    void FormatHighscores(string textStream) {
    	string[] entries = textStream.Split(new char[] {'\n'}, System.StringSplitOptions.RemoveEmptyEntries);
    	highscoreList = new Highscore[entries.Length];

    	for(int i = 0; i < entries.Length; i++) {
    		string[] entryInfo = entries[i].Split(new char[] {'|'});
    		string username = entryInfo[0];
    		int score = int.Parse(entryInfo[1]);
    		highscoreList[i] = new Highscore(username, score);
    		print (highscoreList[i].username + ":" + highscoreList[i].score);
    	}
    }
}

public struct Highscore {
	public string username;
	public int score;

	public Highscore(string _username, int _score) {
		username = _username;
		score = _score;
	}
}
