using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterAnimPhone : MonoBehaviour
{

    private Animator anim;
    GameObject Player;
    private float screenCenterX;

    void Start()
    {
        Player = gameObject;
        anim = GetComponent<Animator>();
        screenCenterX = Screen.width * 0.5f;
    }

    void Update()
    {
        if (Input.touchCount > 0 && (Input.GetTouch(0).rawPosition.x < screenCenterX || Input.GetTouch(0).rawPosition.x >= screenCenterX)) {
            anim.SetBool("isRunning", true); 
        } else {
            anim.SetBool("isRunning", false);
        }
    }
}
