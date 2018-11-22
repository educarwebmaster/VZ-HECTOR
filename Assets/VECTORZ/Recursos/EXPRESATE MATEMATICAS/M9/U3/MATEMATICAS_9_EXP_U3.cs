using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MATEMATICAS_9_EXP_U3 : MonoBehaviour {
public GameObject NoSolucion, Solucion;
public InputField[] textos;
public float x_,y_;
public Text X, Y;

public void Start(){

}

public void Update(){
    
}

public void verificar (){
float resultado = Calcular(float.Parse(textos[0].text+".0"),float.Parse(textos[1].text+".0"),float.Parse(textos[2].text+".0"),float.Parse(textos[3].text+".0"),float.Parse(textos[4].text+".0"),float.Parse(textos[5].text+".0"));
    if (resultado!=0.0f){
        Solucion.SetActive(true);
        X.text=""+x_; 
        Y.text=""+y_;
    }else{
        NoSolucion.SetActive(true);
    }
}
public float Calcular(float a,float b, float c, float a1, float b1, float c1){
    float deter = ((a*b1) - (a1*b));
    if (deter!=0.0f){
        x_= ((c*b1)-(c1*b))/deter;
        y_= ((a*c1)-(a1*c))/deter;
    }
    return deter;
}

}
