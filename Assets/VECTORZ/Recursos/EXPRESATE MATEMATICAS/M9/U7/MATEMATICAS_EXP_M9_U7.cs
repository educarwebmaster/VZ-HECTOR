using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MATEMATICAS_EXP_M9_U7 : MonoBehaviour {
	public RETROS Controlador;
	public GameObject[] Scenes,retros,chulos;
	public DROPDOWNS[] Drops;
	public InputField Tercero;
	public string[] Correctos;

	public void Validar1(){
		for(int i = 0;i < 3;i++){
			if(Drops[i].ItemSelect==Correctos[i]){
				Drops[i].transform.GetChild(2).gameObject.SetActive(true);
				Controlador.Aumentar();
			}else{
				Drops[i].transform.GetChild(3).gameObject.SetActive(true);
				Controlador.Disminuir();
			}
		}
		StartCoroutine(Cambiar(1,2));
	}

		
	public void Validar2(){
		for(int i = 3;i < 6;i++){
			if(Drops[i].ItemSelect==Correctos[i]){
				Drops[i].transform.GetChild(2).gameObject.SetActive(true);
				Controlador.Aumentar();
			}else{
				Drops[i].transform.GetChild(3).gameObject.SetActive(true);
				Controlador.Disminuir();
			}
		}
		StartCoroutine(Cambiar(2,2));
	}

	public void Validar3(){
		if(Tercero.text == "20"){
			chulos[0].SetActive(true);
			Controlador.Aumentar();
		}else{
			chulos[1].SetActive(true);
			Controlador.Disminuir();
		}
		StartCoroutine(Finalizar());
	}

	public void Restore(){
		for(int i = 0;i<Scenes.Length;i++){
			Scenes[i].SetActive(false);
		}
		Tercero.text = "";
	    chulos[0].SetActive(false);
		chulos[1].SetActive(false);
		for(int i = 0;i < Drops.Length;i++){
				Drops[i].transform.GetChild(2).gameObject.SetActive(false);
				Drops[i].transform.GetChild(3).gameObject.SetActive(false);
				Drops[i].ItemSelect = "Seleccionar";
				Drops[i].transform.GetChild(0).gameObject.GetComponent<Text>().text = "Seleccionar";
		}
	}

	public IEnumerator Cambiar(int escena,int tiempo){
		yield return new WaitForSeconds(tiempo);
		for(int i = 0;i<Scenes.Length;i++){
			Scenes[i].SetActive(false);
		}
		Controlador.Info(retros[escena]);
		Scenes[escena].SetActive(true);
	}

	public IEnumerator Finalizar()
	{
		yield return new WaitForSeconds(2);
		Controlador.Verficar(Controlador.Correctos,5);
		StartCoroutine(Controlador.FINAL());
	}
}
