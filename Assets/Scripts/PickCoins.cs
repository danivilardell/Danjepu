using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickCoins : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
    	if(col.tag == "Player") {
    		ScoreTextScript.coinAmaunt += 1;
        	Destroy(gameObject);
    	}
    }
}
