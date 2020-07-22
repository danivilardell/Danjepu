using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterAnim : MonoBehaviour
{

    private Animator anim;
    GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = gameObject;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) {
            anim.SetBool("isRunning", true);
        } else {
            anim.SetBool("isRunning", false);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) &&  Player.GetComponent<Movement>().isGrounded == true) {
            anim.SetTrigger("jump");
            anim.SetBool("isJumping", true);
        }
    }
}
