using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ChooseNumber : MonoBehaviour
{
	
	[SerializeField] private int number;
	private bool isPrime;
	[SerializeField] private Text txt;	

	void Start() {
		isPrime = isPrimeNum(number);
		transform.GetChild(1).GetComponent<PlatformBounce>().esPrimer = isPrime;
		txt.text = number.ToString();
	}

    private bool isPrimeNum(int a) {
    	if(a < 2) return false;
    	for(int i = 2; i*i <= a; i++) {
    		if(a%i == 0) return false;
    	}
    	return true;
    }
}
