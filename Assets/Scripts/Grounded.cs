using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    GameObject Player;

    void Start() {
    	Player = gameObject;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
    	if(collision.collider.tag == "Ground") {
    		Player.GetComponent<Movement>().isGrounded = true;
            Player.GetComponent<Movement>().doubleJump = 2;
    	}
    }

    private void OnCollisionExit2D(Collision2D collision) {
    	if(collision.collider.tag == "Ground") {
    		Player.GetComponent<Movement>().isGrounded = false;
    	}
    }
}
