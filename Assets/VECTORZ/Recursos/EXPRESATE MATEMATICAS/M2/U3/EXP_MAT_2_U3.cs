using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EXP_MAT_2_U3 : MonoBehaviour 
{

	public RETROS controlador;
    public Sprite[] normal, clickselect, escenas;
    public GameObject chulo, mal, mascara, contenedor;
    public Image[] botones;
    public Image fondo;
    public bool[] estado;
    public int[] correctos;
    public int slider;

	public void randomizar ()
	{
		for (int i=0;i<botones.Length;i++)
		{
			botones[i].transform.SetSiblingIndex(Random.Range(0,2));
		}
	}

    public void capturar (int s)
    {
        estado[s]= false;
        mascara.SetActive(true);
        if (s == correctos[slider])
        {
            chulo.SetActive(true);
            botones[s].sprite=clickselect[s];
            controlador.Aumentar();
        }
        else 
        {
            mal.SetActive(true);
            controlador.Disminuir();
        }
        slider++;
        if (slider == 3)
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
            for(int i=0;i<botones.Length;i++)
            {
                botones[i].sprite = normal[i];  
            }
        mascara.SetActive(false);
        chulo.SetActive(false);
        mal.SetActive(false);
		randomizar();
    }
    
            public IEnumerator finalizar ()
        {
            yield return new WaitForSeconds (2);
                controlador.Verficar(controlador.Correctos,2);
                StartCoroutine(controlador.FINAL());
        }

    
    public void Restore()
    {
        controlador.Restore();
        mascara.SetActive(false);
        chulo.SetActive(false);
        mal.SetActive(false);
        fondo.sprite=escenas[0];
        slider=0;
    

        for(int i=0;i<botones.Length;i++)
        {
            botones[i].sprite = normal[i];  
        }

        
    }
        

}
