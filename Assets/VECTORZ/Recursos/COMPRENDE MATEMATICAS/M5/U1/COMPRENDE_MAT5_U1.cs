using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class  COMPRENDE_MAT5_U1_system{
 public GameObject[] imagenes;   
 public Image boton;
 public Sprite bnormal, bsobre;
 public int cantidad, mayor, menor;



 public void sumar ()
 {
	if (cantidad < mayor)
	{
		
		imagenes[cantidad].SetActive(true);
		cantidad++;
	}
 }

 public void restar()
 {
	if (cantidad > menor)
	{
		cantidad--;
		imagenes[cantidad].SetActive(false);
		
	}
 }

}

[System.Serializable]
public class  COMPRENDE_MAT5_U1_system2{
 public GameObject[] imagenes;   
 public Image boton;
 public GameObject flecha;

 public int cantidad, mayor, menor;


 public void sumar ()
 {
	if (cantidad < mayor)
	{
		
		imagenes[cantidad].SetActive(true);
		cantidad++;
	}
 }

 public void restar()
 {
	if (cantidad > menor)
	{
		cantidad--;
		imagenes[cantidad].SetActive(false);
	
	}
 }

}


public class COMPRENDE_MAT5_U1 : MonoBehaviour 
{
	public RETROS controlador;
	public COMPRENDE_MAT5_U1_system[] imagenes;
	public COMPRENDE_MAT5_U1_system2[] imagenes2;
	public InputField resultado1, resultado2;
	public int posicion, posicion2; 
	public int[] respuestas1, respuestas2;
	public GameObject[] chulo, mal, actividades;
	public Scrollbar restaur;


	public void camposicion (int s)
	{
		for(int i=0;i<imagenes.Length;i++)
		{
			imagenes[i].boton.sprite= imagenes[i].bnormal;
		}
			imagenes[s].boton.sprite= imagenes[s].bsobre;
			posicion=s;
	}

		public void camposicion2 (int s)
	{
			for(int i=0;i<imagenes2.Length;i++)
		{
			imagenes2[i].flecha.SetActive(false);
		}
			imagenes2[s].flecha.SetActive(true);
			posicion2=s;
	}

	 public void restar()
 	{
		imagenes[posicion].restar();	
	}

	 public void sumar()
 	{
		imagenes[posicion].sumar();	
	}

	 public void restar2()
 	{
		imagenes2[posicion2].restar();	
	}

	 public void sumar2()
 	{
		imagenes2[posicion2].sumar();	
	}
	public void validar1 ()
	{
		for(int i=0;i<imagenes.Length;i++)
		{
			if (imagenes[i].cantidad == respuestas1[i] )
			{
				controlador.Aumentar();
				chulo[0].SetActive(true);

			}
			else
			{
				controlador.Disminuir();
				mal[0].SetActive(true);
			}
			controlador.Informacion_mostrar(2);
		}	StartCoroutine(Cambiar(2));
	}	

	public void validar2 ()
	{
		for(int i=0;i<imagenes2.Length;i++)
		{
			if (imagenes2[i].cantidad == respuestas2[i] )
			{
				controlador.Aumentar();
				chulo[1].SetActive(true);

			}
			else
			{
				controlador.Disminuir();
				mal[1].SetActive(true);
			}
			controlador.Informacion_mostrar(3);
		}StartCoroutine(Cambiar(3));

		
	}	
 	public void validar3 ()
	{
		
		if (resultado1.text  == "19" && resultado2.text == "6")
		{
			controlador.Aumentar();
			chulo[2].SetActive(true);

			
		}else
		{
			controlador.Disminuir();
			mal[2].SetActive(true);

		}

		StartCoroutine(finalizar());

	}
		public IEnumerator finalizar ()
		{
			yield return new WaitForSeconds (2);
				controlador.Verficar(controlador.Correctos,9);
				StartCoroutine(controlador.FINAL());
		}

			public IEnumerator Cambiar(int s){
		yield return new WaitForSeconds (2);
		for (int i=0;i<actividades.Length;i++)
		{
			actividades[i].SetActive(false);
		}
		actividades[s].SetActive(true);
			
}

	public void Restore()
	{
		controlador.Restore();
		restaur.gameObject.SetActive(false);
		restaur.value=0;
		restaur.gameObject.SetActive(true);
		resultado1.text="";
		resultado2.text="";
		posicion=0;
		posicion2=0;

		for (int i=0;i<actividades.Length;i++)
		{
			actividades[i].SetActive(false);
		}

		for (int i=0;i<chulo.Length;i++)
		{
			chulo[i].SetActive(false);
		}

			for (int i=0;i<mal.Length;i++)
		{
			mal[i].SetActive(false);
		}

		for (int i=0;i<imagenes.Length;i++)
		{	
			imagenes[i].cantidad=0;
			imagenes[i].boton.sprite=imagenes[i].bnormal;
			for (int j=0;j<imagenes[i].imagenes.Length;j++)
			{	
				imagenes[i].imagenes[j].SetActive(false);
			}
		}

		for (int i=0;i<imagenes2.Length;i++)
		{	
			imagenes2[i].cantidad=0;
			imagenes2[i].flecha.SetActive(false);
			for (int j=0;j<imagenes2[i].imagenes.Length;j++)
			{
				imagenes2[i].imagenes[j].SetActive(false);
			}
		}



	}





	
		
	
}
