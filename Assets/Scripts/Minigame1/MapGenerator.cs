using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{

	public Transform prefab;
	[SerializeField] private Transform prefabWallR;
	public Transform prefabWallL;
	public static int interval = 50;
	public static int numeroBase = 2;
	[SerializeField] public int initheight;
	[SerializeField] public float initheightWall = 22.26f;
	public static int contador = 0;
	private bool prime;
	private int randomNum;
	private float[] posicions = {0f, 0f, 0f};
	public static  int it = 1;

	public void Restart() {
		if(!DisplayHighscore.ISLEGENDARY) {
			contador = 0;
			interval = 50;
			numeroBase = 2;
		}
		else {
			contador = 0;
			interval = 200;
			numeroBase = 100;
		}
	}

	public void creaPlataformes() {
		for(int i = 0; i < 2; i++) {
			prime = false;
			System.Random r = new System.Random();
			randomNum = r.Next(numeroBase, numeroBase + interval);
			if(isPrimeNum(randomNum)) prime = true;
			prefab.gameObject.GetComponent<ChooseNumber>().number = randomNum;
			posicions[0] = Random.Range(-8.5f, 8.5f);
			Instantiate(prefab, new Vector3(posicions[0], initheight + contador, 0), Quaternion.identity).transform.parent = GameObject.Find("PlataformesNoves").transform;



			randomNum = r.Next(numeroBase, numeroBase + interval);
			if(isPrimeNum(randomNum)) prime = true;
			prefab.gameObject.GetComponent<ChooseNumber>().number = randomNum;
			posicions[1] = Random.Range(-8.5f, 8.5f);
			while(Mathf.Abs(posicions[1] - posicions[0]) < 3.3) {
				posicions[1] = Random.Range(-8.5f, 8.5f);
			}
			Instantiate(prefab, new Vector3(posicions[1], initheight + contador, 0), Quaternion.identity).transform.parent = GameObject.Find("PlataformesNoves").transform;


			randomNum = r.Next(numeroBase, numeroBase + interval);
			while(!isPrimeNum(randomNum) && !prime) {
				randomNum = r.Next(numeroBase, numeroBase + interval);
			}
			prefab.gameObject.GetComponent<ChooseNumber>().number = randomNum;
			posicions[2] = Random.Range(-8.5f, 8.5f);
			while(Mathf.Abs(posicions[2] - posicions[0]) < 3.3 || Mathf.Abs(posicions[2] - posicions[1]) < 3.3) {
				posicions[2] = Random.Range(-8.5f, 8.5f);
			}
			Instantiate(prefab, new Vector3(posicions[2], initheight + contador, 0), Quaternion.identity).transform.parent = GameObject.Find("PlataformesNoves").transform;
			contador += 2;
		}

		if(contador%6 == 0 || contador%6 == 1) {
			if(!DisplayHighscore.ISLEGENDARY) {
				interval = (int)(1.2 * interval);
				numeroBase += 7*it;
			} 
			Instantiate(prefabWallR, new Vector3(10, initheightWall + 16.4f * it, 0), Quaternion.identity).transform.parent = GameObject.Find("ParedsNoves").transform;
			Instantiate(prefabWallL, new Vector3(-10, initheightWall + 16.4f * it, 0), Quaternion.identity).transform.parent = GameObject.Find("ParedsNoves").transform;
			it++;
		}
		if(contador%4 == 0 || contador%4 == 1 && DisplayHighscore.ISLEGENDARY) {
			interval = (int)1.7 * interval;
			numeroBase += 30*it;
		}

	}

	private bool isPrimeNum(int a) {
    	if(a < 2) return false;
    	for(int i = 2; i*i <= a; i++) {
    		if(a%i == 0) return false;
    	}
    	return true;
    }

    public static int CONTADOR {
        get {
            return contador;
        }
        set {
            contador = value;
        }
    }

    public static int IT {
        get {
            return it;
        }
        set {
            it = value;
        }
    }

    public static int INTERVAL {
        get {
            return interval;
        }
        set {
            interval = value;
        }
    }

    public static int NUMEROBASE {
        get {
            return numeroBase;
        }
        set {
            numeroBase = value;
        }
    }
}
