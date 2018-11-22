using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NATURALES_EXP_N2_U4 : MonoBehaviour {
	public RETROS Controlador;
	public GameObject[] Sliders;

	public DropMultiple[] drops;

	public void Seleccionar_scena(int s){
		for(int i = 0;i<Sliders.Length;i++){
			Sliders[i].SetActive(false);
		}
		Sliders[s].SetActive(true);
	}

	public void Verificar(){
		for(int i = 0;i<drops.Length;i++){
			for (int e = 0; e < drops[i].transform.childCount; e++)
			{
				if(drops[i].transform.childCount>0){
					DragMultiple d = drops[i].transform.GetChild(e).gameObject.GetComponent<DragMultiple>();
					if(d.ID == drops[i].ID){
						Controlador.Aumentar();
						d.transform.GetChild(0).gameObject.SetActive(true);
					}else{
						Controlador.Disminuir();
						d.transform.GetChild(1).gameObject.SetActive(true);
					}
				}
			}
		}
		StartCoroutine(FINAL());
	}

	public IEnumerator FINAL(){
		yield return new WaitForSeconds(1);
		Controlador.Verficar(Controlador.Correctos,5);
		StartCoroutine(Controlador.FINAL());
	}

	public void Restore(){
		int cont1 = drops[0].transform.childCount;
		DragMultiple[] d1 = new DragMultiple[cont1];
		for(int i = 0;i<cont1;i++){
			d1[i] = drops[0].transform.GetChild(i).gameObject.GetComponent<DragMultiple>();
		}
		for(int i = 0;i<cont1;i++){
			d1[i].enabled = true;
			d1[i].Restore();
			d1[i].transform.GetChild(0).gameObject.SetActive(false);
			d1[i].transform.GetChild(1).gameObject.SetActive(false);
		}
		int cont2 = drops[1].transform.childCount;
		DragMultiple[] d2 = new DragMultiple[cont2];
		for(int i = 0;i<cont2;i++){
			d2[i] = drops[1].transform.GetChild(i).gameObject.GetComponent<DragMultiple>();
		}
		for(int i = 0;i<cont2;i++){
			d2[i].enabled = true;
			d2[i].Restore();
			d2[i].transform.GetChild(0).gameObject.SetActive(false);
			d2[i].transform.GetChild(1).gameObject.SetActive(false);
		}
		for(int i = 0;i<Sliders.Length;i++){
			Sliders[i].SetActive(false);
		}
		Sliders[0].SetActive(true);
	}


}
