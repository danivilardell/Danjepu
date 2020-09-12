using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimRotatePhone : MonoBehaviour
{

    private float screenCenterX;


    void Start() {
        screenCenterX = Screen.width * 0.5f;
    }

    void Update()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).rawPosition.x > screenCenterX) {
            transform.eulerAngles = new Vector3(0,0,0);
        }
        else if(Input.touchCount > 0 && Input.GetTouch(0).rawPosition.x <= screenCenterX){
            transform.eulerAngles = new Vector3(0,180,0);
        }
    }
}
