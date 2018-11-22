using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class COMPRENDE_MAT2_U3_sistem{
public Sprite[] normal, sobre;
public Sprite fondo;
public int result;
}

public class COMPRENDE_MAT2_U3 : MonoBehaviour {

public RETROS controlador;
public Image[] botones;
public Image fondo;
public GameObject mascara;
public COMPRENDE_MAT2_U3_sistem[] sprites ;
public int slider;




public void randomizar ()
{
	for (int i=0;i<botones.Length;i++)
	{
		botones[i].transform.SetSiblingIndex(Random.Range(0,2));
	}

}

public void capturar (int boton)
{
	for(int i = 0;i<botones.Length;i++){
       botones[i].sprite = sprites[slider].normal[i];
	}
	botones[boton].sprite = sprites[slider].sobre[boton];
	mascara.SetActive(true);
	if(boton == sprites[slider].result)
	{
		controlador.Aumentar();
		botones[boton].transform.GetChild(0).gameObject.SetActive(true);
	}else
	{
		controlador.Disminuir();
		botones[boton].transform.GetChild(1).gameObject.SetActive(true);
	}

	if (slider == 4)
	{
		StartCoroutine(finalizar());

	}else
	{
		slider++;
		StartCoroutine(Cambiar());
	}
	
	
}
public IEnumerator finalizar ()
	{
		yield return new WaitForSeconds (2);
		controlador.Verficar(controlador.Correctos,3);
		StartCoroutine(controlador.FINAL());
	}

public IEnumerator Cambiar(){
	yield return new WaitForSeconds (2);
	for(int i = 0;i<botones.Length;i++){
       botones[i].sprite = sprites[slider].normal[i];
	   botones[i].transform.GetChild(0).gameObject.SetActive(false);
	   botones[i].transform.GetChild(1).gameObject.SetActive(false);
	}
	fondo.sprite = sprites[slider].fondo;
	mascara.SetActive(false);		

	}

	public void Restore()
	{
		controlador.Restore();

		for(int i = 0;i<botones.Length;i++){
       botones[i].sprite = sprites[0].normal[i];
	   botones[i].transform.GetChild(0).gameObject.SetActive(false);
	   botones[i].transform.GetChild(1).gameObject.SetActive(false);
	}
	fondo.sprite = sprites[0].fondo;
	mascara.SetActive(false);	

	slider = 0;

		
	}




	
}
