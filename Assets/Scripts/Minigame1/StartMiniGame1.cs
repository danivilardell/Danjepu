using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMiniGame1 : MonoBehaviour
{
    
    public KeyCode start;
    private bool started;
    [SerializeField] GameObject startText;
    [SerializeField] GameObject player;
    [SerializeField] private float initialJumpSpeed;

    void Start() {
    	started = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(start) && !started) {
        	started = true;
        	startText.SetActive(false);
            player.GetComponent<Rigidbody2D>().AddForce(new Vector3(0f, initialJumpSpeed),  ForceMode2D.Impulse);
        }
    }
}
