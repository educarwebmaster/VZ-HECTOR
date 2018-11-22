using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MATEMATICAS_COM_U3_U1 : MonoBehaviour {

	public RETROS Controlador;
	public GameObject[] Scenes,Infos,Mascaras,Chulos;
	public float[] flotantes;
	public InputField[] Inputs;
	public Image[] Imagenes;
	public Sprite[] ImagenesMas;
	
	public int Slider;

	public void Validar(){
		if(Inputs[Slider].text == flotantes[Slider].ToString()){
			Controlador.Aumentar();
			Chulos[0].SetActive(true);
			Imagenes[0].sprite = ImagenesMas[1];
		}else{
			Controlador.Disminuir();
			Chulos[1].SetActive(true);
		}
		Mascaras[Slider].SetActive(true);
		Slider++;
		StartCoroutine(Cambiar(1,2));
	}

	public void Validar2(){
		if(Inputs[Slider].text == flotantes[Slider].ToString()){
			Controlador.Aumentar();
			Chulos[2].SetActive(true);
			Imagenes[1].sprite = ImagenesMas[3];
		}else{
			Controlador.Disminuir();
			Chulos[3].SetActive(true);
		}
		Mascaras[Slider].SetActive(true);
		StartCoroutine(Final());
	}

	public IEnumerator Final(){
		yield return new WaitForSeconds(2);
		Controlador.Verficar(Controlador.Correctos,2);
		StartCoroutine(Controlador.FINAL());
	}

	public IEnumerator Cambiar(int escena,int tiempo){
		yield return new WaitForSeconds(tiempo);
		for(int i = 0;i<Scenes.Length;i++){
			Scenes[i].SetActive(false);
		}
		Controlador.Info(Infos[escena]);
		Scenes[escena].SetActive(true);
	}

	public void Restore(){
		Slider = 0;
		for(int i = 0;i<Inputs.Length;i++){
			Inputs[i].text = "";
		}
		for(int i = 0;i<Mascaras.Length;i++){
			Mascaras[i].SetActive(false);
		}
		for(int i = 0;i<Chulos.Length;i++){
			Chulos[i].SetActive(false);
		}
		for(int i = 0;i<Scenes.Length;i++){
			Scenes[i].SetActive(false);
		}
		Imagenes[0].sprite = ImagenesMas[0];
		Imagenes[1].sprite = ImagenesMas[2];
	}

}
