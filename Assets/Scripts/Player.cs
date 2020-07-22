using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	public int maxHealth = 100;
	public int currentHealth;
	public HealthBar healthBar;
	public GameObject player;
    public GameObject respown;

    void Start()
    {
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Space))
		{
			TakeDamage(20);
		}
    }

	void TakeDamage(int damage)
	{
		currentHealth -= damage;

		healthBar.SetHealth(currentHealth);

		if(currentHealth < 0) {
			player.transform.position = respown.transform.position;
        	DeathsTextScript.deathAmaunt += 1;
        	currentHealth = maxHealth;
        	healthBar.SetHealth(currentHealth);
		}
	}
}