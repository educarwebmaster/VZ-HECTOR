using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MATEMATICA_EXP_11_U7 : MonoBehaviour {
	public RETROS Controlador;
	public DPRBASE[] Drops;
	public int[] Correctos;
	public int Seleccionado,slide;
	public GameObject[] S,Retros_,chulos;

	public void Verificar1(int ins){
		Seleccionado = ins;
	}

	public void Cambiar_s1(){
		
		if(Correctos[slide] == Seleccionado){
			Controlador.Aumentar();
		}else{
			Controlador.Disminuir();
		}
		chulos[Seleccionado].SetActive(true);
		slide++;
		StartCoroutine(Cambiar(slide,2));
	}

	public void Verificar2(){
		for(int i = 0;i<Drops.Length;i++){
			if(Drops[i].transform.childCount > 0){
				DRRBASE D = Drops[i].transform.GetChild(0).gameObject.GetComponent<DRRBASE>();
				if(Drops[i].ID == D.ID){
					Controlador.Aumentar();
				}else{
					Controlador.Disminuir();
				}
			}
		}
		StartCoroutine(Final());
	}

	public IEnumerator Final(){
		yield return new WaitForSeconds(0.2f);
		Controlador.Verficar(Controlador.Correctos,4);
		StartCoroutine(Controlador.FINAL());
	}

	public void Restore(){
		for(int i = 0;i<Drops.Length;i++){
			if(Drops[i].transform.childCount > 0){
				DRRBASE D = Drops[i].transform.GetChild(0).gameObject.GetComponent<DRRBASE>();
				D.enabled = true;
				D.Restore();
				Drops[i].Ocupado = false;
			}
		}
		slide=0;
		for(int i = 0;i<chulos.Length;i++){
			chulos[i].SetActive(false);
		}
	}

	public IEnumerator Cambiar(int escena,int tiempo){
		yield return new WaitForSeconds(tiempo);
		for(int i = 0;i<S.Length;i++){
			S[i].SetActive(false);
		}
		Controlador.Info(Retros_[escena]);
		S[escena].SetActive(true);
	}
}
