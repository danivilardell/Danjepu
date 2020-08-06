﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementWithNoJump : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private GameObject endPanel;
    [SerializeField] private GameObject controller;
    public KeyCode run1;
    public KeyCode run2m;
    private Animator anim;
    private float moveSpeed = 5f;
    public bool inGame;
    public InputField playername;


    void Start() {
        inGame = true;
        anim = GetComponent<Animator>();
    }

    void Update() {
        if(inGame) {
            transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, 0) * speed * Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == "Enemy") {
            
            HighscoreTable.AddNewHighscore(playername.text, transform.GetComponent<ContadorPunts>().punts);

            endPanel.SetActive(true);
            anim.SetBool("isJumping", false);
            inGame = false;
            PlatformBounce.INGAME = false;
        }
    }

}