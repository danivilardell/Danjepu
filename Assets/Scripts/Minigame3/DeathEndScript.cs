using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEndScript : MonoBehaviour
{
	public GameObject canvas;

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
    	}
    }
}
