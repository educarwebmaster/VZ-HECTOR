using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RINGLETE_C_U3 : MonoBehaviour {

	public Sprite[] fondosniño, fondosniña, botonesactiv, botonesdesactiv;
	public Image fondo;
	public Image[] botones;
	public AudioClip[] audiosniño, audiosniña;
	public AudioSource audio;
	public GameObject niño, niña, letreroxx, letreroxy;
	public bool sexo;

	
	public void cambiar (int escena)
	{
		if(sexo)
		{
			fondo.sprite = fondosniño[escena];
			for (int i=0;i<botones.Length;i++)
			{
				botones[i].sprite = botonesdesactiv[i];
			}
			botones[escena].sprite = botonesactiv[escena];
			audio.clip = audiosniño[escena];
			audio.Stop();
			audio.Play();
		}else
		{
			fondo.sprite = fondosniña[escena];
			for (int i=0;i<botones.Length;i++)
			{
				botones[i].sprite = botonesdesactiv[i];
			}
			botones[escena].sprite = botonesactiv[escena];
			audio.clip = audiosniña[escena];
			audio.Stop();
			audio.Play();
		}
	}
	
	public void sexos(bool xy)
	{
		sexo = xy;
		if (sexo)
		{
			letreroxx.SetActive(false);
			niña.SetActive(false);
			niño.SetActive(true);
			letreroxy.SetActive(true);
		}else
		{
			letreroxy.SetActive(false);
			niño.SetActive(false);
			niña.SetActive(true);
			letreroxx.SetActive(true);
		}

	}
	
}
