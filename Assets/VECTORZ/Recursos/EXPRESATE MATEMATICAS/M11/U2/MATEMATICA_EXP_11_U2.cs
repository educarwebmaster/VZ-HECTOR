using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MATEMATICA_EXP_11_U2 : MonoBehaviour {
	public RETROS Controlador;
	public GameObject Seleccionador;
	public Vector2[] Correctos,Actividad;
	public Image[] botones;
	public Sprite[] imagenes;
	public Sprite defecto;
	public int temporal;


	public void Seleccion(int posicion){
		Seleccionador.SetActive(true);
		temporal = posicion;
		
	}
	public void Asignar(int posicion){
		Actividad[posicion] = new Vector2(temporal,posicion);
		botones[temporal].sprite = imagenes[posicion];
		Seleccionador.SetActive(false);
	}

	public void Verificar(){
		for(int i =0;i<Actividad.Length;i++){
			if(Actividad[i] == Correctos[i]){
				Controlador.Aumentar();
				botones[i].gameObject.transform.GetChild(0).gameObject.SetActive(true);
			}else{
				Controlador.Disminuir();
				botones[i].gameObject.transform.GetChild(1).gameObject.SetActive(true);
			}
		}
		StartCoroutine("Finalizar");
	}

	public IEnumerator Finalizar(){
		yield return new WaitForSeconds(3);
		Controlador.Verficar(Controlador.Correctos,Actividad.Length);
		StartCoroutine(Controlador.FINAL());
	}

    public void Restore(){
		for(int i =0;i<botones.Length;i++){
			botones[i].sprite = defecto;
			Actividad[i] = new Vector2(0,0);
			botones[i].gameObject.transform.GetChild(0).gameObject.SetActive(false);
			botones[i].gameObject.transform.GetChild(1).gameObject.SetActive(false);
		}
		temporal = 0;
	} 



}
