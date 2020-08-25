﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
	[SerializeField] GameObject plataformes;
	[SerializeField] GameObject jugador;
	[SerializeField] GameObject mapaMove;
	[SerializeField] GameObject respawn;
	[SerializeField] GameObject canvas;
	[SerializeField] Text pun;

	public string[] acudits = {
		"Should we say all prime numbers are odd but one or 2?",
		"Pro tip, 6 is not prime",
		"Counting primes is like dating, if they are under 13 put them in your head",
		"What do prime numbers and teenage girls have in common? They both \"can't even\"",
		"2 is the only even prime number. It's kind of odd, isn't it?",
		"We should give credit to the number 2. It became a prime number against all odds.",
		"All prime numbers except 2 are odd, this makes 2 the oddest prime.",
		"What can a mathematician and a pedophile agree upon? Seven is a prime number",
		"Why was six afraid of seven? Cause seven, eight, nine!",
		"Why was six afraid of seven? Aproximatelly -0.89594417018",
		"Why is statistics never anyone’s favorite subject? It’s just average.",
		"You should never start a conversation with Pi. It’ll just go on and on forever.",
		"I poured root beer into a square cup. Now I have beer."
	};


	void Start() {
		foreach (Transform child in plataformes.transform) {
     		GameObject.Destroy(child.gameObject);
 		}
 		mapaMove.transform.position = new Vector3(0,0,0);
 		jugador.transform.position = respawn.transform.position;
 		mapaMove.GetComponent<MapMove>().started = false;
 	 	canvas.SetActive(false);
 	 	transform.GetComponent<StartMiniGame1>().started = false;
 	 	jugador.GetComponent<MovementWithNoJump>().inGame = true;
 	 	jugador.GetComponent<ContadorPunts>().Start();
 	 	int randomNum;
		System.Random r = new System.Random();
		randomNum = r.Next(0, acudits.Length);
		pun.text = acudits[randomNum];
		pun.gameObject.SetActive(true);
		MapGenerator.CONTADOR = -2;
        MapGenerator.INTERVAL = 50;
        MapGenerator.NUMEROBASE = 0;
		transform.GetComponent<MapGenerator>().creaPlataformes();
	}

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
 	 	jugador.GetComponent<ContadorPunts>().Start();
 	 	int randomNum;
		System.Random r = new System.Random();
		randomNum = r.Next(0, acudits.Length);
		pun.text = acudits[randomNum];
		pun.gameObject.SetActive(true);
		MapGenerator.CONTADOR = -2;
        MapGenerator.INTERVAL = 50;
        MapGenerator.NUMEROBASE = 0;
		transform.GetComponent<MapGenerator>().creaPlataformes();
    }

}
