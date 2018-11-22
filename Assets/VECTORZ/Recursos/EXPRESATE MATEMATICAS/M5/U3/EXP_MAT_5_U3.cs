using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EXP_MAT_5_U3 : MonoBehaviour
{
	public RETROS controlador;
    public GameObject[] mascara, actividades, ficha1, ficha2;
	public GameObject chulo, mal;
	public DPRBASE[] drops1, drops2;
	public InputField resultado;

	public void randomizar ()
    {
        for (int i=0;i<ficha1.Length;i++)
        {
            ficha1[i].transform.SetSiblingIndex(Random.Range(0,3));
        }
        for (int i=0;i<ficha2.Length;i++)
        {
            ficha2[i].transform.SetSiblingIndex(Random.Range(0,3));
        }
    }


	public void validar1 ()
	{
		if (resultado.text == "9430")
		{
			chulo.SetActive(true);
			controlador.Aumentar();
			
		}else 
		{	
			mal.SetActive(true);
			controlador.Disminuir();
			
		}
		mascara[0].SetActive(true);
		StartCoroutine(Cambiar(1));
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
                    controlador.Aumentar();
                    d.transform.GetChild(0).gameObject.SetActive(true);
                }
                else
                {
                    controlador.Disminuir();
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
                    controlador.Aumentar();
                    d.transform.GetChild(0).gameObject.SetActive(true);
                }
                else
                {
                    controlador.Disminuir();
                    d.transform.GetChild(1).gameObject.SetActive(true);
                }
            }
        }
        mascara[2].SetActive(true);
        StartCoroutine(finalizar());
    }

	    public IEnumerator Cambiar(int s)
		{
			yield return new WaitForSeconds (2);
			for (int i=0;i<actividades.Length;i++)
			{
				actividades[i].SetActive(false);
			}
			actividades[s].SetActive(true);
			controlador.Informacion_mostrar(s);     

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
		resultado.text="";
		chulo.SetActive(false);
		mal.SetActive(false);


		for(int i=0;i<mascara.Length;i++)
		{
			mascara[i].SetActive(false);
		}

		for(int i=0;i<actividades.Length;i++)
		{
			actividades[i].SetActive(false);
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
