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
    	for(int i = 0; i < pathContainer.transform.childCount; i++) {
    		if(!PlayerPrefs.HasKey("Star" + i)) PlayerPrefs.SetInt("Star" + i, 0);
    	}

    	int lastLevel = PlayerPrefs.GetInt("lastLevel");
    	for(int i = 1; i <= pathContainer.transform.childCount; i++) {
    		if(i <= lastLevel) {
    			pathContainer.transform.GetChild(i - 1).GetChild(0).gameObject.SetActive(true);
    			pathContainer.transform.GetChild(i - 1).GetChild(2).gameObject.SetActive(true);
    			int p = i - 1;
    			for(int j = 0; j < PlayerPrefs.GetInt("Star" + p); j++) {
    				pathContainer.transform.GetChild(i - 1).GetChild(2).GetChild(j).GetComponent<Image>().color = Color.yellow;
    			}
    		}
    		else {
    			pathContainer.transform.GetChild(i - 1).GetChild(0).gameObject.SetActive(false);
    			pathContainer.transform.GetChild(i - 1).GetChild(2).gameObject.SetActive(false);
    		}
    	}
    }
}