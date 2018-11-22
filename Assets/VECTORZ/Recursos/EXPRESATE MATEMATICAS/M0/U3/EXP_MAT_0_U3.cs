using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EXP_MAT_0_U3 : MonoBehaviour
{
	public RETROS controlador;
	public Sprite[] normal, seleccionado, validado, escenas, normal2, seleccionado2, validado2;	
	public Image[] botones, botones2;
	public bool[] estado, correctos, estados2, correctos2;

	public GameObject[] actividades, contenedor, mascara;

	public int slider;


    public void capturar (int s)
    {
        if (estado[s])
        {
            estado[s]= false;
			botones[s].sprite=normal[s];
        }
        else 
        {
			estado[s]=true;
            botones[s].sprite=seleccionado[s];
        }
	}
    
	public void validar1 ()
	{
		for(int i=0; i<estado.Length;i++)
		{
			if(estado[i])
			{
				if(estado[i]== correctos[i])
				{
					controlador.Aumentar();
				}
				else
				{
					controlador.Disminuir();
				}	
				botones[i].sprite=validado[i];
			}
		}
		mascara[0].SetActive(true);
		StartCoroutine(Cambiar(1));
	}

	 public void capturar2 (int s)
    {
        if (estados2[s])
        {
            estados2[s]= false;
			botones2[s].sprite=normal2[s];
        }
        else 
        {
			estados2[s]=true;
            botones2[s].sprite=seleccionado2[s];
        }
	}
	public void validar2 ()
	{
		for(int i=0; i<estados2.Length;i++)
		{
			if(estados2[i])
			{
				if(estados2[i]== correctos2[i])
				{
					controlador.Aumentar();
				}
				else
				{
					controlador.Disminuir();
				}	
				botones2[i].sprite=validado2[i];
			}
		}
		mascara[1].SetActive(true);
		StartCoroutine(finalizar());
	}
		public IEnumerator Cambiar(int s){
	yield return new WaitForSeconds (2);
	for (int i=0;i<actividades.Length;i++)
	{
		actividades[i].SetActive(false);
	}
	actividades[s].SetActive(true);	
}

	

	 public IEnumerator finalizar ()
    {
        yield return new WaitForSeconds (2);
        controlador.Verficar(controlador.Correctos - controlador.Incorrectos,6);
        StartCoroutine(controlador.FINAL());
	}

	public void randomizar ()
	{
		for (int i=0;i<contenedor.Length;i++)
		{
			contenedor[i].transform.SetSiblingIndex(Random.Range(0,5));
		}
	}

	public void Restore()
	{
		controlador.Restore();

		for(int i=0;i<botones.Length;i++)
        {
            botones[i].sprite = normal[i];  
			estado[i]=false;
        }

			for(int i=0;i<botones2.Length;i++)
        {
            botones2[i].sprite = normal2[i];
			estados2[i]=false;  
        }

		mascara[0].SetActive(false);
		mascara[1].SetActive(false);

	}

}
