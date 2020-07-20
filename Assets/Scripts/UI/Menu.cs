using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void doQuit() {
    	Application.Quit();
    }

    public void doStart() {
    	SceneManager.LoadScene("Game");
    }
}
