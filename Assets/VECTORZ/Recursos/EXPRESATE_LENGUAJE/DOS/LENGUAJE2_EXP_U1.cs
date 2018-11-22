using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LENGUAJE2_EXP_U1 : MonoBehaviour {
	public RETROS Controlador;
	public GameObject[] Drops1;
	public GameObject[] Check1;
	public LENGUAJE2_EXP_U1_b[] Drops2;
	public GameObject Actividad1,Actividad2,Info1,Info2;
	public Sprite Bien,Mal;
	public int puntaje;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Restore(){
		puntaje = 0;
		Controlador.Restore();
		for(int i = 0;i<Drops1.Length;i++){
			if(Drops1[i].transform.childCount > 0){
				Drops1[i].GetComponent<DPRBASE>().Ocupado = false;
				Drops1[i].transform.GetChild(0).GetComponent<DRRBASE>().enabled = true;
				Drops1[i].transform.GetChild(0).GetComponent<DRRBASE>().Restore();
			}
		}
		for(int i = 0;i<Drops1.Length;i++){
			
		}
		for(int i = 0;i<Check1.Length;i++){
			Check1[i].SetActive(false);;
		}
		for(int i = 0;i<Drops2.Length;i++){
			Drops2[i].Restore();
		}
	}

	public void verify1(){
		for(int i = 0;i<Drops1.Length;i++){
			if(Drops1[i].transform.childCount > 0){
					if(Drops1[i].GetComponent<DPRBASE>().ID == Drops1[i].transform.GetChild(0).gameObject.GetComponent<DRRBASE>().ID){
						Check1[i].GetComponent<Image>().sprite = Bien;
						Check1[i].SetActive(true);
						Controlador.Aumentar();
						puntaje++;
					}else{
						Check1[i].GetComponent<Image>().sprite = Mal;
						Check1[i].SetActive(true);
						Controlador.Disminuir();
						puntaje++;
					}
			}
			
		}
		StartCoroutine("Pasar");
	}

	public IEnumerator Pasar(){
		yield return new WaitForSeconds(3);
		for(int i = 0;i<Drops1.Length;i++){
			if(Drops1[i].transform.childCount > 0){
				Drops1[i].GetComponent<DPRBASE>().Ocupado = false;
				Drops1[i].transform.GetChild(0).GetComponent<DRRBASE>().enabled = true;
				Drops1[i].transform.GetChild(0).GetComponent<DRRBASE>().Restore();
			}
		}
		Actividad1.SetActive(false);
		Actividad2.SetActive(true);
		Controlador.Info(Info2);
	}

	public void verify2(){
		for(int i = 0;i<Drops2.Length;i++){
			if(Drops2[i].Bueno){
				puntaje++;
				Controlador.Aumentar();
				Drops2[i].Validar();
			}else{
				puntaje++;
				Controlador.Disminuir();
				Drops2[i].Validar();
			}
		}
		Final();
	}

	public void Final(){
		Controlador.Verficar(Controlador.Correctos,8);
		StartCoroutine(Controlador.FINAL());
	}

	
}
