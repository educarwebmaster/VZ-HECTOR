using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EXP_MAT_1_U1 : MonoBehaviour
{
	public RETROS Controlador;
	public DPRBASE[] drops1, drops2, drops3;
	public GameObject[] mascara, actividades, contenedor;
	public bool[] correctos;
	public Sprite[] estados;

		void Update()
	{
		for(int i=0;i<drops3.Length;i++)
		{
			if (drops3[i].Ocupado == true)
			{
				DRRBASE d = drops3[i].transform.GetChild(0).gameObject.GetComponent<DRRBASE>();
				int dd = int.Parse("" + d.ID);
				drops3[i].gameObject.GetComponent<Image>().sprite = estados[dd];
			}
		}
	} 

	public void validar ()
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
        mascara[0].SetActive(true);
        StartCoroutine(Cambiar(1));
    }
	

	
	public void validar1 ()
    {
        for(int i=0;i<drops3.Length;i++)
        {
            if(drops3[i].transform.childCount > 0)
            {
                DRRBASE d= drops3[i].transform.GetChild(0).gameObject.GetComponent<DRRBASE>();
                if( d.ID == drops3[i].ID)
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

	public void validar2 ()
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

		public IEnumerator Cambiar(int s)
		{
		yield return new WaitForSeconds (2);
		for (int i=0;i<actividades.Length;i++)
		{
			actividades[i].SetActive(false);
		}
		actividades[s].SetActive(true);
		Controlador.Informacion_mostrar(s);
		}

		    public IEnumerator finalizar ()
        {
            yield return new WaitForSeconds (2);
                Controlador.Verficar(Controlador.Correctos,5);
                StartCoroutine(Controlador.FINAL());
        }

        public void randomizar ()
	{
		for (int i=0;i<contenedor.Length;i++)
		{
            for (int e=0;e<contenedor[i].transform.childCount;e++)
            {
                contenedor[i].transform.GetChild(e).transform.SetSiblingIndex(Random.Range(0,2));
            }
			
		}
	}


        public void Restore ()
        {
            Controlador.Restore();

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

         for(int i=0;i<drops3.Length;i++)
        {
            if(drops3[i].transform.childCount > 0)
            {
                drops3[i].gameObject.GetComponent<Image>().sprite=estados[3];
                DRRBASE d= drops3[i].transform.GetChild(0).gameObject.GetComponent<DRRBASE>();
                d.enabled=true;
                d.transform.GetChild(0).gameObject.SetActive(false);
                d.transform.GetChild(1).gameObject.SetActive(false);
                d.Restore();
                drops3[i].Ocupado=false;
            }
        }


        }
}
