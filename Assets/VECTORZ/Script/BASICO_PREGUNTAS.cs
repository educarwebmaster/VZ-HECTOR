using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System;

[System.Serializable]
public class BASICO_PREGUNTAS_array
{
    public int Correcto;
    public string Respuesta;
    public string Pregunta;
    public string Array1;
    public string Array2;
    public string Array3;
    public string Array4;
}

public class BASICO_PREGUNTAS : MonoBehaviour {
    public BASICO_PREGUNTAS_array[] Datos;
    public Text[] Textos;
    public GameObject RetroBuena;
    public GameObject RetroMala;
    public GameObject Retroalimentacion;
    public int Correctos;
    public int Incorrectos;
    public int contador;
    public int contadorBuenos;
    public int Estados;
    public Text Buenos;
    public Text Malos;
    public Text Informacion;
    public bool Iniciar;
    public GameObject Inicial;
    public GameObject Actividad;
    public GENERAL_INTERFAZ General;

	// Use this for initialization
	void Start () {
        if (Iniciar)
        {
            General.Abrir_visor_3d();
        }
        else
        {
            Estados = 0;
            contador = 0;
            Crear(Estados);
        }
	}

	// Update is called once per frame
	void Update () {
        if (Iniciar)
        {
            General.Abrir_visor_3d();
        }
        else
        {
            Buenos.text = "" + Correctos;
            Malos.text = "" + Incorrectos;
        }
    }

    public void Crear(int Estado)
    {
        Textos[0].text = "" + Datos[Estado].Array1;
        Textos[1].text = "" + Datos[Estado].Array2;
        Textos[2].text = "" + Datos[Estado].Array3;
        Textos[3].text = "" + Datos[Estado].Array4;
        Informacion.text = Datos[Estado].Pregunta;
    }

    public void Verificar(int res)
    {
        if (Datos[Estados].Correcto == res)
        {
            Correctos++;
            Estados++;
        }
        else
        {
            Incorrectos++;
            Estados++;
        }
        if (Estados == Datos.Length){
            if (Correctos >= (Datos.Length/2)){
                RetroB();
                Estados=0;
            }else{
                RetroM();   
                Estados=0;    
            }
        }else{
            Crear(Estados);
        }
    }

    public void Restore()
    {
            RetroBuena.SetActive(false);
            RetroMala.SetActive(false);
            Correctos = 0;
            Incorrectos = 0;
            Estados=0;
            Inicial.SetActive(true);
            Actividad.SetActive(false);
            Crear(Estados);
    }

    public void RetroB()
    {
        RetroBuena.SetActive(true);
        RetroMala.SetActive(false);
        Inicial.SetActive(true);
        Actividad.SetActive(false);
        Retroalimentacion.SetActive(true);
    }

    public void RetroM()
    {
        RetroBuena.SetActive(false);
        RetroMala.SetActive(true);
        Inicial.SetActive(true);
        Actividad.SetActive(false);
        Retroalimentacion.SetActive(true);
    }
}
