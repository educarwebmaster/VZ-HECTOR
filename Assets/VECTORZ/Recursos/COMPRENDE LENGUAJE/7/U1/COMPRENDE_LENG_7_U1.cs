using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class COMPRENDE_LENG_7_U1 : MonoBehaviour {

	public RETROS controlador;
	public GameObject[]  chulo, chulo2, mal, mal2, fondos; 
	public DPRBASE[] drops1, drops2; 



	public void validar () 
	{
		for(int i = 0;i < drops1.Length;i++)
		{
			if (drops1[i].transform.childCount>0){
				DRRBASE d =  drops1[i].transform.GetChild(0).gameObject.GetComponent<DRRBASE>();
				if (d.ID == drops1[i].ID)
				{
					chulo[i].SetActive(true);
					controlador.Aumentar();
				}else
				{
					mal[i].SetActive(true);
					controlador.Disminuir();
				}
			}
		}
		StartCoroutine(FondosA(1,2));
	}
	
	public IEnumerator FondosA (int escena, int tiempo)
		{
			yield return new WaitForSeconds (tiempo);
				for(int i=0;i<fondos.Length;i++)
				{

					fondos[i].SetActive(false);
				}
				fondos[escena].SetActive(true);
		}



	public void validar2 () 
	{
		for(int i = 0;i < drops2.Length;i++)
		{
			if (drops2[i].transform.childCount>0){
				DRRBASE d =  drops2[i].transform.GetChild(0).gameObject.GetComponent<DRRBASE>();
				if (d.ID == drops2[i].ID)
				{
					chulo2[i].SetActive(true);
					controlador.Aumentar();
				}else
				{
					mal2[i].SetActive(true);
					controlador.Disminuir();
				}
			}
		}

			StartCoroutine(finalizar());	
	}
	

	public IEnumerator finalizar ()
		{
			yield return new WaitForSeconds (2);
				controlador.Verficar(controlador.Correctos,6);
				StartCoroutine(controlador.FINAL());
				
		}

	public void Restore()
	{
		controlador.Restore();

		for(int e = 0;e < drops1.Length;e++)
		{
			if (drops1[e].transform.childCount>0){
				DRRBASE m = drops1[e].transform.GetChild(0).gameObject.GetComponent<DRRBASE>();
				m.enabled = true;
				m.Restore();
				drops1[e].Ocupado = false;
			}

		}

		
		for(int e = 0;e < drops2.Length;e++)
		{
			if (drops2[e].transform.childCount>0){
				DRRBASE m = drops2[e].transform.GetChild(0).gameObject.GetComponent<DRRBASE>();
				m.enabled = true;
				m.Restore();
				drops2[e].Ocupado = false;
			}

		}

		for (int i=0;i<chulo.Length;i++)
		{
			chulo[i].SetActive(false);
		}

		for (int i=0;i<mal.Length;i++)
		{
			mal[i].SetActive(false);
		}

		for (int i=0;i<chulo2.Length;i++)
		{
			chulo2[i].SetActive(false);
		}

		for (int i=0;i<mal2.Length;i++)
		{
			mal2[i].SetActive(false);
		}

		

	}

}




