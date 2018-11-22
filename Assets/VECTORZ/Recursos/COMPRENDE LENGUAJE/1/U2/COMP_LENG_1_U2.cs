using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class COMP_LENG_1_U2 : MonoBehaviour {

	public RETROS retros;
	public Image[] botones;
	public GameObject[] filas, mascara;
	public Animator niño;
	public Color colorv, colorr, colorn;
	public bool estado;
	public int slider;
	public RectTransform posinicial;

	
	void Start()
	{
		
	}

	public void validarBot (int v) 
	{
		if (v == 0)
		{
			
			mascara[slider].SetActive(true);
			slider++;
			filas[slider].SetActive(true);
			niño.Play("caminar" + slider);
			retros.Aumentar();
			if (slider == 3)
			{
				StartCoroutine(Final(4,3));	
			}
		}
		else 
		{
			StartCoroutine(Final(2,2));	
			mascara[slider].SetActive(true);
		}
	}
	public void pintarv (Image m)
	{
		m.color = colorv;
	}
	public void pintarr (Image m)
	{
		m.color = colorr;
	}

	public IEnumerator Final(int s, int t){
		yield return new WaitForSeconds (s);
		retros.Verficar2(t,3);	

	}

	public void Restore()
	{
		slider = 0;
		retros.Restore();

		for(int i=0;i<mascara.Length;i++)
		{
			mascara[i].SetActive(false);
			
		}
		niño.Play("Static");
		for(int i=1;i<mascara.Length;i++)
		{
			filas[i].SetActive(false);

		}
			for(int i=0;i<botones.Length;i++)
		{
			botones[i].color = colorn;

		}

	}
 

}
