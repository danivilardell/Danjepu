﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBounce : MonoBehaviour
{

    [SerializeField] private float jumpSpeed;
    private Animator anim;
    public bool esPrimer;
    [SerializeField] GameObject controller;
    public static bool inGame;

    public void StartGame() {
        inGame = true;
    	anim = GameObject.Find("Matematic").GetComponent<Animator>();
    	if(!esPrimer) {
    		GetComponent<Collider2D>().enabled = false;
    	}
        else GetComponent<Collider2D>().enabled = true;
    }

    void OnCollisionEnter2D(Collision2D collision) {
    	if(collision.gameObject.tag == "Grounded" && collision.gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0 && inGame) {
            collision.transform.GetComponent<ContadorPunts>().CanviaPunts(transform.parent.transform.position.y);
			collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(0f, jumpSpeed),  ForceMode2D.Impulse);
            anim.SetBool("isJumping", false);
	    	anim.SetTrigger("jump");
	    	anim.SetBool("isJumping", true);
            controller.GetComponent<MapGenerator>().creaPlataformes();

	    }
    }

    public static bool INGAME {
        get {
            return inGame;
        }
        set {
            inGame = value;
        }
    }
}
