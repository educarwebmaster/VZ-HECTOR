using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MATEMATICA_EXP_11_U8 : MonoBehaviour {
	public RETROS Controlador;
	public int[] Correctos,Correctos2;
	public Toggle[] Grupo1,Grupo2;
	public GameObject[] Scenes,Infos,retros,retros2;

	public void Verificar1(){
		for(int i = 0;i<Grupo1.Length;i++){
			if(Grupo1[i].isOn == true){
				retros[i].SetActive(true);
				if(i == Correctos[i]){
					Controlador.Aumentar();
				}else{
					Controlador.Disminuir();
				}
				break;
			}
		}
		StartCoroutine(Cambiar(1,2));
		Controlador.Info(Infos[1]);
	}

	public void Verificar2(){
		for(int i = 0;i<Grupo2.Length;i++){
			if(Grupo2[i].isOn == true){
				retros2[i].SetActive(true);
				if(i == Correctos2[i]){
					Controlador.Aumentar();
				}else{
					Controlador.Disminuir();
				}
				break;
			}
		}
		Controlador.Verficar(Controlador.Correctos,6);
		StartCoroutine(Controlador.FINAL());
	}

	public IEnumerator Cambiar(int escena,int tiempo){
		yield return new WaitForSeconds(tiempo);
		for(int i = 0;i<Scenes.Length;i++){
			Scenes[i].SetActive(false);
		}
		Controlador.Info(retros[escena]);
		Scenes[escena].SetActive(true);
	}

	public void Restore(){
		for(int i = 0;i<Grupo1.Length;i++){
			Grupo1[i].isOn = false;
			retros[i].SetActive(false);
		}
		for(int i = 0;i<Grupo2.Length;i++){
			Grupo2[i].isOn = false;
			retros2[i].SetActive(false);
		}
		for(int i = 0;i<Infos.Length;i++){
			Infos[i].SetActive(false);
		}
		for(int i = 0;i<retros.Length;i++){
			retros[i].SetActive(false);
		}
		for(int i = 0;i<retros2.Length;i++){
			retros2[i].SetActive(false);
		}

	}

}
