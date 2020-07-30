using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{

	public Transform prefab;
	private int interval = 100;
	private int numeroBase = 7;
	[SerializeField] private int initheight;
	public static int contador;
	private bool prime;
	private int randomNum;
	private float[] posicions = {0f, 0f, 0f};
    
	public void creaPlataformes() {
		prime = false;
		System.Random r = new System.Random();
		randomNum = r.Next(numeroBase, numeroBase + 100);
		if(isPrimeNum(randomNum)) prime = true;
		prefab.gameObject.GetComponent<ChooseNumber>().number = randomNum;
		posicions[0] = Random.Range(-8.5f, 8.5f);
		Instantiate(prefab, new Vector3(posicions[0], initheight + contador, 0), Quaternion.identity);

		randomNum = r.Next(numeroBase, numeroBase + 100);
		if(isPrimeNum(randomNum)) prime = true;
		prefab.gameObject.GetComponent<ChooseNumber>().number = randomNum;
		posicions[1] = Random.Range(-8.5f, 8.5f);
		while(Mathf.Abs(posicions[1] - posicions[0]) < 3.3) {
			posicions[1] = Random.Range(-8.5f, 8.5f);
		}
		Instantiate(prefab, new Vector3(posicions[1], initheight + contador, 0), Quaternion.identity);

		randomNum = r.Next(numeroBase, numeroBase + 100);
		while(!isPrimeNum(randomNum) && !prime) {
			randomNum = r.Next(numeroBase, numeroBase + 100);
		}
		prefab.gameObject.GetComponent<ChooseNumber>().number = randomNum;
		posicions[2] = Random.Range(-8.5f, 8.5f);
		while(Mathf.Abs(posicions[2] - posicions[0]) < 3.3 || Mathf.Abs(posicions[2] - posicions[1]) < 3.3) {
			posicions[2] = Random.Range(-8.5f, 8.5f);
		}
		Instantiate(prefab, new Vector3(posicions[2], initheight + contador, 0), Quaternion.identity);
		contador += 2;
	}

	private bool isPrimeNum(int a) {
    	if(a < 2) return false;
    	for(int i = 2; i*i <= a; i++) {
    		if(a%i == 0) return false;
    	}
    	return true;
    }

}
