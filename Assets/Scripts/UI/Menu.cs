using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

	public Animator transition1;
	public Animator transition2;
    public static string playername;
    public InputField playernameInput;

    private const string PlayerPrefsNameKey = "PlayerName";

    public void doQuit() {
    	Application.Quit();
    }

    public void doStart() {
    	StartCoroutine(LoadLevel());
    }

    private void Awake() => SetUpInputField();

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

    public void LoadMainMenu() {
        SceneManager.LoadScene("Menu");
    }

    public void SaveName() {
        playername = playernameInput.text;

        PlayerPrefs.SetString(PlayerPrefsNameKey, playername);
    }

    private void SetUpInputField()
    {
        Debug.Log(PlayerPrefs.GetString(PlayerPrefsNameKey));
        if (!PlayerPrefs.HasKey(PlayerPrefsNameKey)) { return; }

        string defaultName = PlayerPrefs.GetString(PlayerPrefsNameKey);

        playernameInput.text = defaultName;
    }

    public static string PLAYERNAME {
        get {
            return playername;
        }
        set {
            playername = value;
        }
    }
}
