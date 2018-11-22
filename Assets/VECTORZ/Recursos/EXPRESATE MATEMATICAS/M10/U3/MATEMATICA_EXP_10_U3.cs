using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class MATEMATICA_EXP_10_U3_sistem{
	public Sprite fondo1, fondo2;
	public int Info;
	public Sprite[] img;
}

public class MATEMATICA_EXP_10_U3 : MonoBehaviour {
	public RETROS Controlador;
	public  MATEMATICA_EXP_10_U3_sistem[] Info;
	public GameObject[] drops,contents;
	public GameObject infos;
	public Image fondo1, fondo2;
	public Image[] img;
	public int slide,puntos;

	public void Estasblecer(int i){
		for(int e = 0;e < drops.Length;e++){
			int o = Random.Range(0,2);
			contents[e].transform.SetSiblingIndex(o);
		}
		fondo1.sprite = Info[i].fondo1;
		fondo2.sprite = Info[i].fondo2;
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
				}else{
					Controlador.Disminuir();
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
			Controlador.Verficar(Controlador.Correctos,3);
			StartCoroutine(Controlador.FINAL());
		}else{
			Estasblecer(slide);
			//Controlador.Info(infos);
		}

		
	}

	public void Restore(){
		slide = 0;
		puntos = 0;
		Estasblecer (0);
	}
}
