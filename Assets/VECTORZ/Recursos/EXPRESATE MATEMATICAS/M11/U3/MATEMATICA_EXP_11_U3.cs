using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class  MATEMATICA_EXP_11_U3_sistem{
	public InputField[] textos;
	public Toggle[] radios;
	public string[] Correctos1;
	public int Correctos2;
	public GameObject Scena;

	public Vector2 Verificar(){
		int buenos = 0;
		int malos = 0;
		for(int i= 0;i<textos.Length;i++){
			if(textos[i].text == Correctos1[i]){
				buenos++;
				textos[i].transform.GetChild(2).gameObject.SetActive(true);
			}else{
				malos++;
				textos[i].transform.GetChild(3).gameObject.SetActive(true);
			}
		}
		for(int i= 0;i<radios.Length;i++){
			if(radios[i].isOn){
				if(i == Correctos2){
					radios[i].transform.GetChild(0).gameObject.SetActive(true);
					buenos++;
				}else{
					radios[i].transform.GetChild(1).gameObject.SetActive(true);
					malos++;
				}
			}
		}
		return new Vector2(buenos,malos);
	} 

	public void Restore(){
		for(int i= 0;i<textos.Length;i++){
				textos[i].text = "";
				textos[i].transform.GetChild(2).gameObject.SetActive(false);
				textos[i].transform.GetChild(3).gameObject.SetActive(false);
		}
		for(int i= 0;i<radios.Length;i++){
				radios[i].isOn = false;
				radios[i].transform.GetChild(0).gameObject.SetActive(false);
				radios[i].transform.GetChild(1).gameObject.SetActive(false);
		}
		Scena.SetActive(false);
	}
}
public class MATEMATICA_EXP_11_U3 : MonoBehaviour {
	public RETROS Controlador;
	public MATEMATICA_EXP_11_U3_sistem[] Scenas;
	public int slider;
	public GameObject[] Retros_;

	public void Validar(){
		Vector2 puntos = Scenas[slider].Verificar();
		for(int i = 0;i<puntos.x;i++){
			Controlador.Aumentar();
		}
		for(int i = 0;i<puntos.y;i++){
			Controlador.Disminuir();
		}
		slider++;
		if(slider == 3){
			StartCoroutine(Final());
		}else{
			StartCoroutine(Cambiar(slider,2));
		}
	}

	public void Restore(){
		slider = 0;
		for(int i = 0;i<Scenas.Length;i++){
			Retros_[i].SetActive(false);
			Scenas[i].Restore();
		}
	}

	public IEnumerator Final(){
		yield return new WaitForSeconds(1);
		Controlador.Verficar(Controlador.Correctos,7);
		StartCoroutine(Controlador.FINAL());
	}

	public IEnumerator Cambiar(int escena,int tiempo){
		yield return new WaitForSeconds(tiempo);
		for(int i = 0;i<Scenas.Length;i++){
			Scenas[i].Scena.SetActive(false);
		}
		Controlador.Info(Retros_[escena]);
		Scenas[escena].Scena.SetActive(true);
	}

}
