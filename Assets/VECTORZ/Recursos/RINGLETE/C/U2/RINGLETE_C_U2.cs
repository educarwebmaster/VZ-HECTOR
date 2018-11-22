using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RINGLETE_C_U2 : MonoBehaviour {
	public RETROS Controlador;
	public DPRBASE[] drops;
	public int Slide;
	public AudioSource AudioControler;
	public AudioClip[] Audios;
	public GameObject[] Escenas;
	public bool activado = true;

	// Update is called once per frame
	void Update () {
		if(activado){
			if(drops[Slide].Ocupado == true){
				activado = false;
				Verificar();
			}
		}
	}

	public void Verificar(){
		DRRBASE D = drops[Slide].transform.GetChild(0).gameObject.GetComponent<DRRBASE>();
		if(D.ID == drops[Slide].ID){
			D.transform.GetChild(0).gameObject.SetActive(true);
			Controlador.Aumentar();
		}else{
			D.transform.GetChild(1).gameObject.SetActive(true);
			Controlador.Disminuir();
		}
		Slide++;
		if(Slide<4){
			StartCoroutine(Cambiar(Slide,2));
		}else{
			StartCoroutine(Finalizar());
		}
	}

	public void Audio(){
		AudioControler.PlayOneShot(Audios[Slide]);
	}

	public IEnumerator Finalizar()
	{

		yield return new WaitForSeconds(2);
        AudioControler.Stop();
        Controlador.Verficar2(Controlador.Correctos,3);
	}

	public IEnumerator Cambiar(int escena,int tiempo){
		yield return new WaitForSeconds(tiempo);
		activado = true;
		for(int i = 0;i<Escenas.Length;i++){
			Escenas[i].SetActive(false);
		}
        AudioControler.Stop();
		AudioControler.PlayOneShot(Audios[Slide]);
		Escenas[escena].SetActive(true);
	}

	public void Restore(){
		Slide = 0;
		for(int i = 0;i<Escenas.Length;i++){
			Escenas[i].SetActive(false);
		}
		for(int i = 0;i<drops.Length;i++){
            if (drops[i].transform.childCount>0) {
                drops[i].Ocupado = false;
                DRRBASE D = drops[i].transform.GetChild(0).gameObject.GetComponent<DRRBASE>();
                D.enabled = true;
                D.transform.GetChild(0).gameObject.SetActive(false);
                D.transform.GetChild(1).gameObject.SetActive(false);
                D.Restore();
            }
		}
		activado = true;
	}
}
