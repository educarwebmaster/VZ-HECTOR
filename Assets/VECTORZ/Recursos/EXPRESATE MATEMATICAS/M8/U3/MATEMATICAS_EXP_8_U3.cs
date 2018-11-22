using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MATEMATICAS_EXP_8_U3 : MonoBehaviour {
public int[] respuestas;
public int slider,puntos,boton;
public Sprite[] fondos,boton1,boton2,boton3,boton4;
public Image fondo,boton_1,boton_2,boton_3,boton_4;
public  RETROS controlador;
public GameObject[] botones;
public GameObject barrera;

	public void saltar(){
	StartCoroutine("inicar_con_tiempo");
	}
	public IEnumerator inicar_con_tiempo()
	{
		yield return new WaitForSeconds(2); 
		for (int i = 0; i< botones.Length;i++){
			botones[i].transform.GetChild(0).gameObject.SetActive(false);
			botones[i].transform.GetChild(1).gameObject.SetActive(false);
		}
		//barrera.SetActive(false);
		if(slider>=respuestas.Length-1){
			controlador.Verficar(puntos,3);
			StartCoroutine(controlador.FINAL());
		}
		slider++;
		fondo.sprite=fondos[slider];
		boton_1.sprite=boton1[slider];
		boton_2.sprite=boton2[slider];
		boton_3.sprite=boton3[slider];
		boton_4.sprite=boton4[slider];
		boton_1.transform.SetSiblingIndex(Random.Range(0,3));
		boton_2.transform.SetSiblingIndex(Random.Range(0,3));
		boton_3.transform.SetSiblingIndex(Random.Range(0,3));
		boton_4.transform.SetSiblingIndex(Random.Range(0,3));
	}

	public void ResultadoFinal (int r)
	{
		boton=r;
		//barrera.SetActive(true);
	}
	void Start () {
		
	}
	
		void Update () {
		
	}
	public void restaurar ()
	{
		slider = 0;
		fondo.sprite = fondos[0];
		boton_1.sprite = boton1[0];
		boton_2.sprite = boton2[0];
		boton_3.sprite = boton3[0];
		boton_4.sprite = boton4[0];
		puntos = 0;
		//barrera.SetActive(false);
		boton_1.transform.SetSiblingIndex(Random.Range(0,3));
		boton_2.transform.SetSiblingIndex(Random.Range(0,3));
		boton_3.transform.SetSiblingIndex(Random.Range(0,3));
		boton_4.transform.SetSiblingIndex(Random.Range(0,3));
	}

	public void termine (){
      	if(boton==respuestas[slider]){	
			controlador.Aumentar();
         puntos++;
		 	botones[boton - 1].transform.GetChild(0).gameObject.SetActive(true);
		}else{ 	
			botones[boton - 1].transform.GetChild(1).gameObject.SetActive(true);
			controlador.Disminuir();

		}
		//barrera.SetActive(true);
		saltar();
	}
}
