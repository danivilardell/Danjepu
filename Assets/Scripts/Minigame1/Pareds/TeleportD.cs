using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportD : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

     void OnCollisionEnter2D(Collision2D collision) 
     {
         // faria algo com collision.transform.position.x = -collision.transform.position.x
         // pero no funciona, ho he buscat i es veu que s'ha de fer algo aixi :( es super feo.
         Vector3 p = collision.transform.position;
         // el +1 es per prevenir bugs de teleportacio infinita
         p[0] = -p[0] + 1;
         collision.transform.position = p;
     }
}
