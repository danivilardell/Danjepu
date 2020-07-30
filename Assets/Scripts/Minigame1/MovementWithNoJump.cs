using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementWithNoJump : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private GameObject camera;
    public KeyCode run1;
    public KeyCode run2m;
    private Animator anim;
    private float moveSpeed = 5f;
    public Vector3 camPos;


    void Start() {
        camPos = camera.transform.position;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, 0) * speed * Time.deltaTime;
        camera.transform.position += (camPos - camera.transform.position) * Time.deltaTime * moveSpeed;
    }

}