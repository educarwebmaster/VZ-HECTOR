using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LENGUAJE2_EXP_U1_b : MonoBehaviour {
	public bool Ocupado,Bien;
	public int correcto;
	public Color Naranga,Blanco;
	public GameObject boton;
	public Sprite Bueno,Malo;
	public GameObject[] Botones;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Restore(){
		Bien = false;
		Ocupado = false;
		for(int i = 0;i<Botones.Length;i++){
			Botones[i].GetComponent<Image>().color = Naranga;
			Botones[i].transform.GetChild(0).transform.gameObject.GetComponent<Text>().color = Blanco;
			Botones[i].transform.GetChild(1).transform.gameObject.SetActive(false);
		}
	}

	public void Imagen(GameObject miboton){
		if(!Ocupado){
			Ocupado = true;
			boton = miboton;
			boton.GetComponent<Image>().color = Blanco;
			boton.transform.GetChild(0).transform.gameObject.GetComponent<Text>().color = Naranga;
			for(int i=0;i<Botones.Length;i++){
				if(boton == Botones[i]){
					if(i==correcto){
						Bien = true;
					}
				}
			}
		}
	}

	public void Validar(){
		if(boton != null && boton.transform.childCount > 0){
			if(Bien){
				boton.transform.GetChild(1).transform.gameObject.SetActive(true);
				boton.transform.GetChild(1).transform.gameObject.GetComponent<Image>().sprite = Bueno;
			}else{
				boton.transform.GetChild(1).transform.gameObject.SetActive(true);
				boton.transform.GetChild(1).transform.gameObject.GetComponent<Image>().sprite = Malo;
			}
		}
		
	}


}
