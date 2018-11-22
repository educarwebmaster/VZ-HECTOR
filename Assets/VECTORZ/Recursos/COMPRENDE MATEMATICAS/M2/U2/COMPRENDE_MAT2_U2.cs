using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class COMPRENDE_MAT2_U2_system{
public Sprite[] imagenes;

}

public class COMPRENDE_MAT2_U2 : MonoBehaviour {

	public RETROS controlador;
	public COMPRENDE_MAT2_U2_system[] imagenes;
	public DPRBASE[] drop;
	public GameObject chulo, mal;
	public Image[] botones;
	public bool ocupado;
	public int slider;

	public void validar ()
	{
		for (int i=0; i<drop.Length; i++){
			if (drop[i].transform.childCount>0){
					DRRBASE d =  drop[i].transform.GetChild(0).gameObject.GetComponent<DRRBASE>();
					if (d.ID == drop[i].ID)
					{
						chulo.SetActive(true);
						controlador.Aumentar();
					}else
					{
						mal.SetActive(true);
						controlador.Disminuir();
					}
			}
		}
		StartCoroutine (cambiar());
	}

	public IEnumerator cambiar ()
	{
		yield return new WaitForSeconds(2);
		if (slider == 4)
		{
			controlador.Verficar(controlador.Correctos,3);
				StartCoroutine(controlador.FINAL());
				
		}
		else
		{
			slider++;
			devolver();
		}
	
	}


	
	// Update is called once per frame
	void Update () {
		for (int i=0; i<drop.Length; i++){
			if (!ocupado){
				if (drop[i].Ocupado)
				{
					ocupado = true;
					validar();
				}
			}
			
		}
	}

	public void devolver()
	{
			
			ocupado = false;
			chulo.SetActive(false);
			mal.SetActive(false);
			for (int i=0; i<drop.Length; i++){
				if (drop[i].transform.childCount>0){
					DRRBASE d =  drop[i].transform.GetChild(0).gameObject.GetComponent<DRRBASE>();
					d.enabled = true;
					d.Restore();
					drop[i].Ocupado = false;
				}
				drop[i].gameObject.SetActive(false);
			}
			drop[slider].gameObject.SetActive(true);
			for (int i=0; i<botones.Length; i++){
				botones[i].sprite = imagenes[slider].imagenes[i];
				botones[i].transform.parent.transform.SetSiblingIndex(Random.Range(0,3));
			}
	}

	public void Restore()
	{
		slider = 0;
		devolver();
	}
}
