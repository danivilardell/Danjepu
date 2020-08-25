using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject levels;
    public GameObject player;

    void LoadLevel(int level) {
    	levels.transform.GetChild(level).gameObject.SetActive(true);
    	player.transform.position = levels.transform.GetChild(level).GetChild(0).position;
    }

}
