using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXPRESATE_LENGUAJE_0_ANIMAL : MonoBehaviour {
	public EXPRESATE_LENGUAJE_0_ANIMALES controlador;
	public int animal;
	void OnMouseDown () {
		controlador.AnimacionIniciar(animal);
	}
}