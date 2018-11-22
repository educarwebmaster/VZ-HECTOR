using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PRUEBA_NEW_PROGRAMADOR : MonoBehaviour {
	public RETROS Controlador;
	public DPRBASE Drops;
	public DRRBASE[] Drags;


	public void Termine(){
		if(Drops.ID == Drops.gameObject.transform.GetChild(0).gameObject.GetComponent<DRRBASE>().ID){
			Controlador.Aumentar();
		}
		Controlador.Verficar(Controlador.Correctos,1);
		StartCoroutine(Controlador.FINAL());
	}

	public void Restaurar(){
		for(int i = 0;i<Drags.Length;i++){
			Drags[i].Restore();
		}
	}
}
