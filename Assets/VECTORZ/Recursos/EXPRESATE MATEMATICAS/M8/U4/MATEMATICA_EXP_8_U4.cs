using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MATEMATICA_EXP_8_U4 : MonoBehaviour {

	public int[] respuestas;
	public GameObject[] botonesbuenos,botonesmalos;
	public GameObject[] barrera;
	public  RETROS controlador;
	public int slider,puntos,boton;	
	public Image[] blanco;
	public Sprite botonblanco;

	public bool[] seleccionados;

	    void Start()
    {
        
    }

    void Update()
    {
        
    }

	public void saltar(){
	for (int i = 0; i< seleccionados.Length;i++){
		if(seleccionados[i]){
			puntos++;
			controlador.Aumentar();
			botonesbuenos[i].SetActive(true);
		}else {
			botonesmalos[i].SetActive(true);
			controlador.Disminuir();
		}
	}
	StartCoroutine(iniciar());
	}

		public IEnumerator iniciar()
	{
		yield return new WaitForSeconds(2); 
			controlador.Verficar(puntos,3);
	StartCoroutine(controlador.FINAL());
	}


	public void posicion(int res){
		slider=res;
		//barrera[res].SetActive(true);
	}

	public void enviar(int res)
	{
		if(res==respuestas[slider]){
		seleccionados[slider]=true;
		}else{
		seleccionados[slider]=false;
		}
	}


public void restaurar(){
	for (int i = 0; i< respuestas.Length;i++){
	seleccionados[i]=false;
	//barrera[i].SetActive(false);
	botonesmalos[i].SetActive(false);
	botonesbuenos[i].SetActive(false);
	}
	puntos=0;
	for (int i = 0; i< blanco.Length;i++){
		blanco[i].sprite=botonblanco;
	}
}


	

}
