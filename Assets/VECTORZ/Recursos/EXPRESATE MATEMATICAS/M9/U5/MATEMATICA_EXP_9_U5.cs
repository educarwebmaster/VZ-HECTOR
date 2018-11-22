using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MATEMATICA_EXP_9_U5 : MonoBehaviour {
	public RETROS Controlador;
	public int Slide,Puntos,Incorrectos;
	public int[] correctos;
	public Vector3[] Posiciones;
	public Image[] elementos;
	public Image Seleccionado,Fondo;
	public Sprite[] Fondos;
	public Sprite Bueno,Malo;
	public bool Ocupado;
	public Color Selec,Normal;
	public Sprite[] botones;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Iniciar(){
		    int slide = Slide;
			Fondo.sprite = Fondos[slide];
			for(int i = 0;i < elementos.Length;i++){
				elementos[i].gameObject.transform.SetSiblingIndex(Random.Range(0,elementos.Length));
			}
			elementos[0].gameObject.GetComponent<Image>().sprite = botones[(int)Posiciones[slide].x];
			elementos[1].gameObject.GetComponent<Image>().sprite = botones[(int)Posiciones[slide].y];
			elementos[2].gameObject.GetComponent<Image>().sprite = botones[(int)Posiciones[slide].z];
			
	}

	public void Seleccionar(Image select){
		for(int i = 0; i < elementos.Length;i++){
			elementos[i].color = Normal;
		}
			select.color = Selec;
			
			Ocupado = true;
			Seleccionado = select;
		
	}

	public IEnumerator Saltar(){
		yield return new WaitForSeconds(3);
		for(int i = 0; i < elementos.Length;i++){
			elementos[i].color = Normal;
			elementos[i].gameObject.transform.GetChild(0).gameObject.SetActive(false);
		}
		Slide++;
		Iniciar();
		Ocupado = false;
	}

	public void Mostrar(){
		if (Ocupado == true)
		{
			for(int i = 0;i<elementos.Length;i++)
		{
			if(Seleccionado == elementos[i])
			{
			Image ima = Seleccionado.gameObject.transform.GetChild(0).gameObject.GetComponent<Image>();
			Seleccionado.gameObject.transform.GetChild(0).gameObject.SetActive(true);
			if(i == correctos[Slide])
			{
					ima.sprite = Bueno;
					Puntos++; 
					Controlador.Aumentar();
			}else{
					ima.sprite = Malo;
					Controlador.Disminuir();
				}
			}
		}
		if(Slide == 2){
			Controlador.Verficar(Puntos,correctos.Length);
			StartCoroutine(Controlador.FINAL());
		}else{
			StartCoroutine("Saltar");
		}

		}
			}

	public void Restore(){
		Slide = 0;
		Puntos = 0;
		Ocupado = false;
		for(int i = 0; i < elementos.Length;i++){
			elementos[i].color = Normal;
			elementos[i].gameObject.transform.GetChild(0).gameObject.SetActive(false);
		}
		Controlador.Restore();
	}
}
