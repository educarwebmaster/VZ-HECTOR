using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MATEMATICA_EXP_10_U4 : MonoBehaviour {
	public RETROS Controlador;
	public GameObject[] Actividades,infos;
	public InputField[] inputs1,inputs2;
	public Vector4[] Respuestas;
	public int Slider;
	public void Verificar(){
		StartCoroutine("Saltar");
	}

	public IEnumerator Saltar(){
		yield return new WaitForSeconds(1f);
			if(Slider == 0){
				if(Respuestas[Slider].x == float.Parse(inputs1[0].text)){Controlador.Aumentar();}else{Controlador.Disminuir();}
				if(Respuestas[Slider].y == float.Parse(inputs1[1].text)){Controlador.Aumentar();}else{Controlador.Disminuir();} 
				if(Respuestas[Slider].z == float.Parse(inputs1[2].text)){Controlador.Aumentar();}else{Controlador.Disminuir();} 
				if(Respuestas[Slider].w == float.Parse(inputs1[3].text)){Controlador.Aumentar();}else{Controlador.Disminuir();} 
				Actividades[1].SetActive(true);
				Controlador.Info(infos[1]);
			}else if(Slider == 1){
				if(Respuestas[Slider].x == float.Parse(inputs2[0].text)){Controlador.Aumentar();}else{Controlador.Disminuir();}
				if(Respuestas[Slider].y == float.Parse(inputs2[1].text)){Controlador.Aumentar();}else{Controlador.Disminuir();} 
				if(Respuestas[Slider].z == float.Parse(inputs2[2].text)){Controlador.Aumentar();}else{Controlador.Disminuir();} 
				if(Respuestas[Slider].w == float.Parse(inputs2[3].text)){Controlador.Aumentar();}else{Controlador.Disminuir();} 
				Controlador.Verficar(Controlador.Correctos,8);
				StartCoroutine(Controlador.FINAL());
			}
		Slider++;
	}

	public void Restore(){
		Slider=0;
		for(int i = 0;i < Actividades.Length;i++){
				Actividades[i].SetActive(false);
		}
		for(int i = 0;i < inputs1.Length;i++){
				inputs1[i].text = "";
		}
		for(int i = 0;i < inputs2.Length;i++){
				inputs2[i].text = "";
		}
		Controlador.Restore();
	}
}
