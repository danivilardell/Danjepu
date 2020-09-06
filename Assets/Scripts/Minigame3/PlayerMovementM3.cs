using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementM3 : MonoBehaviour
{
    private Animator anim;
    public float speed;
    private float hInput;
    public Rigidbody2D rb;

    void Start() {
        anim = GetComponent<Animator>();
    }

    void Update() {
        hInput = Input.GetAxisRaw("Horizontal");
    }

    public void StartPush() {
        transform.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(5f, 0f),  ForceMode2D.Impulse);
        anim.SetBool("isMoving", true);
    }

    void FixedUpdate() {
        rb.AddTorque(-hInput * speed * Time.fixedDeltaTime);
    }

}
