using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacioRodesBici : MonoBehaviour
{
	private float speed = 200f;
	
    void Update() {
        transform.Rotate(0, 0, -Input.GetAxis("Horizontal")*speed*Time.deltaTime);
    }
}
