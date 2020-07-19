using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathsTextScript : MonoBehaviour
{
    Text text;
    public static int deathAmaunt;

    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        text.text = deathAmaunt.ToString("0");
    }
}
