using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMiniGamePhone : MonoBehaviour
{
    
    public KeyCode start;
    public bool started;
    [SerializeField] GameObject startText;
    [SerializeField] GameObject puntuador;
    [SerializeField] GameObject player;
    [SerializeField] GameObject mapMove;
    [SerializeField] GameObject highscore;
    [SerializeField] GameObject controller;
    [SerializeField] private float initialJumpSpeed;
    private Animator anim;


    void Start() {
        started = false;
        anim = player.GetComponent<Animator>();
    }

    public void StartGame()
    {
        if(true) {
            if(!controller.GetComponent<DisplayHighscore>().isLegendary) {
                MapGenerator.CONTADOR = 2;
                MapGenerator.INTERVAL = 50;
                MapGenerator.NUMEROBASE = 4;
            }
            else {
                MapGenerator.CONTADOR = 2;
                MapGenerator.INTERVAL = 200;
                MapGenerator.NUMEROBASE = 100;
            }
            MapGenerator.IT = 1;
            player.GetComponent<ContadorPunts>().Start();
            highscore.GetComponent<DisplayHighscore>().StartGame();
            started = true;    
            startText.SetActive(false);
            puntuador.SetActive(true);
            anim.SetTrigger("jump");
            anim.SetBool("isJumping", true);
            player.GetComponent<Rigidbody2D>().AddForce(new Vector3(0f, initialJumpSpeed),  ForceMode2D.Impulse);
            mapMove.GetComponent<MapMove>().started = true;
        }
    }
}