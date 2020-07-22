using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpSpeed = 5f;
    public KeyCode run1;
    public KeyCode run2;
    public KeyCode jump;
    private Animator anim;
    public bool isGrounded;
    public int doubleJump;

    void Start() {
        anim = GetComponent<Animator>();
        doubleJump = 2;
    }

    void Update()
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, 0) * speed * Time.deltaTime;

        if(Input.GetKeyDown(jump) && doubleJump > 0) {
        	GetComponent<Rigidbody2D>().AddForce(new Vector3(0f, jumpSpeed),  ForceMode2D.Impulse);
            anim.SetTrigger("jump");
            doubleJump--;
        }

    }
}
