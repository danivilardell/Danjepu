using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
	public Slider slider;
	public Gradient gradient;
	public Image fill;

	public void SetMaxHealth(int health) {
		slider.maxValue = health;
		slider.value = health;

		//Pongo el color de maxHealth.
		fill.color = gradient.Evaluate(1);
	}

	public void setHealth(int health) {
		slider.value = health;
		//No esta funcionando, pero en teoría la vida debería cambiar de color.
		fill.color = gradient.Evaluate(slider.normalizedValue);
	}
}
