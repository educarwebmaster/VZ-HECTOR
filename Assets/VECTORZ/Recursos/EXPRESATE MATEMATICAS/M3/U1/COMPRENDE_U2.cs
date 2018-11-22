using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class COMPRENDE_U2 : MonoBehaviour {

	public RETROS controlador;
	public GameObject[] drops,chulo, mal, actividades, infos; 
	public DPRBASE[] drops2; 
	public Image[]  retro;
	public Sprite[] sprite;
	public DropMultiple resultados1;

	public void randomizar ()
	{
		for(int e = 0;e < drops.Length;e++)
		{
			int o = Random.Range(0,5);
			drops[e].transform.SetSiblingIndex(o);
		}
	}

	public void validar()
	{
		for(int i = 0;i < resultados1.transform.childCount;i++)
		{
			DragMultiple d =  resultados1.transform.GetChild(i).gameObject.GetComponent<DragMultiple>();
			if (d.ID == 0)
			{
				d.transform.GetChild(0).gameObject.SetActive(true);
				controlador.Aumentar();
			}else
			{
				d.transform.GetChild(0).gameObject.SetActive(true);
				controlador.Disminuir();
			}
			StartCoroutine(Cambiar(1));
		}
	} 
	public void validar2 () 
	{
		for(int i = 0;i < drops2.Length;i++)
		{
			if (drops2[i].transform.childCount>0){
				DRRBASE d =  drops2[i].transform.GetChild(0).gameObject.GetComponent<DRRBASE>();
				if (d.ID == drops2[i].ID)
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
	
	public IEnumerator Cambiar(int s){
	yield return new WaitForSeconds (2);
	for (int i=0;i<actividades.Length;i++)
	{
		actividades[i].SetActive(false);
	}
	actividades[s].SetActive(true);
	controlador.Info(infos[s]);		

}
	

	public IEnumerator finalizar ()
		{
			yield return new WaitForSeconds (2);
				controlador.Verficar(controlador.Correctos,5);
				StartCoroutine(controlador.FINAL());
		}

	public void Restoe()
	{
		controlador.Restore();
	    int gg = resultados1.transform.childCount;
		DragMultiple[] d = new DragMultiple[gg];

		for(int i = 0;i < gg;i++)
		{
					d[i] =  resultados1.transform.GetChild(i).gameObject.GetComponent<DragMultiple>();

		}
		if (resultados1.transform.childCount>0){
			for(int i = 0;i < gg;i++)
			{
					
					d[i].enabled = true;
					d[i].Restore();
					d[i].transform.GetChild(0).gameObject.SetActive(false);
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

		for (int i=0;i<actividades.Length;i++)
		{
		actividades[i].SetActive(false);
		}
		



	}

	
}
