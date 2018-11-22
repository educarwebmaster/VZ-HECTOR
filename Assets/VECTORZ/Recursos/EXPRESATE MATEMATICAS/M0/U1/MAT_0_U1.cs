using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MAT_0_U1 : MonoBehaviour
{
	public RETROS controlador;
	public Sprite[] normal, clickbien, clickmal, escenas;
	public GameObject chulo, mal, mascara;
	public Image[] botones;
	public Image fondo;
	public bool[] estado;
	public int[] correctos;
	public Text respuesta;
	public string[] textos;
	public int slider;


	public void capturar (int s)
	{
		estado[s]= false;
		mascara.SetActive(true);
		respuesta.text = textos[s];
		if (s == correctos[slider])
		{
			chulo.SetActive(true);
			botones[s].sprite=clickbien[s];
			controlador.Aumentar();
		}
		else 
		{
			mal.SetActive(true);
			botones[s].sprite=clickmal[s];
			controlador.Disminuir();
		}
		slider++;
		if (slider == 5)
		{
			StartCoroutine(finalizar());
		}
		else
		{
			StartCoroutine (Cambiar(slider));	
		}
		
	}
	

	public IEnumerator Cambiar(int s)
	{
	yield return new WaitForSeconds (2);
			fondo.sprite=escenas[s];
			respuesta.text="";
			for(int i=0;i<botones.Length;i++)
			{
				botones[i].sprite = normal[i];  
			}
		mascara.SetActive(false);
		chulo.SetActive(false);
		mal.SetActive(false);
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
        mascara.SetActive(false);
		chulo.SetActive(false);
		mal.SetActive(false);
        respuesta.text="";
		fondo.sprite=escenas[0];
		slider=0;
	

		for(int i=0;i<botones.Length;i++)
		{
			botones[i].sprite = normal[i];  
		}

		
	}
		
	
}
