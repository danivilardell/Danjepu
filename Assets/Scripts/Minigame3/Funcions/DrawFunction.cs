using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using B83.ExpressionParser;
using System;

public class DrawFunction : MonoBehaviour
{
    GameObject graph;

    public List<Vector2> points;

    private EdgeCollider2D col;
    private LineRenderer line;
    private GameObject inputText;
    public GameObject exceptionCanvas;
    //private var parser;

    // Start is called before the first frame update
    void Start() {
        Restart();
    }

    public void Restart()
    {
        graph = gameObject;
        col = graph.transform.GetComponentInChildren<EdgeCollider2D>();
        line = graph.GetComponentInChildren<LineRenderer>();
        inputText = graph.transform.Find("Canvas").Find("InputField").Find("Text").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space)) 
        // {
        //     FuncToPoints();
        //     col.points = points.ToArray();
        //     int j = points.Count;
        //     line.positionCount = j;
        //     for (int i = 0; i < j; ++i) line.SetPosition(i, points[i]);
        // }
    }

    void FuncToPoints(string f) 
    {
        var parser = new ExpressionParser();
        Expression exp = parser.EvaluateExpression(f);
        // Expression exp = parser.EvaluateExpression("sin(x*PI/180)");

        points = new List<Vector2>();
        // ho escalo per que aixi no depen del "scale" de la grafica
        float xscale = graph.transform.localScale[0];
        float yscale = graph.transform.localScale[1];
        
        for (float x = -7.65f; x <= 7f; x += .01f) {
            exp.Parameters["x"].Value = x; // set the named parameter "x"
            points.Add( new Vector2(x/xscale, (float) (exp.Value)/yscale) );
            //points.Add( new Vector2(i/xscale, (i*i)/yscale) );
        }
    }

    public void NewFunction() 
    {
        string function = inputText.GetComponent<Text>().text;
	    try {
	        FuncToPoints(function);
	        // amb el collider simplement es pot fer aixo
	        col.points = points.ToArray();
	        // amb el line renderer, com que es 3D sembla que s'ha de fer aquest arreglo
	        StartCoroutine(DrawGradually());
	    }
	    catch (Exception e) {
	    	Debug.Log("hola");
	        exceptionCanvas.SetActive(true);
	        StartCoroutine(Wait2Seconds());
	        exceptionCanvas.SetActive(false);
	    }  
        
        
    }

    public IEnumerator DrawGradually() {
        int j = points.Count;
        for (int i = 0; i < j; ++i) {
            line.positionCount = i + 1;
            line.SetPosition(i, points[i]);
            if(i%16 == 0) yield return new WaitForSeconds(0.0001f);
        }
    }

    public IEnumerator Wait2Seconds() {
        yield return new WaitForSeconds(2f);
    }

}
