using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjects : MonoBehaviour
{
	private float jumpSpeed = 48;

    void OnTriggerEnter2D(Collider2D col)
    {
    	if(col.gameObject.tag == "Teleport"){
    		transform.position = col.transform.parent.GetChild(1).transform.position;
    	}

    	if(col.gameObject.tag == "Fast"){
    		transform.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(Mathf.Sin(col.transform.rotation.z)*jumpSpeed, Mathf.Cos(col.transform.rotation.z)*jumpSpeed),  ForceMode2D.Impulse);
    	}

    }
    void OnCollisionEnter2D(Collision2D col){
	    if(col.gameObject.tag == "Bounce"){
	    	transform.parent.parent.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(Mathf.Sin(col.transform.rotation.z)*jumpSpeed, Mathf.Cos(col.transform.rotation.z)*jumpSpeed),  ForceMode2D.Impulse);
    	}
    }
}
