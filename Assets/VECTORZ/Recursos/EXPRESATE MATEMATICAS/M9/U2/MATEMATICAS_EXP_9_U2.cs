using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MATEMATICAS_EXP_9_U2 : MonoBehaviour {
	public RETROS Controlador;
	public int Slide,Puntos,Incorrectos;
	public int[] correctos;
	public Vector4[] Textos;
	public Image[] elementos;
	public Image Seleccionado,Fondo,Info;
	public Sprite[] Fondos,Infos;
	public Sprite Bueno,Malo;
	public bool Ocupado;
	public Color Selec,Normal;
	public GameObject[] InfosInicio;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Iniciar(){
		    int slide = Slide;
			StartCoroutine(Controlador.Info_c(InfosInicio[slide]));
			Fondo.sprite = Fondos[slide];
			Info.sprite = Infos[slide];
			for(int i = 0;i < elementos.Length;i++){
				elementos[i].gameObject.transform.SetSiblingIndex(Random.Range(0,elementos.Length));
			}
			elementos[0].gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "" + Textos[slide].x;
			elementos[1].gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "" + Textos[slide].y;
			elementos[2].gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "" + Textos[slide].z;
			elementos[3].gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "" + Textos[slide].w;
	}

	public void Seleccionar(Image select){
		if(!Ocupado){
			select.color = Selec;
			select.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().color = Normal;
			Ocupado = true;
			Seleccionado = select;
		}
	}

	public IEnumerator Saltar(){
		yield return new WaitForSeconds(3);
		for(int i = 0; i < elementos.Length;i++){
			elementos[i].color = Normal;
			elementos[i].gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().color = Selec;
			elementos[i].gameObject.transform.GetChild(1).gameObject.SetActive(false);
		}
		Slide++;
		Iniciar();
		Ocupado = false;
	}

	public void Mostrar(){
		for(int i = 0;i<elementos.Length;i++){
			if(Seleccionado == elementos[i]){
				Image ima = Seleccionado.gameObject.transform.GetChild(1).gameObject.GetComponent<Image>();
				Seleccionado.gameObject.transform.GetChild(1).gameObject.SetActive(true);
				if(i == correctos[Slide]){
					ima.sprite = Bueno;
					Puntos++; 
					Controlador.Aumentar();
				}else{
					ima.sprite = Malo;
					Controlador.Disminuir();
				}
			}
		}
		if(Slide == 1){
			Controlador.Verficar(Puntos,correctos.Length);
			StartCoroutine(Controlador.FINAL());
		}else{
			StartCoroutine("Saltar");
		}
	}

	public void Restore(){
		Slide = 0;
		Puntos = 0;
		Ocupado = false;
		for(int i = 0; i < elementos.Length;i++){
			elementos[i].color = Normal;
			elementos[i].gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().color = Selec;
			elementos[i].gameObject.transform.GetChild(1).gameObject.SetActive(false);
		}
		Controlador.Restore();
	}
}
