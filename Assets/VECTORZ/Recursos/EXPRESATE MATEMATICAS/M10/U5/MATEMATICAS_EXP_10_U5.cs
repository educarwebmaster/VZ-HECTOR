using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class MATEMATICAS_EXP_10_U5_sistem {
	public Sprite Fondo,Info;
	public Sprite[] ImagenesNormal,ImagenesHover;
}
public class MATEMATICAS_EXP_10_U5 : MonoBehaviour {
	public RETROS Controlador;
	public MATEMATICAS_EXP_10_U5_sistem[] Sistem;
	public int[] Correctos,Seleccionado;
	public GameObject Bueno,Malo;
	public int Slider;
	public Image Fondo,Info;
	public Image[] Imagenes;

	public void Mostrar(int b){
		Imagenes[0].sprite = Sistem[Slider].ImagenesNormal[0];
		Imagenes[1].sprite = Sistem[Slider].ImagenesNormal[1];
		Imagenes[2].sprite = Sistem[Slider].ImagenesNormal[2];
		Imagenes[3].sprite = Sistem[Slider].ImagenesNormal[3];
		Imagenes[b].sprite = Sistem[Slider].ImagenesHover[b];
		Seleccionado[Slider] = b;
	}

	public void Verificar(){
		if(Seleccionado[Slider] == Correctos[Slider]){
			Controlador.Aumentar();
			Bueno.SetActive(true);
		}else{
			Controlador.Disminuir();
			Malo.SetActive(true);
		}
		StartCoroutine(Cambiar());
	}

	public IEnumerator Cambiar(){
		yield return new WaitForSeconds(2);
		Slider++;
		if(Slider == 3){
			Controlador.Verficar(Controlador.Correctos,3);
			StartCoroutine(Controlador.FINAL());
		}else{
			Saltar(Slider);
		}
		Controlador.Info(Info.transform.parent.gameObject);
		Bueno.SetActive(false);
		Malo.SetActive(false);
	}

	public void Saltar(int s){
		Fondo.sprite = Sistem[s].Fondo;
		Info.sprite = Sistem[s].Info;
		Imagenes[0].sprite = Sistem[s].ImagenesNormal[0];
		Imagenes[1].sprite = Sistem[s].ImagenesNormal[1];
		Imagenes[2].sprite = Sistem[s].ImagenesNormal[2];
		Imagenes[3].sprite = Sistem[s].ImagenesNormal[3];
		Seleccionado[Slider] = 100;
		for(int i = 0;i < Imagenes.Length;i++){
			Imagenes[i].transform.SetSiblingIndex(Random.Range(0,2));
		}
	}

	public void Restore(){
		Slider = 0;
		Saltar(0);
	}

}
