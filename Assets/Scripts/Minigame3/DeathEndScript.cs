using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEndScript : MonoBehaviour
{
	public GameObject canvas;
    public GameObject controller;

    void Start() {
        controller = GameObject.Find("/Controller");
    }

    void OnTriggerEnter2D(Collider2D col) {
    	if(col.tag == "Enemy") {
    		canvas.SetActive(true);
    		canvas.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
            canvas.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
    	}
    	else if(col.tag == "Player") {
    		canvas.SetActive(true);
            canvas.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
            canvas.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
            controller.GetComponent<GameController>().BeatedLevel();
    	}
    }
}
