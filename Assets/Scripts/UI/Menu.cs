using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

	public Animator transition1;
	public Animator transition2;

    public void doQuit() {
    	Application.Quit();
    }

    public void doStart() {
    	StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel() {
    	transition1.SetTrigger("Start");
    	transition2.SetTrigger("Start");

    	yield return new WaitForSeconds(3);
    	Debug.Log("hola");

    	SceneManager.LoadScene("Game");
    }

    public void LoadMinigame(string i) {
        SceneManager.LoadScene("Minigame" + i);
    }
}
