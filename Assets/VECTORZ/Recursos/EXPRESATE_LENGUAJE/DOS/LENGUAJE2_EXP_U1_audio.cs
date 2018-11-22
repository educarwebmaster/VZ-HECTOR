using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LENGUAJE2_EXP_U1_audio : MonoBehaviour {
	public AudioSource[] Audios;
	public Image Img;
	public Sprite Reproducir,Detener;
	public bool Estado;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Repro(int i){
		if(Estado){
			Estado = false;
			Img.sprite = Detener;
			DetenerAudios();
		}else{
			Estado = true;
			Img.sprite = Reproducir;
			DetenerAudios();
			Audios[i].Play();
		}
	}

	public void DetenerAudios(){
		for(int i = 0;i<Audios.Length;i++){
			Audios[i].Stop();
		}
	}
}
