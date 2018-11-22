using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EX_NAT_U3 : MonoBehaviour {

	public RETROS controlador;
	public GameObject[] contenedor, chulo, mal, infos; 
	public DPRBASE[] drops; 



	public void randomizar ()
	{
		for(int e = 0;e < contenedor.Length;e++)
		{
			int o = Random.Range(0,4);
			contenedor[e].transform.SetSiblingIndex(o);
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
	


	public IEnumerator finalizar ()
		{
			yield return new WaitForSeconds (2);
				controlador.Verficar(controlador.Correctos,3);
				StartCoroutine(controlador.FINAL());
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

	

	
		
	
	

		
	

