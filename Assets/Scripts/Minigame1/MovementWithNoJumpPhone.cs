using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MovementWithNoJumpPhone : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private GameObject endPanel;
    [SerializeField] private GameObject controller;
    public KeyCode run1;
    public KeyCode run2m;
    private Animator anim;
    private float moveSpeed = 5f;
    public bool inGame;
    private float screenCenterX;


    void Start() {
        inGame = true;
        anim = GetComponent<Animator>();
        screenCenterX = Screen.width * 0.5f;
    }

    void Update() {
        if(inGame) {
            if(Input.touchCount > 0 && Input.GetTouch(0).rawPosition.x < screenCenterX) {
                transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;
            }
            else if(Input.touchCount > 0 && Input.GetTouch(0).rawPosition.x >= screenCenterX){
                transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
            }
            
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == "Enemy") {
            
            HighscoreTable.AddNewHighscore(Menu.PLAYERNAME, transform.GetComponent<ContadorPunts>().punts);

            //Poner animación de fade para el panel final.
            endPanel.SetActive(true);
            anim.SetBool("isJumping", false);
            FindObjectOfType<AudioManagerScript>().PlaySound("Ouch");
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(0f, 30f), ForceMode2D.Impulse);
            anim.SetBool("Death", true);
            inGame = false;
        }
    }

}