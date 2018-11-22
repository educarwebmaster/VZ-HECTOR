using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LENGUAJE_1_EXP_U3 : MonoBehaviour {
	public RETROS Controlador;
	public Color colorNormal,colorSelect;
	public int Puntos,Slide,SlideActividad;
	public Vector3 Seleccionados;
	public Vector3[] Correctos,positions;
	public Sprite[] Infos,Fondos,BotonesNormales,BotonesBuenos,BotonesMalos,Titulos;
	public Image Fondo,Info,titulo;
	public Image[] Botones;
	public GameObject RetroAct1,SCS,SCA,Mascara;

	public void Next(){
		if(Slide<Infos.Length-1){
			Slide++;
			Cambiar(Slide);
		}else if(Slide==3){
			Controlador.Info(RetroAct1);
			Slide=0;
			Cambiar(0);
			SCS.SetActive(false);
			SCA.SetActive(true);
			SlideActividad = 0;
			Seleccionados = new Vector3(0,0,0);
			titulo.sprite = Titulos[SlideActividad];
			Botones[0].sprite = BotonesNormales[int.Parse(positions[SlideActividad].x + "")];
			Botones[1].sprite = BotonesNormales[int.Parse(positions[SlideActividad].y + "")];
			Botones[2].sprite = BotonesNormales[int.Parse(positions[SlideActividad].z + "")];
		}
	}

	public void After(){
		if(Slide>0){
			Slide--;
		}
		Cambiar(Slide);
	}

	public void Cambiar(int e){
		Info.sprite = Infos[e];
		Fondo.sprite = Fondos[e];
	}

	public void Ver(){
		Mascara.SetActive(true);
		Botones[0].color = colorNormal;
		Botones[1].color = colorNormal;
		Botones[2].color = colorNormal;
		if(Seleccionados.x == 1){
			if(Correctos[SlideActividad].x == 0){
				Puntos++;
				Controlador.Aumentar();
				Botones[0].sprite = BotonesBuenos[int.Parse(positions[SlideActividad].x + "")];
			}else{
				Controlador.Disminuir();
				Botones[0].sprite = BotonesMalos[int.Parse(positions[SlideActividad].x + "")];
			}
		}
		if(Seleccionados.y == 1){
			if(Correctos[SlideActividad].y == 0){
				Puntos++;
				Controlador.Aumentar();
				Botones[1].sprite = BotonesBuenos[int.Parse(positions[SlideActividad].y + "")];
			}else{
				Controlador.Disminuir();
				Botones[1].sprite = BotonesMalos[int.Parse(positions[SlideActividad].y + "")];
			}
		}
		if(Seleccionados.z == 1){
			if(Correctos[SlideActividad].z == 0){
				Puntos++;
				Controlador.Aumentar();
				Botones[2].sprite = BotonesBuenos[int.Parse(positions[SlideActividad].z + "")];
			}else{
				Controlador.Disminuir();
				Botones[2].sprite = BotonesMalos[int.Parse(positions[SlideActividad].z + "")];
			}
		}
		if(SlideActividad==Correctos.Length-1){
			Controlador.Verficar(Controlador.Correctos - Controlador.Incorrectos,5);
			Mascara.SetActive(false);
			StartCoroutine(Controlador.FINAL());
		}else{
			StartCoroutine(AumentarAct());
		}
		
	}

	public void Saltar(int env){
		if(env == 0){
			Seleccionados.x = 1;
			
		}
		if(env == 1){
			Seleccionados.y = 1;
		}
		if(env == 2){
			Seleccionados.z = 1;
		}
		Botones[env].color = colorSelect;
	}

	public IEnumerator AumentarAct(){
		yield return new WaitForSeconds(2);
		Mascara.SetActive(false);
		SlideActividad++;
		Seleccionados = new Vector3(0,0,0);
		Botones[0].sprite = BotonesNormales[int.Parse(positions[SlideActividad].x + "")];
		Botones[0].color = colorNormal;
		Botones[1].sprite = BotonesNormales[int.Parse(positions[SlideActividad].y + "")];
		Botones[1].color = colorNormal;
		Botones[2].sprite = BotonesNormales[int.Parse(positions[SlideActividad].z + "")];
		Botones[2].color = colorNormal;
		titulo.sprite = Titulos[SlideActividad];
	}

	public void Restore(){
		Mascara.SetActive(false);
		Puntos = 0;
		Slide = 0;
		SlideActividad = 0;
		Botones[0].color = colorNormal;
		Botones[1].color = colorNormal;
		Botones[2].color = colorNormal;
		titulo.sprite = Titulos[SlideActividad];
		Botones[0].sprite = BotonesNormales[int.Parse(positions[SlideActividad].x + "")];
		Botones[1].sprite = BotonesNormales[int.Parse(positions[SlideActividad].y + "")];
		Botones[2].sprite = BotonesNormales[int.Parse(positions[SlideActividad].z + "")];
	}


}
