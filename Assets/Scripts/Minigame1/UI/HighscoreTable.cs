using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreTable : MonoBehaviour
{
    private string privateCode = "VDuAQcGxeE28ukTKpSQ54g-50LOBNDsEuR7Ct0j5ucJQ";
    private string publicCode = "5f2bfe05eb371809c4b0c74e";
    private string webURL = "http://dreamlo.com/lb/";

    public Highscore[] highscoreList;
    public Highscore[] highscoreListLeg;
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
            if(DisplayHighscore.ISLEGENDARY) highscoresDisplay.OnHighscoresDownloaded(highscoreList);
            else highscoresDisplay.OnHighscoresDownloaded(highscoreListLeg);
        }
    	else print ("Error Downloading: " + www.error);
    }

    void FormatHighscores(string textStream) {
        if(DisplayHighscore.ISLEGENDARY) {
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
        else {
            string[] entries = textStream.Split(new char[] {'\n'}, System.StringSplitOptions.RemoveEmptyEntries);
            highscoreListLeg = new Highscore[entries.Length];

            for(int i = 0; i < entries.Length; i++) {
                string[] entryInfo = entries[i].Split(new char[] {'|'});
                string username = entryInfo[0];
                int score = int.Parse(entryInfo[1]);
                highscoreListLeg[i] = new Highscore(username, score);
                print (highscoreListLeg[i].username + ":" + highscoreListLeg[i].score);
            }
        }
    	
    }

    public void isLegendary(bool isLeg) {
        if(isLeg) {
            privateCode = "R0OinHankkGzNxlmSalNFgSB1wWOsri06QoDArSoxplw";
            publicCode = "5f2c4b94eb371809c4b18470";
            webURL = "http://dreamlo.com/lb/";
        }
        else {
            privateCode = "VDuAQcGxeE28ukTKpSQ54g-50LOBNDsEuR7Ct0j5ucJQ";
            publicCode = "5f2bfe05eb371809c4b0c74e";
            webURL = "http://dreamlo.com/lb/";
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
