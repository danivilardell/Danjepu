using UnityEngine;

public class Fall_to_the_pit : MonoBehaviour
{
    public GameObject player;
    public GameObject respown;

    void OnTriggerEnter2D(Collider2D col)
    {
    	if(col.tag == "Player") {
        	player.transform.position = respown.transform.position;
        	DeathsTextScript.deathAmaunt += 1;
        }
    }
}
