using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class  COMPRENDE_LENG_3_U1_system{
  public Image[] imagenes;  
}

public class COMPRENDE_LENG_3_U1 : MonoBehaviour {

	public RETROS controlador;
	public GameObject[] defi;
	public COMPRENDE_LENG_3_U1_system[] image;
	public int[] respuestas, seleccionado;
	public int pos, val;
	public Sprite rojo, verde, normal;

	public void randomico ()
	{
		for (int i=0;i<defi.Length;i++)
		{
			defi[i].transform.SetSiblingIndex(Random.Range(0,4));
		}
	}

public void posicion (int p)
{
	pos = p;
}

public void valor (int v)
{
	val = v;
	seleccionado[pos] = val;
}

public void validar ()
{
	for (int i=0;i<respuestas.Length;i++)
		{
			if (respuestas[i] == seleccionado[i])
			{
				controlador.Aumentar();
				image[i].imagenes[seleccionado[i]-1].sprite = verde;
			}
			else
			{
				controlador.Disminuir();
				image[i].imagenes[seleccionado[i]-1].sprite = rojo;
			}

		}
		StartCoroutine(final());
}

		public IEnumerator final()
		{
			yield return new WaitForSeconds (2);
			controlador.Verficar(controlador.Correctos,3);
			StartCoroutine(controlador.FINAL());
		}

		public void Restore ()
		{
			controlador.Restore();

			for (int i=0;i<respuestas.Length;i++)
			{
				seleccionado[i]=0;
				image[i].imagenes[0].sprite = normal;
				image[i].imagenes[1].sprite = normal;
				image[i].imagenes[0].transform.parent.gameObject.transform.parent.gameObject.GetComponent<Toggle>().isOn = false;
				image[i].imagenes[1].transform.parent.gameObject.transform.parent.gameObject.GetComponent<Toggle>().isOn = false;
				pos=0;
				val=0;
			}

		}
		

}
