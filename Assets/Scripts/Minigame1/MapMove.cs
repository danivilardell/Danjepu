using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMove : MonoBehaviour
{

	[SerializeField] private float speed;
	public bool started;

	void Start() {
		started = false;
	}

    void Update()
    {
        if(started) transform.position += new Vector3(0, 1, 0) * speed * Time.deltaTime;
    }
}
