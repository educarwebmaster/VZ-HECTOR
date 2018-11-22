using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RINGLETE_A_U3 : MonoBehaviour {
	public RETROS Controlador;
	public Sprite[] Au1,Au2,Fondos,Infos;
	public Image[] Au;
	public Image Fondo,Info;
	public AudioSource AudioControlador;
	public AudioClip[] AudiosAnimales1,AudiosAnimales2,Tuto,Infos_;
	public GameObject Slide1,AudiosSlide,Conteo,Actividad,Drops,Mascara,Retro;
	public GameObject[] Cache;
	public int SlideAu,Slide2,Puntos;

	public void NextAudio(){
		for(int e = 0; e<Au.Length;e++){
			Au[e].transform.GetChild(0).gameObject.SetActive(false);
		}
		AudioControlador.Stop();
		if(SlideAu<1){
			SlideAu++;
			AudioControlador.PlayOneShot(Tuto[SlideAu]);
		}else{
			SaltarSlide2();
		}
		for(int i = 0; i<Au.Length;i++){
			Au[i].sprite = Au2[i];
		}
	}

	public void AfterAudio(){
		for(int e = 0; e<Au.Length;e++){
			Au[e].transform.GetChild(0).gameObject.SetActive(false);
		}
		AudioControlador.Stop();
		SlideAu=0;
		for(int i = 0; i<Au.Length;i++){
			Au[i].sprite = Au1[i];
		}
		AudioControlador.PlayOneShot(Tuto[SlideAu]);
	}

	public void ReproducirAudio(int i){
		AudioControlador.Stop();
		for(int e = 0; e<Au.Length;e++){
			Au[e].transform.GetChild(0).gameObject.SetActive(false);
		}
		Au[i].transform.GetChild(0).gameObject.SetActive(true);
		if(SlideAu == 0){
			AudioControlador.PlayOneShot(AudiosAnimales1[i]);
		}else{
			AudioControlador.PlayOneShot(AudiosAnimales2[i]);
		}
	}

	public void SaltarSlide1(){
		Slide1.SetActive(true);
		StartCoroutine("Saltar_Slide1");
	}

	public IEnumerator Saltar_Slide1(){
		yield return new WaitForSeconds(5);
		AudiosSlide.SetActive(true);
		AfterAudio();
		Slide1.SetActive(false);
	}

	public void SaltarSlide2(){
		Conteo.SetActive(true);
		StartCoroutine("Saltar_Slide2");
	}

	public IEnumerator Saltar_Slide2(){
		yield return new WaitForSeconds(4);
		Actividad.SetActive(true);
		Controlador.Info(Retro);
		Audioi();
		Conteo.SetActive(false);
	}

	public void Audioi(){
		AudioControlador.Stop();
		AudioControlador.PlayOneShot(Infos_[Slide2]);
		Info.sprite = Infos[Slide2];
	}

	public void Validar(){
		Mascara.SetActive(true);
		if(Slide2==1)
		{
			for(int i = 0;i<Drops.transform.childCount;i++){
				if(Drops.transform.GetChild(i).gameObject.GetComponent<DragMultiple>().ID == 1){
					Puntos++;
					Drops.transform.GetChild(i).gameObject.transform.GetChild(0).gameObject.SetActive(true);
				}else{
					Drops.transform.GetChild(i).gameObject.transform.GetChild(1).gameObject.SetActive(true);
				}
			}
			Mascara.SetActive(true);
			Slide2 = 0;
			Controlador.Verficar2(Puntos,6);
		}else{
			for(int i = 0;i<Drops.transform.childCount;i++){
				if(Drops.transform.GetChild(i).gameObject.GetComponent<DragMultiple>().ID == 0){
					Puntos++;
					Drops.transform.GetChild(i).gameObject.transform.GetChild(0).gameObject.SetActive(true);
				}else{
					Drops.transform.GetChild(i).gameObject.transform.GetChild(1).gameObject.SetActive(true);
				}
			}
			
			StartCoroutine("Saltar_Slide3");
		}
		
	}

	public IEnumerator Saltar_Slide3(){
		yield return new WaitForSeconds(2);
 		restored();
		Slide2++;
		Fondo.sprite = Fondos[Slide2];
		Info.sprite = Infos[Slide2];
		Mascara.SetActive(false);
	}

	public void restored(){
		Mascara.SetActive(false);
		Cache = new GameObject[Drops.transform.childCount];
		Fondo.sprite = Fondos[0];
		Info.sprite = Infos[0];
		for(int i = 0;i<Cache.Length;i++){
			GameObject d = Drops.transform.GetChild(i).gameObject;
			Cache[i] = d;
			Debug.Log(Cache[i].name);
		}
		for(int i = 0;i<Cache.Length;i++){
				Cache[i].transform.GetChild(0).gameObject.SetActive(false);
				Cache[i].transform.GetChild(1).gameObject.SetActive(false);
				Cache[i].GetComponent<DragMultiple>().enabled = true;
				Cache[i].GetComponent<DragMultiple>().Restore();
		}
	}

	public void Restore(){
		Mascara.SetActive(false);
		Puntos = 0;
		Slide2 = 0;
		SlideAu = 0;
		Fondo.sprite = Fondos[0];
		Info.sprite = Infos[0];
		Cache = new GameObject[Drops.transform.childCount];
		for(int i = 0;i<Cache.Length;i++){
			GameObject d = Drops.transform.GetChild(i).gameObject;
			Cache[i] = d;
			Debug.Log(Cache[i].name);
		}
		for(int i = 0;i<Cache.Length;i++){
				Cache[i].transform.GetChild(0).gameObject.SetActive(false);
				Cache[i].transform.GetChild(1).gameObject.SetActive(false);
				Cache[i].GetComponent<DragMultiple>().enabled = true;
				Cache[i].GetComponent<DragMultiple>().Restore();
		}

	}


}
