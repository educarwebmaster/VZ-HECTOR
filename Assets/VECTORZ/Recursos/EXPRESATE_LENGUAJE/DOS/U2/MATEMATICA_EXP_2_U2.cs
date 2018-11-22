using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MATEMATICA_EXP_2_U2 : MonoBehaviour {
	public RETROS Controlador;
	public GameObject[] Actividades,Contenedor,Infos,Botones;
	public Sprite[] ImagenesSelect;
	public Sprite[] ImagenesNormal;
	public int slider,boton;
	public bool Selec;
	
	public void Saltar(){
		StartCoroutine("SaltarActividad");
	}

	public void Bueno(){
		Selec = true;
	}

	public void Malo(){
		Selec = false;
	}

	public void Seleccion(int i){
		boton = i;
	}

	public IEnumerator SaltarActividad(){
		Botones[boton].GetComponent<Image>().sprite = ImagenesSelect[boton];
		for(int i = 0; i < Botones.Length;i++){
			Botones[i].GetComponent<Image>().raycastTarget = false;
		}
		yield return new WaitForSeconds(3);
		for(int i = 0; i < Botones.Length;i++){
			Botones[i].GetComponent<Image>().raycastTarget = true;
		}
		if(Selec){
			Controlador.Aumentar();
		}else{
			Controlador.Disminuir();
		}
		Selec= false;
		for(int i = 0; i < Actividades.Length;i++){
			Actividades[i].SetActive(false);
			Contenedor[i].transform.GetChild(0).SetSiblingIndex(Random.Range(0,2));
		}
		slider++;
		if(slider == 3){
			Controlador.Verficar(Controlador.Correctos,3);
			StartCoroutine(Controlador.FINAL());
		}
		Controlador.Info(Infos[slider]);
		Actividades[slider].SetActive(true);
	}

	public void Restore(){
		for(int i = 0; i < Botones.Length;i++){
			Botones[i].GetComponent<Image>().raycastTarget = true;
		}
		Controlador.Restore();
		slider= 0;
		boton= 0;
		Selec = false;
		for(int i = 0; i < Botones.Length;i++){
			Botones[i].GetComponent<Image>().sprite = ImagenesNormal[i];
		}
		
	}
}
