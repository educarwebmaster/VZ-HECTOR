using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class EXPRESATE_LENGUAJE_0_ANIMALES_Preguntas {
	public AudioClip[] audio;
	public int correcto;
	public string[] textos;
	public string abrir;
}

public class EXPRESATE_LENGUAJE_0_ANIMALES : MonoBehaviour {

	public EXPRESATE_LENGUAJE_0_ANIMALES_Preguntas[] Preguntas;
	public Animator anim;
	public int Scene;
	public GameObject Interfas,Interfas2,RB,RM;
	public Image[] btn;
	public Sprite normal, bueno, malo;
	public Text[] textos;
	public AudioSource audio;

	public void AnimacionIniciar (int s) {
		anim.SetBool("Terminado",false); 
		Scene = s;
		anim.Play (Preguntas[s].abrir);
		btn[0].sprite = normal;
		btn[1].sprite = normal;
		btn[2].sprite = normal;
		textos[0].text = Preguntas[s].textos[0];
		textos[1].text = Preguntas[s].textos[1];
		textos[2].text = Preguntas[s].textos[2];
		Interfas2.SetActive (false);
		Interfas.SetActive (true);
	}

	public void HoverSeleccion (int m) {
		if(m == Preguntas[Scene].correcto){
			btn[m].sprite = bueno;
			RB.SetActive(true);
			RB.GetComponent<Animator>().Play("RetroBuena");
		}else{
			btn[m].sprite = malo;
			RM.SetActive(true);
			RM.GetComponent<Animator>().Play("RetroMala");
		}
		StartCoroutine(this.Desaparecer());
	}

	public void AudioPlay (int m) {
		audio.PlayOneShot (Preguntas[Scene].audio[m]);
	}

	public IEnumerator Desaparecer(){
		yield return new WaitForSeconds(3);
		anim.SetBool("Terminado",true); 
		RB.SetActive(false);
		RM.SetActive(false);
		Interfas.SetActive (false);
		Interfas2.SetActive (false);
	}
}