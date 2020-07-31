using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{

	[SerializeField] GameObject player;

    void Update()
    {
        transform.position = new Vector3(0, player.transform.position.y + 2, -10);
    }

}
