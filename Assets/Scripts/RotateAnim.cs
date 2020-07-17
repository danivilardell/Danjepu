using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAnim : MonoBehaviour
{

	public KeyCode run1;
    public KeyCode run2;
    
    void Update()
    {
       	if(Input.GetKey(run1)) transform.eulerAngles = new Vector3(0, 0, 0);
       	else if(Input.GetKey(run2)) transform.eulerAngles = new Vector3(0, 180, 0); 
    }
}
