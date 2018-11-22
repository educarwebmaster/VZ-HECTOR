using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ringlete_C_U4 : MonoBehaviour {

	public RETROS controlador;
	public GameObject[]  chulo, mal, fondos; 
	public DPRBASE[] drops; 
	public void pasar1 ()
	{
		StartCoroutine(FondosA(1,6));
		randomizar();
	}

	public void randomizar ()
	{
		for(int e = 0;e < drops.Length;e++)
		{
			int o = Random.Range(0,3);
			drops[e].transform.SetSiblingIndex(o);
		}
	}

	public void validar () 
	{
		for(int i = 0;i < drops.Length;i++)
		{
			if (drops[i].transform.childCount>0){
				DRRBASE d =  drops[i].transform.GetChild(0).gameObject.GetComponent<DRRBASE>();
				if (d.ID == drops[i].ID)
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

			StartCoroutine(finalizar());	
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


	public IEnumerator finalizar ()
		{
			yield return new WaitForSeconds (2);
				controlador.Verficar2(controlador.Correctos,3);
				
		}

	public void Restoe()
	{
		controlador.Restore();
		
		for(int e = 0;e < drops.Length;e++)
		{
			if (drops[e].transform.childCount>0){
				DRRBASE m = drops[e].transform.GetChild(0).gameObject.GetComponent<DRRBASE>();
				m.enabled = true;
				m.Restore();
				drops[e].Ocupado = false;
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

		

	}

}
