using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class COMPRENDE_MAT4_U1 : MonoBehaviour {
	public RETROS controlador;
	public GameObject[] fondos, contenedor1, contenedor2; 
	public DPRBASE[] drop, drops2; 


		public void validar () 
		{
			for(int i = 0;i < drop.Length;i++)
			{
				if (drop[i].transform.childCount>0){
					DRRBASE d =  drop[i].transform.GetChild(0).gameObject.GetComponent<DRRBASE>();
					if (d.ID == drop[i].ID)
					{
						d.transform.GetChild(0).gameObject.SetActive(true);
						controlador.Aumentar();
					}else
					{
						d.transform.GetChild(1).gameObject.SetActive(true);
						controlador.Disminuir();
					}
				}
			}
			StartCoroutine(FondosA(1,2));
		}
		
		public void validar2 () 
		{
			for(int i = 0;i < drops2.Length;i++)
			{
				if (drops2[i].transform.childCount>0){
					DRRBASE d =  drops2[i].transform.GetChild(0).gameObject.GetComponent<DRRBASE>();
					if (d.ID == drops2[i].ID)
					{
						d.transform.GetChild(0).gameObject.SetActive(true);
						controlador.Aumentar();
					}else
					{
						d.transform.GetChild(1).gameObject.SetActive(true);
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
				controlador.Verficar(controlador.Correctos,6);
				StartCoroutine(controlador.FINAL());
		}

		public void randomizar ()
		{
			for (int i=0;i<contenedor1.Length;i++)
			{
				contenedor1[i].transform.SetSiblingIndex(Random.Range(0,7));
			}
			for (int i=0;i<contenedor2.Length;i++)
			{
				contenedor2[i].transform.SetSiblingIndex(Random.Range(0,7));
			}
		}



		public void Restore()
		{
			controlador.Restore();

			for(int e = 0;e < drop.Length;e++)
		{
			if (drop[e].transform.childCount>0){
				DRRBASE m = drop[e].transform.GetChild(0).gameObject.GetComponent<DRRBASE>();
				m.transform.GetChild(0).gameObject.SetActive(false);
				m.transform.GetChild(1).gameObject.SetActive(false);
				m.enabled = true;
				m.Restore();
				drop[e].Ocupado = false;
			}

		}

		for(int e = 0;e < drops2.Length;e++)
		{
			if (drops2[e].transform.childCount>0){
				DRRBASE m = drops2[e].transform.GetChild(0).gameObject.GetComponent<DRRBASE>();
				m.transform.GetChild(0).gameObject.SetActive(false);
				m.transform.GetChild(1).gameObject.SetActive(false);
				m.enabled = true;
				m.Restore();
				drops2[e].Ocupado = false;
			}

		}

		}
}
