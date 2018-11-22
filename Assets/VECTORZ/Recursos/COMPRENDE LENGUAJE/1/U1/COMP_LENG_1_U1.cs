using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class COMP_LENG_1_U1 : MonoBehaviour 
{
	public RETROS controlador;
	public bool[] estados;
	public Sprite[] animal, letra;

	public Image[] imagenes, rando; 
	public int s1,p1, contador;
	public GameObject popup;

	public void cambiar(int posicion)
	{
		if(estados[posicion])
		 {
			estados[posicion] = false;
			imagenes[posicion].sprite = animal[posicion];
		 }else
		 {
			 estados[posicion] = true;
			 imagenes[posicion].sprite = letra[posicion]; 
		 }
	}

	public void seleccion1 (int s)
	{
		s1 = s;
		popup.SetActive(true);
	}

		public void seleccion2 (int p)
	{
		p1 = p;
		popup.SetActive(false);
		contador++;
		if (p1 == s1)
		{
			rando[s1].transform.GetChild(0).gameObject.SetActive(true);
			controlador.Aumentar();
			rando[s1].raycastTarget=false;
		}else
		{
			rando[s1].transform.GetChild(1).gameObject.SetActive(true);
			controlador.Disminuir();
			rando[s1].raycastTarget=false;
			//palabras[p].gameObject.SetActive(false);
		}


		if (contador == 27)
		{
			controlador.Verficar2(controlador.Correctos, 17);
		}
	}

	
	public void randomico()
	{
		for (int i=0;i<rando.Length;i++)
		{
			rando[i].transform.SetSiblingIndex(Random.Range(0,26));
		}
	}


	public void Restore()
	{
		controlador.Restore();
		contador = 0;
		for (int i=0;i<rando.Length;i++)
		{
			rando[i].raycastTarget=true;
			rando[i].transform.GetChild(0).gameObject.SetActive(false);
			rando[i].transform.GetChild(1).gameObject.SetActive(false);
            imagenes[i].sprite = animal[i];

        }
	}

	 
}

