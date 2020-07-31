using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContadorPunts : MonoBehaviour
{
    [SerializeField] private Text txt;
    [SerializeField] private Text txtDeath;
    public int punts;

    void Start()
    {
    	punts = 0;
        txt.text = punts.ToString();
    }

    public void CanviaPunts(float a) {
		punts = (int) a/2;
		txt.text = punts.ToString();
        txtDeath.text = "Your score is " + punts.ToString() + "!";
    	
    }
}
