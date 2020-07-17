using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpSpeed = 5f;
    public Animator anim;
    public KeyCode run1;
    public KeyCode run2;
    public KeyCode jump;
    public bool isGrounded;
    public int doubleJump;

    void Start() {
    	anim.SetTrigger ("stopped");
        doubleJump = 2;
    }

    void Update()
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, 0) * speed * Time.deltaTime;
        if(Input.GetKey(run1) || Input.GetKey(run2)) {
        	anim.SetTrigger ("run");
        }
        else anim.SetTrigger("stopped");

        if(Input.GetKeyDown(jump) && doubleJump > 0) {
        	GetComponent<Rigidbody2D>().AddForce(new Vector3(0f, jumpSpeed),  ForceMode2D.Impulse);
            doubleJump--;
        }

    }

    void OnTriggerEnter2D(Collider2D col) {
        Debug.Log("hola1");
        if(col.gameObject.tag == "Moneda") {
            Debug.Log("hola");
            col.gameObject.SetActive(false);
        }
    }
}
