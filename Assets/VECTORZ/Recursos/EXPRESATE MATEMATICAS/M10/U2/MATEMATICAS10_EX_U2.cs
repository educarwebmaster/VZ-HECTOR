using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class MATEMATICAS10_EX_U2_sistem{
	public Sprite[] img;
	public Sprite fondo,retro;
}

public class MATEMATICAS10_EX_U2 : MonoBehaviour {
	public RETROS Controlador;
	public MATEMATICAS10_EX_U2_sistem[] Info;
	public GameObject[] drops,contents;
	public GameObject infos;
	public Image fondo,retro;
	public Image[] img;
	public int slide,puntos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Estasblecer(int i){
		for(int e = 0;e < drops.Length;e++){
			int o = Random.Range(0,2);
			contents[e].transform.SetSiblingIndex(o);
		}
		fondo.sprite = Info[i].fondo;
		retro.sprite = Info[i].retro;
		for(int e = 0;e < Info[i].img.Length;e++){
			img[e].sprite = Info[i].img[e];
		}
	}

	public void Avanzar(){
		
		for(int i = 0;i < drops.Length;i++){
			if(drops[i].transform.childCount > 0){
				if(drops[i].transform.GetChild(0).gameObject.GetComponent<DRRBASE>().ID == drops[i].GetComponent<DPRBASE>().ID){
					puntos++;
					Controlador.Aumentar();
				}else{
					Controlador.Disminuir();
				}
				drops[i].transform.GetChild(0).gameObject.GetComponent<DRRBASE>().enabled = true;
				drops[i].transform.GetChild(0).gameObject.GetComponent<DRRBASE>().Restore();
				drops[i].GetComponent<DPRBASE>().Ocupado = false;
			}else{
				puntos++;
				Controlador.Disminuir();
			}
			
		}
		slide++;
		if(slide == 3){
			Controlador.Verficar(Controlador.Correctos,7);
			StartCoroutine(Controlador.FINAL());
		}else{
			Estasblecer(slide);
			Controlador.Info(infos);
		}

		
	}

	public void Restore(){
		slide = 0;
		puntos = 0;
	}
}
