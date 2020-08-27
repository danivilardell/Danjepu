using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHighscore : MonoBehaviour
{
	public GameObject[] highscoreText;
	HighscoreTable highscoreManager;
  	public bool isLegendary;
    
    void Start()
    {
      isLegendary = false;
       	for (int i = 0; i < highscoreText.Length; i++) {
       		highscoreText[i].transform.GetChild(1).transform.GetComponent<Text>().text = "Fetching...";
       		highscoreText[i].transform.GetChild(2).transform.GetComponent<Text>().text = "...";
       	} 
       	highscoreManager = GetComponent<HighscoreTable>();

       	StartCoroutine("RefreshHighscores");
       	isLegendary = false;
    }

    public void StartGame() {
       	StartCoroutine("RefreshHighscores");
    }

    public void OnHighscoresDownloaded(Highscore[] highscoreList) {
    	for (int i = 0; i < highscoreText.Length; i++) {
       		if(highscoreList.Length > i) {
       			highscoreText[i].transform.GetChild(1).transform.GetComponent<Text>().text = highscoreList[i].username;
       			highscoreText[i].transform.GetChild(2).transform.GetComponent<Text>().text = highscoreList[i].score.ToString();
       		}
       		else {
       			highscoreText[i].transform.GetChild(1).transform.GetComponent<Text>().text = "-";
       		highscoreText[i].transform.GetChild(2).transform.GetComponent<Text>().text = "-";
       		}
    	} 
    }

    IEnumerator RefreshHighscores() {
    	while(true) {
    		highscoreManager.DownloadHighScores();
    		yield return new WaitForSeconds(30);
    	}
    }

    public void viewLeg(bool isLeg) {
      bool aux = isLegendary;
      isLegendary = isLeg;
      highscoreManager.isLegendary(isLeg);
      highscoreManager.DownloadHighScores();
      isLegendary = aux;
    }

    public void isLeg (bool isLeg) {
        isLegendary = isLeg;
    }

}
