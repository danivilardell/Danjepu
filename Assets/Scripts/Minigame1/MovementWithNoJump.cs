using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementWithNoJump : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    public KeyCode run1;
    public KeyCode run2m;
    private Animator anim;

    void Start() {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, 0) * speed * Time.deltaTime;

    }
}