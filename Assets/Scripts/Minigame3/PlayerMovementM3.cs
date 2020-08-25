using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    void OnTriggerEnter(Collider col) {
    	Debug.Log("hola");
    	if(col.gameObject.tag == "Teleport") {
    		transform.position = col.transform.parent.GetChild(1).transform.position;
    	}
    }
}
