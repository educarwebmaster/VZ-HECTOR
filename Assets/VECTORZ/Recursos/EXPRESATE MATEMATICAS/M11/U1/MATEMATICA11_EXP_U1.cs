using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[System.Serializable]
public class MATEMATICA11_EXP_U1_sistem{
	public Sprite[] botones_act,botones_des;
	public Sprite fondo;
	public int respuestas;
}
public class MATEMATICA11_EXP_U1 : MonoBehaviour {
	public MATEMATICA11_EXP_U1_sistem[] SISTEM;
	public RETROS Controlador;
	public GameObject mascara;
	public int puntos,slide,temporal;
	public Image[] imgs;
	public Image fondo;

	public void Cambiar(int slides){
		fondo.sprite = SISTEM[slide].fondo;
	   for(int i = 0;i<imgs.Length;i++){
		   imgs[i].sprite = SISTEM[slide].botones_des[i];
		   imgs[i].transform.GetChild(0).gameObject.SetActive(false);
		   imgs[i].transform.GetChild(1).gameObject.SetActive(false);
	   }
	}

	public void Verificar(int i){
		for(int it = 0;it<imgs.Length;it++){
			imgs[it].sprite = SISTEM[slide].botones_des[it];
		}
		temporal = i;
		imgs[i].sprite = SISTEM[slide].botones_act[i];
	}

	public void Termine(){
		mascara.SetActive(true);
		if(temporal == SISTEM[slide].respuestas){
			puntos++;
			imgs[temporal].transform.GetChild(0).gameObject.SetActive(true);
			Controlador.Aumentar();
		}else{
			imgs[temporal].transform.GetChild(1).gameObject.SetActive(true);
			Controlador.Disminuir();
		}
		StartCoroutine("saltar");
	}

	public IEnumerator saltar(){
		yield return new WaitForSeconds(2);
		slide++;
		if(slide == imgs.Length){
			Controlador.Verficar(puntos,2);
			StartCoroutine(Controlador.FINAL());
		}else{
			Cambiar(slide);
		}
		mascara.SetActive(false);
	}

	public void Restore(){
		puntos = 0;
		slide = 0;
		Cambiar(0);
	}
}
