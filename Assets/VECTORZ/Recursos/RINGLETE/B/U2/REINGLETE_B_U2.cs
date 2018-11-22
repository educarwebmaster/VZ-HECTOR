using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class REINGLETE_B_U2 : MonoBehaviour {
	public RETROS retros;
	public int Slider,acertado;
	public Vector3[] posiciones;
	public int[] Correctos;
	public Image[] imagenes;
	public Sprite[] sprites,fondo;
	public Image Fondos;
    public GameObject mascara;

	public void aumentar(int r)  
    {
        mascara.SetActive(true);
		if(Slider == posiciones.Length-1){
			if(r == Correctos[Slider]){
				retros.Aumentar();
				acertado = 1;
			}else{
				retros.Disminuir();
				acertado = 0;
			}
		 
			retros.Verficar2(retros.Correctos,3);
		}else{
			
			if(r == Correctos[Slider]){
				retros.Aumentar();
				acertado = 1;
			}else{
				retros.Disminuir();
				acertado = 0;
			}
            Cambiar(r,acertado);
			Slider++;
			
            StartCoroutine(clear());
		}
	}

	public void Cambiar(int s,int b){
		
        if(b == 1)
        {
		imagenes[s].sprite = sprites[int.Parse("" + posiciones[s].x)];
        }
        else{
            imagenes[s].sprite = sprites[int.Parse("" + posiciones[s].y)];
        }
	}

    public IEnumerator clear()
    {
        yield return new WaitForSeconds(2);
        Fondos.sprite = fondo[Slider];
        for (int i = 0; i<posiciones.Length;i++)
        {
            imagenes[i].sprite = sprites[int.Parse("" + posiciones[i].z)];
        }
       mascara.SetActive(false);
    } 

	public void Restore(){
		for (int i = 0; i<posiciones.Length;i++)
        {
            imagenes[i].sprite = sprites[int.Parse("" + posiciones[i].z)];
        }
		Slider = 0;
		retros.Restore();
        mascara.SetActive(false);
        Fondos.sprite = fondo[0];
	}
}
