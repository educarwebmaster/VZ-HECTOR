using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MATEMATICA_EXP_11_U4 : MonoBehaviour {
	public RETROS Controlador;
	public DPRBASE[] Drops;
	public Toggle[] Radios;
	public DPORDER[] Drops2;
	public GameObject[] Retros_,S;

	public void validar1(){
		for(int i = 0;i<Drops.Length;i++){
			if(Drops[i].transform.childCount > 0){
				DRRBASE D = Drops[i].transform.GetChild(0).gameObject.GetComponent<DRRBASE>();
				if(Drops[i].ID == D.ID){
					D.transform.GetChild(0).gameObject.SetActive(true);
					Controlador.Aumentar();
				}else{
					D.transform.GetChild(1).gameObject.SetActive(true);
					Controlador.Disminuir();
				}
			}
		}
		StartCoroutine(Cambiar(1,2));
	}

	public void validar2(){
		for(int i = 0;i<Radios.Length;i++){
			if(Radios[i].isOn == true){
				if(i == 1){
					Controlador.Aumentar();
				}else{
					Controlador.Disminuir();
				}
				Radios[i].transform.GetChild(0).gameObject.SetActive(true);
			}
		}
		StartCoroutine(Cambiar(2,2));
	}

	public void validar3(){
		for(int i = 0;i<Drops2.Length;i++){
			if(Drops2[i].transform.childCount > 0){
				DRORDER D = Drops2[i].transform.GetChild(0).gameObject.GetComponent<DRORDER>();
				if(Drops2[i].ID == D.ID){
					D.transform.GetChild(1).gameObject.SetActive(true);
					Controlador.Aumentar();
				}else{
					D.transform.GetChild(2).gameObject.SetActive(true);
					Controlador.Disminuir();
				}
				D.transform.GetChild(0).gameObject.SetActive(true);
			}
		}
		Controlador.Verficar(Controlador.Correctos,6);
		StartCoroutine(Controlador.FINAL());
	}

	public IEnumerator Cambiar(int escena,int tiempo){
		yield return new WaitForSeconds(tiempo);
		for(int i = 0;i<S.Length;i++){
			S[i].SetActive(false);
		}
		Controlador.Info(Retros_[escena]);
		S[escena].SetActive(true);
	}

	public void Restore(){
		for(int i = 0;i<S.Length;i++){
			S[i].SetActive(false);
			Retros_[i].SetActive(false);
		}
		for(int i = 0;i<Drops.Length;i++){
			if(Drops[i].transform.childCount > 0){
				DRRBASE D = Drops[i].transform.GetChild(0).gameObject.GetComponent<DRRBASE>();
				D.transform.GetChild(0).gameObject.SetActive(false);
				D.transform.GetChild(1).gameObject.SetActive(false);
				D.enabled = true;
				D.Restore();
				Drops[i].Ocupado = false;
			}
		}
		for(int i = 0;i<Drops2.Length;i++){
			if(Drops2[i].transform.childCount > 0){
				DRORDER D = Drops2[i].transform.GetChild(0).gameObject.GetComponent<DRORDER>();
				D.transform.GetChild(0).gameObject.SetActive(false);
				D.transform.GetChild(1).gameObject.SetActive(false);
				D.transform.GetChild(2).gameObject.SetActive(false);
				D.enabled = true;
				D.Restore();
			}
		}
		for(int i = 0;i<Radios.Length;i++){
			Radios[i].isOn = false;
			Radios[i].transform.GetChild(0).gameObject.SetActive(false);
		}
	}


}
