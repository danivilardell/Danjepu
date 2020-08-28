using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementM3 : MonoBehaviour
{
    private bool started;
    private Animator anim;
    public float speed;
    private float hInput;
    public Rigidbody2D rb;

    void Start() {
        started = false;
        anim = GetComponent<Animator>();
    }

    void Update() {
        hInput = Input.GetAxisRaw("Horizontal");
    }

    public void StartPush() {
        if(!started) {
            transform.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(4f, 0f),  ForceMode2D.Impulse);
            started = true;
            anim.SetBool("isMoving", true);
        }
    }

    void FixedUpdate() {
        Debug.Log(hInput);
        rb.AddTorque(-hInput * speed * Time.fixedDeltaTime);
    }
}
