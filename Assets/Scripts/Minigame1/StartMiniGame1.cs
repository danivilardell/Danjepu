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
    [SerializeField] private float initialJumpSpeed;
    private Animator anim;


    void Start() {
    	started = false;
        anim = player.GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(start) && !started) {
            MapGenerator.CONTADOR = 0;
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
