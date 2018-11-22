using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MATEMATICAS_EXP_11_6 : MonoBehaviour 
{
	public RETROS controlador;
	public InputField resultado1, resultado2, resultado3;
	
	public GameObject[] actividades, infos, chulos, malos;

	public DPORDER[] drops;

	public IEnumerator Cambiar(int s)
	{
		yield return new WaitForSeconds(2);
		for(int i=0;i<actividades.Length;i++)
		{
			actividades[i].SetActive(false);
		}
		actividades[s].SetActive(true);
		controlador.Info(infos[s]);	
	}

	public void validar1()
	{
		for(int i=0;i<drops.Length;i++)
		{
			DRORDER ficha = drops[i].transform.GetChild(0).gameObject.GetComponent<DRORDER>(); 
			if (ficha.ID == drops[i].ID)
			{
				ficha.transform.GetChild(0).gameObject.SetActive(true);
				controlador.Aumentar();
			}else
			{
				ficha.transform.GetChild(1).gameObject.SetActive(true);
				controlador.Disminuir();
			}
			ficha.transform.GetChild(2).gameObject.SetActive(true);
		}
		StartCoroutine(Cambiar(1));
	}

	public void validar2 ()
	{
		if (resultado1.text=="6")
		{
			chulos[0].SetActive(true);
			controlador.Aumentar();
			
		}else 
		{
			malos[0].SetActive(true);
			controlador.Disminuir();
		}

		if (resultado2.text=="3.75")
		{
			chulos[1].SetActive(true);
			controlador.Aumentar();
		}else
		{
			malos[1].SetActive(true);
			controlador.Disminuir();
		}

		if (resultado3.text=="18")
		{
			chulos[2].SetActive(true);
			controlador.Aumentar();
		}else
		{
			malos[2].SetActive(true);
			controlador.Disminuir();
		}
		StartCoroutine(finalizar());
	}
		public IEnumerator finalizar ()
		{
			yield return new WaitForSeconds (2);
				controlador.Verficar(controlador.Correctos,4);
				StartCoroutine(controlador.FINAL());
		}

		public void Restore()
		{
			controlador.Restore();
			resultado1.text="";
			resultado2.text="";
			resultado3.text="";

			for(int i=0;i<chulos.Length;i++)
			{
				chulos[i].SetActive(false);
			}

			for(int i=0;i<malos.Length;i++)
			{
				malos[i].SetActive(false);
			}
			for(int i=0;i<actividades.Length;i++)
			{
				actividades[i].SetActive(false);
			}
			for(int i=0;i<drops.Length;i++)
			{
					DRORDER ficha = drops[i].transform.GetChild(0).gameObject.GetComponent<DRORDER>(); 
					
					ficha.transform.GetChild(0).gameObject.SetActive(false);
					ficha.transform.GetChild(1).gameObject.SetActive(false);
					ficha.transform.GetChild(2).gameObject.SetActive(false);
					ficha.RestoreLayout();
			}
			
		}

}
