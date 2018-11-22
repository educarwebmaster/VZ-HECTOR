using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MATEMATICA_9_EXP_U4 : MonoBehaviour {
	public RETROS Controlador;
	public Transform[] botones;
	public DPRBASE[] Drags1;
	public DPRBASE[] Drags2;
	public int Puntos,Select;
	public GameObject ACT1,ACT2,ACT3,Mascara,Info2,Info3;

	public void Desordenar(){
		for(int i = 0;i< botones.Length;i++){
				Transform d = botones[i];
				d.SetSiblingIndex(Random.Range(0,3));
		}
	}

	public void Verificar_(int i){
		Select = i;
		if(i == 0){
			Puntos++;
		}
		Mascara.SetActive(true);
	}

	public void Verificar1(){
		if(Select == 0){
			botones[Select].GetChild(0).gameObject.SetActive(true);
		}else{
			botones[Select].GetChild(1).gameObject.SetActive(true);
		}
		StartCoroutine(Pasar1());
	}

	public IEnumerator Pasar1(){
		yield return new WaitForSeconds(2);
		Restaurar();
		ACT1.SetActive(false);
		ACT2.SetActive(true);
		Controlador.Info(Info2);
	}

	public void Verificar2(){
		for(int i = 0;i<Drags1.Length;i++){
			if(Drags1[i].transform.childCount > 0){
				DRRBASE d = Drags1[i].transform.GetChild(0).gameObject.GetComponent<DRRBASE>();
				if(Drags1[i].ID == d.ID){
					Puntos++;
					Controlador.Aumentar();
					d.transform.GetChild(0).gameObject.SetActive(true);
				}else{
					Controlador.Disminuir();
					d.transform.GetChild(1).gameObject.SetActive(true);
				}
			}
		}
		StartCoroutine(Pasar2());
	}

	public IEnumerator Pasar2(){
		yield return new WaitForSeconds(2);
		Restaurar();
		ACT2.SetActive(false);
		ACT3.SetActive(true);
		Controlador.Info(Info3);
	}

	public void Verificar3(){
		for(int i = 0;i<Drags2.Length;i++){
			if(Drags2[i].transform.childCount > 0){
				DRRBASE d = Drags2[i].transform.GetChild(0).gameObject.GetComponent<DRRBASE>();
				if(Drags2[i].ID == d.ID){
					Puntos++;
					Controlador.Aumentar();
					d.transform.GetChild(0).gameObject.SetActive(true);
				}else{
					Controlador.Disminuir();
					d.transform.GetChild(1).gameObject.SetActive(true);
				}
			}
		}
		StartCoroutine(Pasar3());
	}

	public IEnumerator Pasar3(){
		yield return new WaitForSeconds(2);
		Restaurar();
		Controlador.Verficar(Puntos,5);
		StartCoroutine(Controlador.FINAL());
	}

	public void Restaurar(){
		Mascara.SetActive(false);
		for(int i = 0;i< botones.Length;i++){
				Transform d = botones[i];
				d.GetChild(0).gameObject.SetActive(false);
				d.GetChild(1).gameObject.SetActive(false);
		}
		for(int i = 0;i<Drags1.Length;i++){
			Drags1[i].Ocupado = false;
			if(Drags1[i].transform.childCount > 0){
				DRRBASE d = Drags1[i].transform.GetChild(0).gameObject.GetComponent<DRRBASE>();
				d.transform.GetChild(0).gameObject.SetActive(false);
				d.transform.GetChild(1).gameObject.SetActive(false);
				d.enabled = true;
				d.Restore();
			}
		}
		for(int i = 0;i<Drags2.Length;i++){
			Drags2[i].Ocupado = false;
			if(Drags2[i].transform.childCount > 0){
				DRRBASE d = Drags2[i].transform.GetChild(0).gameObject.GetComponent<DRRBASE>();
				d.transform.GetChild(0).gameObject.SetActive(false);
				d.transform.GetChild(1).gameObject.SetActive(false);
				d.enabled = true;
				d.Restore();
			}
		}
	}

	public void Restore(){
		Select = 0;
		Puntos = 0;
	}
}
