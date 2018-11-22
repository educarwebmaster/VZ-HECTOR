using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class EXP_MAT1_U1 : MonoBehaviour 
{
	public RETROS controlador;
	
	public InputField[] resultado;
	public string[] respuesta;
	public GameObject[] chulo, mal, escenas, mascara;

	public void validar ()
{
	mascara[0].SetActive(true);
	if (resultado[0].text == respuesta[0] && resultado[1].text  == respuesta[1] )
	{
		controlador.Aumentar();
		chulo[0].SetActive(true);

	}
	else
	{
		controlador.Disminuir();
		mal[0].SetActive(true);
	}
	StartCoroutine (Cambiar(1));

}

public void validar1 ()
{	
	mascara[1].SetActive(true);
	if (resultado[2].text == respuesta[2] && resultado[3].text  == respuesta[3] && respuesta[4] == resultado[4].text )
	{
		controlador.Aumentar();
		chulo[1].SetActive(true);
	}
	else
	{
		controlador.Disminuir();
		mal[1].SetActive(true);
	}
	StartCoroutine (Cambiar(2));

}

public void validar2 ()
{	
	mascara[2].SetActive(true);
	if (resultado[5].text == respuesta[5] && resultado[6].text  == respuesta[6] )
	{
		controlador.Aumentar();
		chulo[2].SetActive(true);
	}
	else
	{
		controlador.Disminuir();
		mal[2].SetActive(true);
	}
	StartCoroutine (Cambiar(3));

}

public void validar3 ()
{
	mascara[3].SetActive(true);
	if (resultado[7].text == respuesta[7] && resultado[8].text  == respuesta[8] )
	{
		controlador.Aumentar();
		chulo[3].SetActive(true);
	}
	else
	{
		controlador.Disminuir();
		mal[3].SetActive(true);
	}
	StartCoroutine (Cambiar(4));

}

public void validar4 ()
{
	mascara[4].SetActive(true);
	if (resultado[9].text == respuesta[9] && resultado[10].text  == respuesta[10] )
	{
		controlador.Aumentar();
		chulo[4].SetActive(true);
	}
	else
	{
		controlador.Disminuir();
		mal[4].SetActive(true);
	}
	StartCoroutine (finalizar());

}

public IEnumerator finalizar ()
		{
			yield return new WaitForSeconds (2);
				controlador.Verficar(controlador.Correctos,3);
				StartCoroutine(controlador.FINAL());
		}


public IEnumerator Cambiar(int s){
		yield return new WaitForSeconds (2);
		for(int i=0;i<escenas.Length;i++)
		{
			escenas[i].SetActive(false);
		}
		escenas[s].SetActive(true);
		

	}

public void Restore ()
{
	controlador.Restore();

	for(int i=0;i<resultado.Length;i++)
	{
		resultado[i].text="";
	}
	
	for(int i=0;i<chulo.Length;i++)
	{
		chulo[i].SetActive(false);
	}

	for(int i=0;i<mal.Length;i++)
	{
		mal[i].SetActive(false);
	}

	for(int i=0;i<escenas.Length;i++)
	{
		escenas[i].SetActive(false);
	}

	for(int i=0;i<mascara.Length;i++)
	{
		mascara[i].SetActive(false);
	}
}



}
