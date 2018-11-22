using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class COMPRENDE_MAT5_3 : MonoBehaviour {
public RETROS controlador;

public InputField[] resultado1, resultado2;
public GameObject[] chulo, mal, escenas, vasos, vasos2;
public string[] respuestas1, respuestas2;
public bool[] estado, estados2;



public void validar (int s)
{
	if (resultado1[s].text == respuestas1[s] && resultado2[s].text  == respuestas2[s] )
	{
		controlador.Aumentar();
		chulo[s].SetActive(true);
	}
	else
	{
		controlador.Disminuir();
		mal[s].SetActive(true);
	}
	StartCoroutine (Cambiar(s+1));

}

	public IEnumerator Cambiar(int s){
		yield return new WaitForSeconds (2);
		for(int i=0;i<escenas.Length;i++)
		{
			escenas[i].SetActive(false);
		}
		escenas[s].SetActive(true);
		controlador.Informacion_mostrar(s);

	}

	public void seleccion (int r)
	{
		if (estado[r])
		{
			estado[r]= false;
			vasos[r].transform.GetChild(0).gameObject.SetActive(false);
		}
		else
		{
			estado[r]= true;
			vasos[r].transform.GetChild(0).gameObject.SetActive(true);
		}

	}

	public void validar3 ()
	{	
		int conta=0;
		for(int i=0;i<estado.Length;i++)
		{
			
		    if (estado[i] == true)
			{
				conta++;
			}
				
		}
		if (conta == 3)
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

		public void seleccion2 (int r)
			{
				if (estados2[r])
				{
					estados2[r]= false;
					vasos2[r].transform.GetChild(0).gameObject.SetActive(false);
				}
				else
				{
					estados2[r]= true;
					vasos2[r].transform.GetChild(0).gameObject.SetActive(true);
				}
						
			}


		public void validar4 ()
	{	
		int conta2=0;
		for(int i=0;i<estados2.Length;i++)
		{
			
		    if (estados2[i] == true)
			{
				conta2++;
			}
				
		}
		if (conta2 == 4)
		{
			controlador.Aumentar();
				chulo[3].SetActive(true);
		}
		else
		{
			controlador.Disminuir();
				mal[3].SetActive(true);
		}
		StartCoroutine(finalizar());
		
	}
	

	public IEnumerator finalizar ()
		{
			yield return new WaitForSeconds (2);
				controlador.Verficar(controlador.Correctos,3);
				StartCoroutine(controlador.FINAL());
		}

		public void Restore()
		{
			controlador.Restore();

			for (int i=0;i<escenas.Length;i++)
			{
				escenas[i].SetActive(false);
			}

			
			for (int i=0;i<chulo.Length;i++)
			{
				chulo[i].SetActive(false);
			}

				for (int i=0;i<mal.Length;i++)
			{
				mal[i].SetActive(false);
			}

			for (int i=0;i<resultado1.Length;i++)
			{
				resultado1[i].text= "" ;
			}

				for (int i=0;i<resultado2.Length;i++)
			{
				resultado2[i].text= "" ;
			}

			for (int i=0;i<vasos.Length;i++)
			{
				vasos[i].transform.GetChild(0).gameObject.GetComponent<Animator>().StopPlayback();
				vasos[i].transform.GetChild(0).gameObject.SetActive(false);
			}

			for (int i=0;i<vasos2.Length;i++)
			{
				vasos2[i].transform.GetChild(0).gameObject.GetComponent<Animator>().StopPlayback();
				vasos2[i].transform.GetChild(0).gameObject.SetActive(false);
			}

				for (int i=0;i<estado.Length;i++)
			{
				estado[i]= false;
			}

			for (int i=0;i<estados2.Length;i++)
			{
				estados2[i]= false;
			}
			

			

			


		}





}
