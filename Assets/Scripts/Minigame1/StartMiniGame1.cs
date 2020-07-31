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


    void Start() {
    	started = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(start) && !started) {
            MapGenerator.CONTADOR = 0;
        	started = true;    
        	startText.SetActive(false);
            puntuador.SetActive(true);
            player.GetComponent<Rigidbody2D>().AddForce(new Vector3(0f, initialJumpSpeed),  ForceMode2D.Impulse);
            mapMove.GetComponent<MapMove>().started = true;
        }
    }
}
