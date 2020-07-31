using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
	[SerializeField] GameObject plataformes;
	[SerializeField] GameObject jugador;
	[SerializeField] GameObject mapaMove;
	[SerializeField] GameObject respawn;
	[SerializeField] GameObject canvas;


    public void Restart() {
    	foreach (Transform child in plataformes.transform) {
     		GameObject.Destroy(child.gameObject);
 		}
 		mapaMove.transform.position = new Vector3(0,0,0);
 		jugador.transform.position = respawn.transform.position;
 		mapaMove.GetComponent<MapMove>().started = false;
 	 	canvas.SetActive(false);
 	 	transform.GetComponent<StartMiniGame1>().started = false;
 	 	jugador.GetComponent<MovementWithNoJump>().inGame = true;
    }
}
