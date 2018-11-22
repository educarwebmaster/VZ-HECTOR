using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EXP_MAT_5_U1 : MonoBehaviour 
{
	 public RETROS controlador;
	 public InputField resultados;
	 public int slider;
	 public Sprite[] escenas;
	 public GameObject mascara, chulo, mal, trasportador;
	 public Image fondo;
	 public string[] respuestamin, respuestamax;
	 public bool trasestado;

	 public void validar()
	{
		if (int.Parse(resultados.text) >= int.Parse(respuestamin[slider]) && int.Parse(resultados.text) <= int.Parse(respuestamax[slider]))
		{
			controlador.Aumentar();
			chulo.SetActive(true);
		}
		else
		{
			controlador.Disminuir();
			mal.SetActive(true);
		}
		slider++;
		mascara.SetActive(true);
		if (slider == 4)
		{
			StartCoroutine(finalizar());
		}
		else
		{
			StartCoroutine (cambiar(slider));
		}
		
	}

	public IEnumerator cambiar(int s)
	{
		yield return new WaitForSeconds (2);
		mascara.SetActive(false);
		chulo.SetActive(false);
		mal.SetActive(false);
		fondo.sprite=escenas[s];
		resultados.text="";	
		trasportador.GetComponent<DRRSIN>().Restore();
		trasportador.SetActive(false);
		trasestado=false;
	}	

	public IEnumerator finalizar ()
        {
            yield return new WaitForSeconds (2);
                controlador.Verficar(controlador.Correctos,3);
                StartCoroutine(controlador.FINAL());
        }


	public void aparecer()
	{
		if (trasestado)
		{
			trasestado = false;
			trasportador.SetActive(false);
		}
		else
		{
			trasestado = true;
			trasportador.SetActive(true);
		}
	}
	
	public void Restore()
	{
		controlador.Restore();
		chulo.SetActive(false);
		mal.SetActive(false);
		mascara.SetActive(false);
		fondo.sprite=escenas[0];
		resultados.text="";
		slider=0;
		trasportador.GetComponent<DRRSIN>().Restore();
		trasportador.SetActive(false);
	}
}



