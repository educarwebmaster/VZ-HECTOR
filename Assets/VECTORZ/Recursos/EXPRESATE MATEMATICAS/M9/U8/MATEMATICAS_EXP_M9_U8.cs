using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MATEMATICAS_EXP_M9_U8 : MonoBehaviour {
	public RETROS Controlador;
	public GameObject[] Mascara,Scenes,retros;
	public Image[] Imagenes;
	public Sprite[] Normal,Anormal;
	public int Slide;
	public int[] Correctos;

	public void Randomize(){
		for(int i = 0;i<Imagenes.Length;i++){
		  Imagenes[i].transform.SetSiblingIndex(Random.Range(0,3));
		}
	}

	public void Validar(int i){
		Mascara[Slide].SetActive(true);
		Imagenes[i].sprite = Anormal[i];
		Imagenes[i].transform.GetChild(0).gameObject.SetActive(true);
		if(i == Correctos[Slide]){
			Controlador.Aumentar();
		}else{
			Controlador.Disminuir();
		}
		if(Slide<2){
			Slide++;
			StartCoroutine(Cambiar(Slide,2));
		}else{
			StartCoroutine(Finalizar());
		}
	}

	public IEnumerator Finalizar()
	{
		yield return new WaitForSeconds(2);
		Controlador.Verficar(Controlador.Correctos,3);
		StartCoroutine(Controlador.FINAL());
	}

	public void Restore(){
		for(int i = 0;i<Scenes.Length;i++){
			Scenes[i].SetActive(false);
		}
		for(int i = 0;i<Mascara.Length;i++){
			Mascara[i].SetActive(false);
		}
		Slide=0;
		for(int i = 0;i<Imagenes.Length;i++){
			Imagenes[i].sprite = Normal[i];
			Imagenes[i].transform.GetChild(0).gameObject.SetActive(false);
		}
	}

	public IEnumerator Cambiar(int escena,int tiempo){
		yield return new WaitForSeconds(tiempo);
		for(int i = 0;i<Scenes.Length;i++){
			Scenes[i].SetActive(false);
		}
		//Controlador.Info(retros[escena]);
		Scenes[escena].SetActive(true);
	}

}
