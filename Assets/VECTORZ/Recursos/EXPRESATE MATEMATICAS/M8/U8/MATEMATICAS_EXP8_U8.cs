using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MATEMATICAS_EXP8_U8 : MonoBehaviour 
{

	public RETROS controlador;
	public Toggle[] radios;
	public GameObject[] calificacion;
	public GameObject[] calificacionbueno, calificacionmalo;

	public GameObject [] escenas;
	public InputField resultado, resultadoa1, resultadoa2;

	public void aumentar()
	{
    controlador.Aumentar();	
	}
	public void disminuir ()	
	{
   controlador.Disminuir();	
	}
	
	public void validar ()
	{
	for (int i=0;i<radios.Length;i++)
	{
		if (radios[i].isOn)
		{
			if (i>0)
			{
				aumentar();
			}else {
				disminuir();
			}
		calificacion[i].SetActive(true);
		}
		StartCoroutine(cambiar(1));
	}
	}

	public void validar2 ()
	{
		if (resultado.text == "37.5")
		{
			calificacionbueno[0].SetActive(true);
			aumentar();
			
		}else{
			calificacionmalo[0].SetActive(true);
			disminuir();
			
			}
			StartCoroutine(cambiar(2));
	}
	
	public void validar3 ()
	{
		if (resultadoa1.text == "15" )
		{
			calificacionbueno[1].SetActive(true);
			aumentar();
			
		}else{
			calificacionmalo[1].SetActive(true);
			disminuir();
			
		}
		if (resultadoa2.text == "60")
		{
			calificacionbueno[2].SetActive(true);
			aumentar();
			
		}else{
			calificacionmalo[2].SetActive(true);
			disminuir();
			
		}
	StartCoroutine(ultimo());
	} 
	public IEnumerator ultimo ()
	{
		yield return new WaitForSeconds (2);
			controlador.Verficar(controlador.Correctos,4);
	StartCoroutine(controlador.FINAL());
	}

	public IEnumerator cambiar (int escena)
	{
		yield return new WaitForSeconds (2);
		for (int j=0;j<escenas.Length;j++)
		{
			escenas[j].SetActive(false);
		}
		escenas[escena].SetActive(true);
	}	

	public void Restore()
	{
		controlador.Restore();
		resultado.text="";
		resultadoa1.text="";
		resultadoa2.text="";
		for (int i=0;i<calificacion.Length;i++)
		{
			calificacion[i].SetActive(false);
		}
		for (int i=0;i<calificacionbueno.Length;i++)
		{
			calificacionbueno[i].SetActive(false);
		}
		for (int i=0;i<calificacionmalo.Length;i++)
		{
			calificacionmalo[i].SetActive(false);
		}
		for (int i=0;i<escenas.Length;i++)
		{
			escenas[i].SetActive(false);
		}
		for (int i=0;i<radios.Length;i++)
		{
			radios[i].isOn=false;
		}
	}


}
