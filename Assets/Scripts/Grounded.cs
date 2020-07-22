using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    GameObject Player;
    private Animator anim;

    void Start() {
    	Player = gameObject;
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
    	if(collision.collider.tag == "Ground") {
    		Player.GetComponent<Movement>().isGrounded = true;
            Player.GetComponent<Movement>().doubleJump = 2;
            anim.SetBool("isJumping", false);
    	}
    }

    private void OnCollisionExit2D(Collision2D collision) {
    	if(collision.collider.tag == "Ground") {
    		Player.GetComponent<Movement>().isGrounded = false;
    	}
    }
}
