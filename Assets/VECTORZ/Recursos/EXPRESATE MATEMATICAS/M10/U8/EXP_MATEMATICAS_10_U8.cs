using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class EXP_MATEMATICAS_10_U8 : MonoBehaviour {

	public InputField[] x, y;
	public Text[] resultxy, resultx2; 
	public Text sumax, sumay, final;  
	public float a, b, zx, zy, zxy, zx2;
	public bool detectar;
	public GameObject popup;


	public void  analizar()
	{
		
		a=0.0f; b=0.0f; zx=0.0f; zy=0.0f; zxy=0.0f; zx2=0.0f; 
		float sx =0.0f;
		float sy =0.0f;
		int contar = 0;

		for (int i=0;i<x.Length;i++)
		{
			if (x[i].text != "")
			{
				contar++;
			}
			if (y[i].text != "")
			{
				contar++;
			}
		}
		if(contar==10){
			for (int i=0;i<x.Length;i++)
			{			
					if (x[i].text != "")
					{
						sx = sx + float.Parse(x[i].text);
					}
					
				
					if (y[i].text != "")
					{
						sy = sy + float.Parse(y[i].text);
					}
					zxy = zxy + (float.Parse(x[i].text) * float.Parse(y[i].text));
					zx2 = zx2 + (float.Parse(x[i].text) * float.Parse(x[i].text));
					resultxy[i].text = "" + (float.Parse(x[i].text) * float.Parse(y[i].text));
					resultx2[i].text = "" + (float.Parse(x[i].text) * float.Parse(x[i].text));
			}
			zx = sx;
			zy = sy;
			sumax.text = ""+ zx;
			sumay.text = ""+ zy;
			resultxy[5].text = "" + zxy;
			resultx2[5].text = "" + zx2;
			b = B_(zx, zy, zxy, zx2);
			a = A_ (zy, zx);
			detectar = true;
			}
	}
	 	
	public void ecuacion()
	{
		if (detectar)
		{
			Debug.LogWarning("Y=" + b.ToString() + " X+" + a.ToString());
			if (a>0)
			{

					 popup.SetActive(true);
					final.text = "Y=" + Math.Round(b,2) + " X+" + Math.Round(a,2);
			}
			else
			{		
					 popup.SetActive(true);
					final.text = "Y=" + Math.Round(b,2) + " X" + Math.Round(a,2);
			}
		
		} 
	}

	public float B_ (float nzx, float nzy, float nzxy, float nzx2)
	{
		float numerador = 0;
		float denominador = 0;
		numerador = 5*nzxy - (nzx * nzy);
		denominador = 5*nzx2 - (nzx * nzx);

		return numerador/denominador;
	}
	
	public float A_ (float nzy,float nzx)
	{
		float numerador = 0;
		float denominador = 0;
		numerador = nzy - ( b * nzx);
		denominador = 5;

		return numerador/denominador;
	}

	public void Restore()
	{
		for (int i=0;i<x.Length;i++)
		{
			x[i].text = "";
		}
		for (int i=0;i<y.Length;i++)
		{
			y[i].text = "";
		}
		for (int i=0;i<resultxy.Length;i++)
		{
			resultxy[i].text = "";
		}
		for (int i=0;i<resultx2.Length;i++)
		{
			resultx2[i].text = "";
		}

		sumax.text="";
		sumay.text="";
		final.text="";

	}
	

}
