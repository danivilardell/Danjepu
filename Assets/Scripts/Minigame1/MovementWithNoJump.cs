using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementWithNoJump : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private GameObject camera;
    [SerializeField] private GameObject endPanel;
    public KeyCode run1;
    public KeyCode run2m;
    private Animator anim;
    private float moveSpeed = 5f;
    public Vector3 camPos;
    private bool inGame;


    void Start() {
        inGame = true;
        camPos = camera.transform.position;
        anim = GetComponent<Animator>();
    }

    void Update() {
        if(inGame) {
            transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, 0) * speed * Time.deltaTime;
            camera.transform.position += (camPos - camera.transform.position) * Time.deltaTime * moveSpeed;
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == "Enemy") {
            endPanel.SetActive(true);
            inGame = false;
            PlatformBounce.INGAME = false;
        }
    }

}