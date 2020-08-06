using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMiniGame1 : MonoBehaviour
{
    
    public KeyCode start;
    public bool started;
    [SerializeField] GameObject startText;
    [SerializeField] GameObject puntuador;
    [SerializeField] GameObject player;
    [SerializeField] GameObject mapMove;
    [SerializeField] GameObject highscore;
    [SerializeField] private float initialJumpSpeed;
    private Animator anim;


    void Start() {
    	started = false;
        anim = player.GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(start) && !started) {
            if(!DisplayHighscore.ISLEGENDARY) {
                MapGenerator.CONTADOR = 0;
                MapGenerator.INTERVAL = 50;
                MapGenerator.NUMEROBASE = 2;
            }
            else {
                MapGenerator.CONTADOR = 0;
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
