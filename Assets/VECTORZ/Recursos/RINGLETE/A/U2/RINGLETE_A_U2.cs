using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RINGLETE_A_U2 : MonoBehaviour {
public int[] respuestas; 
public int slider,puntos;
public Sprite[] boton_1,boton_2;
public Image boton_img1, boton_img2;
public Monedas moneda;
public GameObject barrera, contador, info;
public RETROS controlador;



public void verificar(int i){
	if (i==respuestas[slider]){
		puntos++;
		moneda.ParticulasCrear(slider);
		if(i==0){
			boton_img1.transform.GetChild(0).gameObject.SetActive(true);//mostrar "bien"
		}else{
			boton_img2.transform.GetChild(0).gameObject.SetActive(true);
		}
	}else{
		if(i==0){
			boton_img1.transform.GetChild(1).gameObject.SetActive(true);//mostrar "bien"
		}else{
			boton_img2.transform.GetChild(1).gameObject.SetActive(true);
		}
	}

	barrera.SetActive(true);
	StartCoroutine("saltar");
}

public IEnumerator saltar(){
	yield return new WaitForSeconds(2);
	boton_img1.transform.GetChild(0).gameObject.SetActive(false);
	boton_img1.transform.GetChild(1).gameObject.SetActive(false);
	boton_img2.transform.GetChild(0).gameObject.SetActive(false);
	boton_img2.transform.GetChild(1).gameObject.SetActive(false);
	if(slider==respuestas.Length-1){
	controlador.Verficar2(puntos,2);
	}else{
	slider++;
	boton_img1.sprite=boton_1[slider];
	boton_img2.sprite=boton_2[slider];	
	}
	barrera.SetActive(false);

}

public void iniciar(){
	controlador.Info(info);
	StartCoroutine(Contador());
}

public IEnumerator Contador(){
	yield return new WaitForSeconds(4);
	contador.SetActive(true);
	yield return new WaitForSeconds(5);
	contador.SetActive(false);
}
public void restaurar (){
slider = 0 ;
boton_img1.sprite = boton_1[0];
boton_img2.sprite = boton_2[0];
puntos = 0;
}


}
