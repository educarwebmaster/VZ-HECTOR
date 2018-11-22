using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MATEMATICA_EXP_11_U5 : MonoBehaviour {
public RETROS controlador;
public GameObject[] contenedor1, contenedor2, respuestaD, respuestaR, actividades, contenedorA2, infos;

public Color colornormal, colorclick;
public int dominio, rango, actividad2;

public InputField resultado1, resultado2a, resultado2b, resultado3;


public void randomizar ()
{
	for (int i=0;i<contenedor1.Length;i++)
	{
		contenedor1[i].transform.SetSiblingIndex(Random.Range(0,3));
	}
	for (int i=0;i<contenedor2.Length;i++)
	{
		contenedor2[i].transform.SetSiblingIndex(Random.Range(0,3));
	}
}

public void capturar (int boton)
{
	if (boton<4)
	{
		dominio = boton;
		for (int i=0;i<contenedor1.Length;i++){
			contenedor1[i].GetComponent<Image>().color=colornormal;
		}
		contenedor1[boton].GetComponent<Image>().color=colorclick;
	}else 
	{
		rango = boton;
		for (int i=0;i<contenedor2.Length;i++){
			contenedor2[i].GetComponent<Image>().color=colornormal;
		}
		contenedor2[boton-4].GetComponent<Image>().color=colorclick;
	}


}
public IEnumerator Cambiar(int s){
	yield return new WaitForSeconds (2);
	for (int i=0;i<actividades.Length;i++)
	{
		actividades[i].SetActive(false);
	}
	actividades[s].SetActive(true);
	controlador.Info(infos[s]);		
}

public void validar()
{
	if (dominio == 0)
	{
		controlador.Aumentar();
	}else
	{
		controlador.Disminuir();
	}
	respuestaD[dominio].SetActive(true);

	if (rango == 4)
	{
		controlador.Aumentar();
	}else
	{
		controlador.Disminuir();
	}
	respuestaR[rango-4].SetActive(true);
	StartCoroutine(Cambiar(1));
	randomizar2();
}

public void randomizar2 ()
{
	for (int i=0;i<contenedorA2.Length;i++)
	{
		contenedorA2[i].transform.SetSiblingIndex(Random.Range(0,3));
	}
}

public void capturar2(int boton2)
{
		actividad2 = boton2;
		for (int i=0;i<contenedorA2.Length;i++)
		{
			contenedorA2[i].GetComponent<Image>().color=colornormal;
		}
		contenedorA2[boton2].GetComponent<Image>().color=colorclick;
}
public void validar2 () 
{
	if (actividad2 == 0)
	{
		controlador.Aumentar();
	}
	else
	{
		controlador.Disminuir();
	}
	contenedorA2[actividad2].transform.GetChild(0).gameObject.SetActive(true);
	StartCoroutine(Cambiar(2));
}

public void validar3 ()
	{
		if (resultado1.text == "-6")
		{
			controlador.Aumentar();
			resultado1.transform.GetChild(2).gameObject.SetActive(true);
		}else{
			resultado1.transform.GetChild(3).gameObject.SetActive(true);
			controlador.Disminuir();
		}
		if (resultado2a.text  == "-6" && resultado2b.text == "0")
		{
			resultado2a.transform.GetChild(2).gameObject.SetActive(true);
			controlador.Aumentar();
			
		}else{
			resultado2a.transform.GetChild(3).gameObject.SetActive(true);
			controlador.Disminuir();
		}
		if (resultado3.text  == "0")
		{
			resultado3.transform.GetChild(2).gameObject.SetActive(true);
			controlador.Aumentar();
			
		}else{
			resultado3.transform.GetChild(3).gameObject.SetActive(true);
			controlador.Disminuir();
		}

		StartCoroutine(finalizar());

	}
	public IEnumerator finalizar ()
	{
		yield return new WaitForSeconds (2);
		controlador.Verficar(controlador.Correctos,5);
		StartCoroutine(controlador.FINAL());
	}
	public void Restore()
	{
		dominio=0;
		rango=0; 
		actividad2=0;	

		for (int i=0;i<contenedor1.Length;i++)
		{
			contenedor1[i].GetComponent<Image>().color=colornormal;
		}

		for (int i=0;i<contenedor2.Length;i++)
		{
			contenedor2[i].GetComponent<Image>().color=colornormal;
		}

		for (int i=0;i<actividades.Length;i++)
		{
		actividades[i].SetActive(false);
		}

		for (int i=0;i<contenedorA2.Length;i++)
		{
			contenedorA2[i].GetComponent<Image>().color=colornormal;
			contenedorA2[i].transform.GetChild(0).gameObject.SetActive(false);
		}

		for (int i=0;i<respuestaR.Length;i++)
		{
			respuestaR[i].SetActive(false);
		}
			for (int i=0;i<respuestaD.Length;i++)
		{
			respuestaD[i].SetActive(false);
		}
		controlador.Restore();
		resultado1.text="";
		resultado2a.text=""; 
		resultado2b.text=""; 
		resultado3.text="";
		resultado1.transform.GetChild(2).gameObject.SetActive(false);
		resultado1.transform.GetChild(3).gameObject.SetActive(false);
		resultado2a.transform.GetChild(2).gameObject.SetActive(false);
		resultado2a.transform.GetChild(3).gameObject.SetActive(false);
		resultado3.transform.GetChild(2).gameObject.SetActive(false);
		resultado3.transform.GetChild(3).gameObject.SetActive(false);
	}
}	
