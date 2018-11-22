using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RINGLETE_B_U3 : MonoBehaviour {
	public RETROS Controlador;
	public Sprite[] ImagenesSelect,ImagenesNormal;
	public Image[] Imagenes;
	public DPRBASE[] Drops;
	public AudioClip RB,RM;
	public AudioSource auc;
	public GameObject Info2,s1,s2;
	public int Slide;

	public void Aumentar(){
		Controlador.Aumentar();
		auc.PlayOneShot(RB);
	}

	public void Disminuir(){
		Controlador.Disminuir();
		auc.PlayOneShot(RM);
	}

	public void Verificar1(int i){
		if(Slide<2){
			Slide++;
		}else{
			s1.SetActive(false);
			s2.SetActive(true);
			Controlador.Info(Info2);
		}
		Imagenes[i].sprite = ImagenesSelect[i];
	}

	public void Verificar2(){
		for(int i = 0;i<Drops.Length;i++){
			if(Drops[i].ID == Drops[i].transform.GetChild(0).gameObject.GetComponent<DRRBASE>().ID){
				Controlador.Aumentar();
			}else{
				Controlador.Disminuir();
			}
		}
		Controlador.Verficar2(Controlador.Correctos,6);
	}

	public void Restore(){
		Slide=0;
		for(int i = 0;i<Drops.Length;i++){
			if(Drops[i].transform.childCount>0){
				Drops[i].Ocupado = false;
				Drops[i].transform.GetChild(0).gameObject.GetComponent<DRRBASE>().enabled = true;
				Drops[i].transform.GetChild(0).gameObject.GetComponent<DRRBASE>().Restore();
			}
		}

		for(int i = 0;i<Imagenes.Length;i++){
			Imagenes[i].sprite = ImagenesNormal[i];
		}
	}

}
