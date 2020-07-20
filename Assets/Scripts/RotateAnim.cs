using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAnim : MonoBehaviour
{

	public KeyCode run1;
    public KeyCode run2;
    
    void Update()
    {
       	if(Input.GetKey(run1))  gameObject.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
       	else if(Input.GetKey(run2)) {
       		gameObject.transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
       	}
    }
}
