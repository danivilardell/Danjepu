using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEndScript : MonoBehaviour
{
	public GameObject canvas;
    public GameObject controller;
    public bool ended;

    void Start() {
        controller = GameObject.Find("/Controller");
        ended = false;
    }

    void Update() {
        Debug.Log(ended);
    }

    void OnTriggerEnter2D(Collider2D col) {
    	if(col.tag == "Enemy") {
    		canvas.SetActive(true);
    		canvas.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
            canvas.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
            ended = true;
    	}
    	else if(col.tag == "Player" && !ended) {
    		canvas.SetActive(true);
            canvas.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
            canvas.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
            controller.GetComponent<GameController>().BeatedLevel(false);
            ended = true;
    	}
        else if(col.tag == "Head" && !ended) {
            Debug.Log("hola");
            canvas.SetActive(true);
            canvas.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
            canvas.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
            controller.GetComponent<GameController>().BeatedLevel(true);
            ended = true;
        }
    }
}
