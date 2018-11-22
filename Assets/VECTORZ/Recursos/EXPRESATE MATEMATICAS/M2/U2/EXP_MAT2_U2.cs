using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class EXP_MAT2_U2 : MonoBehaviour 
{

	public RETROS Controlador;
	public GameObject[] ficha1, ficha2, mascara, actividades;
	public bool[] seleccion, correctos1;
	public Image[] botones;
	public Sprite[] normal, selec;
	public DPRBASE[] drops1, drops2;

	public void selecciones(int s)
	{
		if(seleccion[s])
		{
			seleccion[s]=false;
			botones[s].sprite= normal[s];
		}
		else
		{
			seleccion[s]=true;
			botones[s].sprite= selec[s];
		}
	}

	public void randomizar ()
	{
		for (int i=0;i<ficha1.Length;i++)
		{
			ficha1[i].transform.SetSiblingIndex(Random.Range(0,2));
		}
		for (int i=0;i<ficha2.Length;i++)
		{
			ficha2[i].transform.SetSiblingIndex(Random.Range(0,2));
		}
	}


	public void validar()
	{
		for(int i=0;i<botones.Length;i++)
		{	
			if(seleccion[i])
			{
				if(seleccion[i] == correctos1[i])
				{
					Controlador.Aumentar();
					botones[i].transform.GetChild(0).gameObject.SetActive(true);
				}
				else
				{
					Controlador.Disminuir();
					botones[i].transform.GetChild(1).gameObject.SetActive(true);
				}
			}
		}
		mascara[0].SetActive(true);
		StartCoroutine(Cambiar(1));
	}

	public IEnumerator Cambiar(int s){
	yield return new WaitForSeconds (2);
	for (int i=0;i<actividades.Length;i++)
	{
		actividades[i].SetActive(false);
	}
	actividades[s].SetActive(true);
	Controlador.Informacion_mostrar(s);		

}


	public void validar2 ()
	{
		for(int i=0;i<drops1.Length;i++)
		{
			if(drops1[i].transform.childCount > 0)
			{
				DRRBASE d= drops1[i].transform.GetChild(0).gameObject.GetComponent<DRRBASE>();
				if( d.ID == drops1[i].ID)
				{
					Controlador.Aumentar();
					d.transform.GetChild(0).gameObject.SetActive(true);
				}
				else
				{
					Controlador.Disminuir();
					d.transform.GetChild(1).gameObject.SetActive(true);
				}
			}
		}
		mascara[1].SetActive(true);
		StartCoroutine(Cambiar(2));
	}

	public void validar3 ()
	{
		for(int i=0;i<drops2.Length;i++)
		{
			if(drops2[i].transform.childCount > 0)
			{
				DRRBASE d= drops2[i].transform.GetChild(0).gameObject.GetComponent<DRRBASE>();
				if( d.ID == drops2[i].ID)
				{
					Controlador.Aumentar();
					d.transform.GetChild(0).gameObject.SetActive(true);
				}
				else
				{
					Controlador.Disminuir();
					d.transform.GetChild(1).gameObject.SetActive(true);
				}
			}
		}
		mascara[2].SetActive(true);

	StartCoroutine(finalizar());
	}

	public IEnumerator finalizar ()
		{
			yield return new WaitForSeconds (2);
				Controlador.Verficar(Controlador.Correctos,5);
				StartCoroutine(Controlador.FINAL());
		}

	public void Restore ()
	{
		Controlador.Restore();


		for(int i=0;i<seleccion.Length;i++)
		{
			seleccion[i]= false;
			botones[i].sprite=normal[i];
			botones[i].transform.GetChild(0).gameObject.SetActive(false);
			botones[i].transform.GetChild(1).gameObject.SetActive(false);
			
		}
		
		for(int i=0;i<mascara.Length;i++)
		{
			mascara[i].SetActive(false);
		}

		for(int i=0;i<drops1.Length;i++)
		{
			if(drops1[i].transform.childCount > 0)
			{
				DRRBASE d= drops1[i].transform.GetChild(0).gameObject.GetComponent<DRRBASE>();
				d.enabled=true;
				d.transform.GetChild(0).gameObject.SetActive(false);
				d.transform.GetChild(1).gameObject.SetActive(false);
				d.Restore();
				drops1[i].Ocupado=false;
			}
		}
		
		for(int i=0;i<drops2.Length;i++)
		{
			if(drops2[i].transform.childCount > 0)
			{
				DRRBASE d= drops2[i].transform.GetChild(0).gameObject.GetComponent<DRRBASE>();
				d.enabled=true;
				d.transform.GetChild(0).gameObject.SetActive(false);
				d.transform.GetChild(1).gameObject.SetActive(false);
				d.Restore();
				drops2[i].Ocupado=false;
			}
		}
	}

}
