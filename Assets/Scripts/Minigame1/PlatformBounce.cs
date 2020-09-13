using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBounce : MonoBehaviour
{

    [SerializeField] private float jumpSpeed;
    private Animator anim;
    public bool esPrimer;
    [SerializeField] GameObject controller;
    public GameObject player;

    void Start() {
        player = GameObject.Find("/Matematic");
    }

    public void StartGame() {
    	anim = GameObject.Find("Matematic").GetComponent<Animator>();
    	if(!esPrimer) {
    		GetComponent<Collider2D>().enabled = false;
    	}
        else GetComponent<Collider2D>().enabled = true;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        player = GameObject.Find("Matematic");
    	if(collision.gameObject.tag == "Grounded" && collision.gameObject.GetComponent<Rigidbody2D>().velocity.y <= 1.5f && player.GetComponent<MovementWithNoJumpPhone>().inGame) {
            collision.transform.GetComponent<ContadorPunts>().CanviaPunts(transform.parent.transform.position.y);
			collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(0f, jumpSpeed),  ForceMode2D.Impulse);
            anim.SetBool("isJumping", false);
	    	anim.SetTrigger("jump");
            FindObjectOfType<AudioManagerScript>().PlaySound("Boing");
            anim.SetBool("isJumping", true);
            controller.GetComponent<MapGenerator>().creaPlataformes();

	    }
    }

}
