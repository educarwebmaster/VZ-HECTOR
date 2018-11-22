using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MATEMATICA_EXPRESATE_8_U8 : MonoBehaviour {
	public RETROS retros;
	public int Slider, comodin;
	public Vector4[] posiciones;
	public int[] Correctos;
	public Image[] imagenes;
	public Sprite[] sprites,fondo, fondo2;
	public Image Fondos, Fondos2;
	public GameObject retrobuena, retromala;

	public void Start(){

	}

	public void Update(){
		
	}

	public void aumentar(int r){
		comodin = r;
	}

	public IEnumerator Cambiar(int s){
		yield return new WaitForSeconds (2);
		Fondos.sprite = fondo[s];
		Fondos2.sprite = fondo2[s];
		imagenes[0].sprite = sprites[int.Parse("" + posiciones[s].x)];
		imagenes[1].sprite = sprites[int.Parse("" + posiciones[s].y)];
		imagenes[2].sprite = sprites[int.Parse("" + posiciones[s].z)];
		imagenes[3].sprite = sprites[int.Parse("" + posiciones[s].w)];
		retrobuena.SetActive(false);
		retromala.SetActive(false);
		randomico();
	}

	public void Cambiar2(int s){
		Fondos.sprite = fondo[s];
		Fondos2.sprite = fondo2[s];
		imagenes[0].sprite = sprites[int.Parse("" + posiciones[s].x)];
		imagenes[1].sprite = sprites[int.Parse("" + posiciones[s].y)];
		imagenes[2].sprite = sprites[int.Parse("" + posiciones[s].z)];
		imagenes[3].sprite = sprites[int.Parse("" + posiciones[s].w)];
		retrobuena.SetActive(false);
		retromala.SetActive(false);
		randomico();
	}

	public void validar ()
	{
			if(Slider == posiciones.Length-1){
			if(comodin == Correctos[Slider]){
				retros.Aumentar();
				retrobuena.SetActive(true);
			}else{
				retros.Disminuir();
				retromala.SetActive(true);
			}
			retros.Verficar(retros.Correctos,2);
			StartCoroutine(retros.FINAL());
		}else{
			if(comodin == Correctos[Slider]){
				retros.Aumentar();
				retrobuena.SetActive(true);
			}else{
				retros.Disminuir();
				retromala.SetActive(true);
			}
			Slider++;
			StartCoroutine (Cambiar(Slider));
		}
	}

	public void randomico()
	{
		for (int i=0;i<imagenes.Length;i++)
		{
			imagenes[i].transform.SetSiblingIndex(Random.Range(0,3));
		}
	}

	public void Restore(){
		Cambiar2(0);
		Slider = 0;
		comodin=0;
		retros.Restore();
	}

}
