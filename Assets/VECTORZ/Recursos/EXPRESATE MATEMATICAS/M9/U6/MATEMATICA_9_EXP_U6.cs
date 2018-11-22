using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MATEMATICA_9_EXP_U6 : MonoBehaviour {
	public RETROS Controlador;
	public int[] seleccionados,correctos;
	public int Slider;
	public GameObject[] Buenos,Malos,Actividades;
	public void Asignar(int Boton){
		seleccionados[Slider] = Boton;
	}

	public void Verificar(){
		if(seleccionados[Slider] == correctos[Slider]){
			Controlador.Aumentar();
			Buenos[Slider].SetActive(true);
		}else{
			Controlador.Disminuir();
			Malos[Slider].SetActive(true);
		}
		StartCoroutine(Cambiar());
	}

	public IEnumerator Cambiar(){
		yield return new WaitForSeconds(2);
		Saltar();
	}

	public void Saltar(){
		for(int i = 0;i<Buenos.Length;i++){
			Buenos[i].SetActive(false);
		}
		for(int i = 0;i<Malos.Length;i++){
			Malos[i].SetActive(false);
		}
		Buenos[Slider].SetActive(false);
		Malos[Slider].SetActive(false);
		Slider++;
		if(Slider==3){
			Controlador.Verficar(Controlador.Correctos,3);
			StartCoroutine(Controlador.FINAL());
		}else{
			for(int i = 0;i<Actividades.Length;i++){
				Actividades[i].SetActive(false);
			}
			Actividades[Slider].SetActive(true);
		}
	}

	public void Restore(){
		Slider = 0;
		for(int i = 0;i<Buenos.Length;i++){
			Buenos[i].SetActive(false);
		}
		for(int i = 0;i<Malos.Length;i++){
			Malos[i].SetActive(false);
		}
	}

}
