using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class MATEMATICA_EXPRESATE_10_U2_sistem{
	public Sprite[] img1;
	public Sprite[] img2;
	public Sprite[] img3;
	public Sprite[] img4;
	public Sprite fondo;
	public int correcto;
}

public class MATEMATICA_EXPRESATE_10_U2 : MonoBehaviour {

	public MATEMATICA_EXPRESATE_10_U2_sistem[] imagenes;
	public Image img1,img2,img3,img4,fondo;
	public RETROS Controlador;
	public int slide;
	public GameObject Mascara, boton;
	public Sprite Bueno,Malo;
	// Use this for initialization

	public void Start(){

	}

	public void Update(){
	 	
	}

	public void Verificar(int s){
		if(s == 0){
			img1.sprite=imagenes[slide].img1[1];
			boton=img1.gameObject;
		}
		if(s == 1){img2.sprite=imagenes[slide].img2[1];boton=img2.gameObject;}
		if(s == 2){img3.sprite=imagenes[slide].img3[1];boton=img3.gameObject;}
		if(s == 3){img4.sprite=imagenes[slide].img4[1];boton=img4.gameObject;}
		boton.transform.GetChild(0).gameObject.SetActive(true);
		if(s == imagenes[slide].correcto){
			Controlador.Aumentar();
			boton.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = Bueno;
		}else{
			Controlador.Disminuir();
			boton.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = Malo;
		}
		
		if(slide >= imagenes.Length - 1){
			slide = 0;
			Mascara.SetActive(false);
			Controlador.Verficar(Controlador.Correctos,3);
			boton.transform.GetChild(0).gameObject.SetActive(false);
			StartCoroutine(Controlador.FINAL());
		}else{
			StartCoroutine("Saltar");
		}
	}

	public IEnumerator Saltar(){
		Mascara.SetActive(true);
		yield return new WaitForSeconds(3);	
		boton.transform.GetChild(0).gameObject.SetActive(false);
		Mascara.SetActive(false);
		slide++;
		Cambiar(slide);
	}

	public void Cambiar(int i){
		img1.sprite =  imagenes[i].img1[0];
		img2.sprite =  imagenes[i].img2[0];
		img3.sprite =  imagenes[i].img3[0];
		img4.sprite =  imagenes[i].img4[0];
		img1.transform.SetSiblingIndex(Random.Range(0,3));
		img2.transform.SetSiblingIndex(Random.Range(0,3));
		img3.transform.SetSiblingIndex(Random.Range(0,3));
		img4.transform.SetSiblingIndex(Random.Range(0,3));
		fondo.sprite = imagenes[i].fondo;
	}
}
