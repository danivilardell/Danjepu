using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementM3 : MonoBehaviour
{
	private float jumpSpeed = 20;
    private bool started;

    void Start() {
        started = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
    	Debug.Log(col.transform.rotation.z);
    	if(col.gameObject.tag == "Teleport"){
    		transform.position = col.transform.parent.GetChild(1).transform.position;
    	}

    	if(col.gameObject.tag == "Fast"){
    		transform.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(Mathf.Sin(col.transform.rotation.z)*jumpSpeed, Mathf.Cos(col.transform.rotation.z)*jumpSpeed),  ForceMode2D.Impulse);
    	}

    }
    void OnCollisionEnter2D(Collision2D col){
	    if(col.gameObject.tag == "Bounce"){
	    	transform.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(Mathf.Sin(col.transform.rotation.z)*jumpSpeed, Mathf.Cos(col.transform.rotation.z)*jumpSpeed),  ForceMode2D.Impulse);
    	}
    }

    public void StartPush() {
        if(!started) {
            transform.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(2f, 0f),  ForceMode2D.Impulse);
            started = true;
        }
    }
}
