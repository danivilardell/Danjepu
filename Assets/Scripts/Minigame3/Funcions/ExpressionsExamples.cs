/*

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

!!! necessari !!!
using B83.ExpressionParser;
!!! necessari !!!

// la pagina web on ho he trobat
// http://wiki.unity3d.com/index.php/ExpressionParser

var parser = new ExpressionParser();
Expression exp = parser.EvaluateExpression("(5+3)*8^2-5*(-2)");
Debug.Log("Result: " + exp.Value);  // prints: "Result: 522"
 
Debug.Log("Result: " + parser.Evaluate("ln(e^5)"));  // prints: "Result: 5"
 
 
// unknown identifiers are simply translated into parameters:
 
Expression exp2 = parser.EvaluateExpression("sin(x*PI/180)");
exp2.Parameters["x"].Value = 45; // set the named parameter "x"
Debug.Log("sin(45°): " + exp2.Value); // prints "sin(45°): 0.707106781186547" 
 
 
// convert the expression into a delegate:
 
var sinFunc = exp2.ToDelegate("x");
Debug.Log("sin(90°): " + sinFunc(90)); // prints "sin(90°): 1" 
 
 
// It's possible to return multiple values, but it generates extra garbage for each call due to the return array:
 
var exp3 = parser.EvaluateExpression("sin(angle/180*PI) * length,cos(angle/180*PI) * length");
var f = exp3.ToMultiResultDelegate("angle", "length");
double[] res = f(45,2);  // res contains [1.41421356237309, 1.4142135623731]
 
 
// To add custom functions to the parser, you just have to add it before parsing an expression:
 
parser.AddFunc("test", (p) => {
    Debug.Log("TEST: " + p.Length);
    return 42;
});
Debug.Log("Result: "+parser.Evaluate("2*test(1,5)")); // prints "TEST: 2" and "Result: 84"
 
 
// NOTE: functions without parameters are not supported, use "constants" instead:
parser.AddConst("meaningOfLife", () => 42);
Console.WriteLine("Result: " + parser.Evaluate("2*meaningOfLife")); // prints "Result: 84"
*/
