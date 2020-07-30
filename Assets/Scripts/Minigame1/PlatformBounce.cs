using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBounce : MonoBehaviour
{

    [SerializeField] private float jumpSpeed;
    private Animator anim;
    public bool esPrimer;

    void Start() {
    	anim = GameObject.Find("Matematic").GetComponent<Animator>();
    	if(!esPrimer) {
    		transform.GetComponent<Collider2D>().enabled = false;
    	}
    }

    void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("hola2");
    	if(collision.gameObject.tag == "Grounded" && collision.gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0) {
            Debug.Log("hola3");
			collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(0f, jumpSpeed),  ForceMode2D.Impulse);
	    	anim.SetTrigger("jump");
	    	anim.SetBool("isJumping", true);
	    }
	
    }
}
