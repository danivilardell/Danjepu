using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int actualLevel;
    public GameObject jugador;
    public GameObject roda1;
    public GameObject roda2;
    public GameObject levels;
    public GameObject graph;

    public void RestartLevel(int level) {
    	actualLevel = level;
        jugador.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        jugador.GetComponent<Rigidbody2D>().angularVelocity = 0f;
        roda1.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        roda1.GetComponent<Rigidbody2D>().angularVelocity = 0f;
        roda2.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        roda2.GetComponent<Rigidbody2D>().angularVelocity = 0f;
        jugador.transform.rotation = Quaternion.identity;
    	jugador.transform.position = levels.transform.GetChild(actualLevel - 1).GetChild(0).GetChild(0).transform.position;
    	graph.GetComponent<DrawFunction>().Restart();
    }

    public void NextLevel() {
        jugador.transform.rotation = Quaternion.identity;
        jugador.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        jugador.GetComponent<Rigidbody2D>().angularVelocity = 0f;
        roda1.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        roda1.GetComponent<Rigidbody2D>().angularVelocity = 0f;
        roda2.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        roda2.GetComponent<Rigidbody2D>().angularVelocity = 0f;
    	levels.transform.GetChild(actualLevel - 1).gameObject.SetActive(false);
    	actualLevel++;
    	levels.transform.GetChild(actualLevel - 1).gameObject.SetActive(true);
    	jugador.transform.position = levels.transform.GetChild(actualLevel - 1).GetChild(0).GetChild(0).transform.position;
    	graph.GetComponent<DrawFunction>().Restart();
    }

    public void RestartCurrentLevel() {
        jugador.transform.rotation = Quaternion.identity;
        jugador.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        jugador.GetComponent<Rigidbody2D>().angularVelocity = 0f;
        roda1.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        roda1.GetComponent<Rigidbody2D>().angularVelocity = 0f;
        roda2.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        roda2.GetComponent<Rigidbody2D>().angularVelocity = 0f;
        jugador.transform.position = levels.transform.GetChild(actualLevel - 1).GetChild(0).GetChild(0).transform.position;
    	graph.GetComponent<DrawFunction>().Restart();
    }
}
