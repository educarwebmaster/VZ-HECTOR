using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class NATURALES_EXP_10_U4_sistem{
	public Sprite fondo1;
	public Sprite[] img;
}
public class NATURALES_EXP_10_U4 : MonoBehaviour {

 	public RETROS Controlador;
	public  NATURALES_EXP_10_U4_sistem[] Info;
	public GameObject[] drops,contents;
	public GameObject infos,bueno,malo;
	public Image fondo1;
	public Image[] img;
	public int slide,puntos;

	public void Estasblecer(int i){
		bueno.SetActive(false);
		malo.SetActive(false);
		for(int e = 0;e < drops.Length;e++){
			int o = Random.Range(0,2);
			contents[e].transform.SetSiblingIndex(o);
		}
		fondo1.sprite = Info[i].fondo1;
		//retro.sprite = Info[i].retro;
		for(int e = 0;e < Info[i].img.Length;e++){
			img[e].sprite = Info[i].img[e];
		}
	}

	public void Avanzar(){
		
		for(int i = 0;i < drops.Length;i++){
			if(drops[i].transform.childCount > 0){
				if(drops[i].transform.GetChild(0).gameObject.GetComponent<DRRBASE>().ID == drops[i].GetComponent<DPRBASE>().ID){
					puntos++;
					Controlador.Aumentar();
					bueno.SetActive(true);
				}else{
					Controlador.Disminuir();
					malo.SetActive(true);
				}
				drops[i].transform.GetChild(0).gameObject.GetComponent<DRRBASE>().enabled = true;
				drops[i].transform.GetChild(0).gameObject.GetComponent<DRRBASE>().Restore();
				drops[i].GetComponent<DPRBASE>().Ocupado = false;
			}else{
				puntos++;
				Controlador.Disminuir();
			}
		}
		slide++;
		if(slide == 3){
			Controlador.Verficar(Controlador.Correctos,5);
			StartCoroutine(Controlador.FINAL());
		}else{
			StartCoroutine(Segir());
			//Controlador.Info(infos);
		}

		
	}

	public IEnumerator Segir(){
		yield return new WaitForSeconds(2);
		Estasblecer(slide);
	}

	public void Restore(){
		bueno.SetActive(false);
		malo.SetActive(false);
		slide = 0;
		puntos = 0;
		Estasblecer (0);
	}
}
