using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System;
using System.Net;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class CURSOS_MOODLE : MonoBehaviour {
    public MOODLE Controlador;
	public Text Nombre;
	public Text Bienvenida;
	public string CursoNombre;
	public string CursoCode;
	public string CursoBienvenida;
	public string[] Cuestionarios;
	public string[] cs;
	public GameObject[] cache;
	public GameObject contenedor;
	public GameObject chat;

	// Use this for initialization
	void Start () {
		Nombre.text = CursoNombre;
		//Bienvenida.text = CursoBienvenida;
	}

	public void Crear_cuestionarios(){
		Controlador.Curso = this;
		PlayerPrefs.SetString("CursoActual",CursoCode);
		Controlador.QuitarCuestionarios();
		for(int i = 0;i < Cuestionarios.Length;i++){
            Controlador.CrearCuestionarios(Cuestionarios[i]);
		}
		llenarCache();
	}

	public void llenarCache(){
		cache = new GameObject[Cuestionarios.Length];
		for(int i = 0;i < cache.Length;i++){
			cache[i] = null;
		}
		for(int i = 0;i < cache.Length;i++){
			cache[i] = contenedor.transform.GetChild(i+1).gameObject;
		}
	}

	public void MostarRealizados(){
		for(int i = 0;i < cache.Length;i++){
               cache[i].SetActive(false);
		}
		for(int i = 0;i < cache.Length;i++){
			if(cache[i].GetComponent<CUESTIONARIO>().calificado){
               cache[i].SetActive(true);
			}
		}
	}

	public void MostrarNuevos(){
		for(int i = 0;i < cache.Length;i++){
               cache[i].SetActive(false);
		}
		for(int i = 0;i < cache.Length;i++){
			if(!cache[i].GetComponent<CUESTIONARIO>().calificado){
               cache[i].SetActive(true);
			}
		}
	}

	public void IniciarChat(){
		StartCoroutine("TraerChat");
	}

	public IEnumerator TraerChat(){
       Controlador.www = new WWW("http://127.0.0.1/CUESTIONARIOS_/php/Movil.php?procedimiento=" + "9&nombre=" + PlayerPrefs.GetString("NombreUsuario") + "&curso=" + CursoCode);//ahora traigo los datos del cuestionario y cursos
	   Debug.Log(Controlador.BBDD + "9&nombre=" + PlayerPrefs.GetString("NombreUsuario") + "&curso=" + CursoCode);
       yield return Controlador.www;
	   Debug.Log("chat" + Controlador.www.text);
	   string[] DATES_CHAT = Controlador.www.text.Replace(Environment.NewLine, "").Split(new string[] { "+" }, StringSplitOptions.None);
	   string[] CHATS = DATES_CHAT[0].Replace(Environment.NewLine, "").Split(new string[] { "¥" }, StringSplitOptions.None);
	   chat.GetComponent<MOODLE_CHAT>().chats = CHATS;
	   cs = CHATS;
	   chat.GetComponent<MOODLE_CHAT>().controlador_chat = this;
	   chat.GetComponent<MOODLE_CHAT>().CrearChat();
    }

    public void EnviarChat(){
		if(chat.GetComponent<MOODLE_CHAT>().chat_msg.text != ""){
			Debug.Log(Controlador.BBDD + "10&usuario=" + PlayerPrefs.GetString("NombreUsuario") + "&mensage=" + chat.GetComponent<MOODLE_CHAT>().chat_msg.text + "&codigo=" + CursoCode);
			string MSG = chat.GetComponent<MOODLE_CHAT>().chat_msg.text.Replace(" ","%20");;
			WWW www = new WWW(Controlador.BBDD + "10&usuario=" + PlayerPrefs.GetString("NombreUsuario") + "&mensage=" + MSG + "&codigo=" + CursoCode);//enviar chat
			chat.GetComponent<MOODLE_CHAT>().chat_msg.text = "";
		}
    }

	public void IniciarChatUP(){
		StartCoroutine("TraerChatUP");
	}

	public IEnumerator TraerChatUP(){
       Controlador.www = new WWW("http://127.0.0.1/CUESTIONARIOS_/php/Movil.php?procedimiento=" + "9&nombre=" + PlayerPrefs.GetString("NombreUsuario") + "&curso=" + CursoCode);//ahora traigo los datos del cuestionario y cursos
	   Debug.Log(Controlador.BBDD + "9&nombre=" + PlayerPrefs.GetString("NombreUsuario") + "&curso=" + CursoCode);
       yield return Controlador.www;
       Debug.Log("chat" + Controlador.www.text);
	   string[] DATES_CHAT = Controlador.www.text.Replace(Environment.NewLine, "").Split(new string[] { "+" }, StringSplitOptions.None);
	   string[] CHATS = DATES_CHAT[0].Replace(Environment.NewLine, "").Split(new string[] { "¥" }, StringSplitOptions.None);
	   chat.GetComponent<MOODLE_CHAT>().chats = CHATS;
	   cs = CHATS;
	   chat.GetComponent<MOODLE_CHAT>().controlador_chat = this;
    }
}
