using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MATEMATICAS_EXP_5_U1 : MonoBehaviour {
	public RETROS Controlador;
	public GameObject ACT1,ACT2,ACT3;
	public int puntos;
	public int[] ACT1_correctos;
	public bool[] ACT1_bol;
	public GameObject[] BOTONES;
	public DPRBASE[] ACT2_correctos;
	public InputField[] BOTONES_ACT3;
	public string[] ACT3_correctos;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

	public void Verificar(int i){
		ACT1_bol[i] = true;
	}

	public void Termine1(){
		StartCoroutine("Saltar",1);
		for(int i = 0;i < ACT1_bol.Length;i++){
			if(ACT1_bol[i]){
				if(ACT1_correctos[i] == i){
					puntos++;
					BOTONES[i].transform.GetChild(0).gameObject.SetActive(true);
					Controlador.Aumentar();
				}else{
					BOTONES[i].transform.GetChild(1).gameObject.SetActive(true);
					Controlador.Disminuir();
				}
			}
		}
	}

	public void Termine2(){
		StartCoroutine("Saltar",2);
		for(int i = 0;i < ACT2_correctos.Length;i++){
			if(ACT2_correctos[i].ID == ACT2_correctos[i].transform.GetChild(0).gameObject.GetComponent<DRRBASE>().ID){
				puntos++;
				Controlador.Aumentar();
			}else{
				Controlador.Disminuir();
			}
		}
	}

	public void Termine3(){
		StartCoroutine("Saltar",3);
		for(int i = 0;i < BOTONES_ACT3.Length;i++){
			if(BOTONES_ACT3[i].text == ACT3_correctos[i]){
				puntos++;
				Controlador.Aumentar();
			}else{
				Controlador.Disminuir();
			}
		}
	}

	public IEnumerator Saltar(int s){

		yield return new WaitForSeconds(1);
		for(int i = 0;i < BOTONES.Length;i++){
				BOTONES[i].transform.GetChild(0).gameObject.SetActive(false);
				BOTONES[i].transform.GetChild(1).gameObject.SetActive(false);
		}
		for(int i = 0;i < ACT2_correctos.Length;i++){
			ACT2_correctos[i].Ocupado = false; 
			if(ACT2_correctos[i].transform.childCount > 0){
				ACT2_correctos[i].transform.GetChild(0).gameObject.GetComponent<DRRBASE>().enabled = true;
				ACT2_correctos[i].transform.GetChild(0).gameObject.GetComponent<DRRBASE>().Restore();
			}
		}
		for(int i = 0;i < BOTONES_ACT3.Length;i++){
			BOTONES_ACT3[i].text = "";
		}
		if(s == 1){
			ACT1.SetActive(false);
			ACT2.SetActive(true);
		}
		if(s == 2){
			ACT2.SetActive(false);
			ACT3.SetActive(true);
		}
		if(s == 3){
			Controlador.Verficar(puntos,10);
			StartCoroutine(Controlador.FINAL());
		}
	}

	public void Restore(){
		puntos=0;
		for(int i = 0;i < BOTONES_ACT3.Length;i++){
			BOTONES_ACT3[i].text = "";
		}
		for(int i = 0;i < ACT1_bol.Length;i++){
			ACT1_bol[i] = false;
		}
		ACT1.SetActive(false);
		ACT2.SetActive(false);
		ACT3.SetActive(false);
	}
}
