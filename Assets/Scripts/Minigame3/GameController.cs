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
    private int[] rotacionsPerNivell = new int[] { 1, 1, 5, 7, 9 };
    private int rotacions;
    private double rot1;
    private double rotTot;

    void Start() {
        rot1 = 0;
        rotTot = 0;
    }

    void FixedUpdate() {
        if(rot1 > 350 && jugador.transform.eulerAngles.z < 10) {
            rotTot -= 360 - rot1 + jugador.transform.eulerAngles.z;
        } else if(rot1 < 10 && jugador.transform.eulerAngles.z > 350) {
            rotTot += 360 + rot1 - jugador.transform.eulerAngles.z;
        } else{
            rotTot -= jugador.transform.eulerAngles.z - rot1;
        } 
        rot1 = jugador.transform.eulerAngles.z;
    }

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

    public void BeatedLevel() {
        if(rotTot > 0) rotacions = (int)(rotTot+120)/360;
        else rotacions = (int)(rotTot-120)/360;
        Debug.Log(rotacions);
        int p = actualLevel - 1;
        PlayerPrefs.SetInt("Star" + p, 1);
        if(actualLevel <= PlayerPrefs.GetInt("lastLevel")) return;
        PlayerPrefs.SetInt("lastLevel", actualLevel);
        rotacions = 0;
    }

    public void ClearLevels() {

        for(int i = 0; i < levels.transform.childCount; i++) {
            levels.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
