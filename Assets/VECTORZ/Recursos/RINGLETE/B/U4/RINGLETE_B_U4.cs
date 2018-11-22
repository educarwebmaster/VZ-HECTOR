 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class RINGLETE_B_U4_sistem{
	public RETROS Controlador;
	public DPRBASE[] Drops;
	public GameObject Botones,Mascara,Escena,bueno,malo;
	public Image fondo;
	public Sprite Im1,Im2;
	public int correcto;
	public bool ocupado;
	public AudioClip audio1,audio2;

	public void Verificar(){
		int con = 0;
		for(int i = 0;i<Drops.Length;i++){
			if(Drops[i].Ocupado == true){
				con++;
			}
		}

		if(con == 4){
			ocupado = true;
			for(int i = 0;i<Drops.Length;i++){
				if(Drops[i].ID == Drops[i].transform.GetChild(0).gameObject.GetComponent<DRRBASE>().ID){
					Controlador.Aumentar();
				}else{
					Controlador.Disminuir();
				}
		    }
		}
	}

	public void Aparecer(){
		Botones.SetActive(true);
		fondo.sprite = Im2;
	}

	public void Ver(int verificar){
		Mascara.SetActive(true);
		if(verificar == correcto){
			Controlador.Aumentar();
			bueno.SetActive(true);
		}else{
			Controlador.Disminuir();
			malo.SetActive(true);
		}
	}

	public void Restore(){
		for(int i = 0;i<Drops.Length;i++){
			if(Drops[i].transform.childCount>0){
				Drops[i].Ocupado = false;
				Drops[i].transform.GetChild(0).gameObject.GetComponent<DRRBASE>().enabled = true;
				Drops[i].transform.GetChild(0).gameObject.GetComponent<DRRBASE>().Restore();
			}
		}
		fondo.sprite = Im1;
		ocupado = false;
		Botones.SetActive(false);
		Mascara.SetActive(false);
		Escena.SetActive(false);
		bueno.SetActive(false);
		malo.SetActive(false);
	}
}

public class RINGLETE_B_U4 : MonoBehaviour {
	public RETROS Controlador;
	public RINGLETE_B_U4_sistem[] Objetos;
	public int Slider;
	public bool activado;

	void Update()
	{
		if(activado){
			Objetos[Slider].Verificar();
			if(Objetos[Slider].ocupado){
				activado = false;
				Objetos[Slider].Aparecer();
			}
		}
	}

	public void Audio(AudioSource audio){
		if(Objetos[Slider].ocupado){
			audio.PlayOneShot(Objetos[Slider].audio2);
		}else{
			audio.PlayOneShot(Objetos[Slider].audio1);
		}
		
	}

	public void Ingresar(int elemento){
		Objetos[Slider].Ver(elemento);
		if (Slider == 2)
		{
			StartCoroutine(Final());
		}else{
			Slider++;
			StartCoroutine(Cambiar());
		}
	}

	public IEnumerator Final(){
		yield return new WaitForSeconds(1);
		Controlador.Verficar2(Controlador.Correctos,10);
	}

	public IEnumerator Cambiar(){
		yield return new WaitForSeconds(2);
		activado = true;
		for(int i = 0;i<Objetos.Length;i++){
			Objetos[i].Escena.SetActive(false);
		}
		Objetos[Slider].Escena.SetActive(true);
	}

	public void Restore(){
		Slider = 0;
		activado = true;
		for(int i = 0;i<Objetos.Length;i++){
			Objetos[i].Restore();
		}
	}

}
