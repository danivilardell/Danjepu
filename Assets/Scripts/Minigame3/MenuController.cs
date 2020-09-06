using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject pathContainer;

    void Start() {
    	DrawPath();
    }

    public void DrawPath() {
    	if (!PlayerPrefs.HasKey("lastLevel")) PlayerPrefs.SetInt("lastLevel", 0);
    	int lastLevel = PlayerPrefs.GetInt("lastLevel");
    	Debug.Log(lastLevel);
    	for(int i = 1; i <= pathContainer.transform.childCount; i++) {
    		if(i <= lastLevel) pathContainer.transform.GetChild(i - 1).GetChild(0).gameObject.SetActive(true);
    		else pathContainer.transform.GetChild(i - 1).GetChild(0).gameObject.SetActive(false);
    	}
    }

}
