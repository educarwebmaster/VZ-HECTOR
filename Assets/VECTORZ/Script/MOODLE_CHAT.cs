using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System;
using System.Net;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class MOODLE_CHAT : MonoBehaviour {
    public MOODLE controlador;
	public CURSOS_MOODLE controlador_chat;
	public string id_chat; 
	public string[] chats;
	public GameObject profesor;
	public GameObject user;
	public Transform padreChats;
    public GameObject[] cache;
	public InputField chat_msg;
	public bool actualizar;
	void Start () {
		
	}
	void Update () {
		
	}

	public IEnumerator Actualizar(){
		yield return new WaitForSeconds(2);
		if(actualizar){
			Destroy();
			actualizar = true;
			controlador_chat.IniciarChatUP();
			cache = new GameObject[chats.Length - 1];
			for(int i = 0;i< cache.Length;i++){
				cache[i] = null;
			}
			for(int i = cache.Length - 1;i > -1;i--){
				string[] datos = chats[i].Split(new string[] {"£"}, StringSplitOptions.None);
				string mensage = datos[0];
				string usuario = datos[1];
				if(usuario == PlayerPrefs.GetString("NombreUsuario")){
					var NewChat = Instantiate(user) as GameObject;
					NewChat.transform.SetParent(padreChats, false);
					NewChat.GetComponent<MOODLE_MSG>().Mensage.text = mensage;
					NewChat.SetActive(true);
					cache[i] = NewChat;
				}else{
					var NewChat = Instantiate(profesor) as GameObject;
					NewChat.transform.SetParent(padreChats, false);
					NewChat.GetComponent<MOODLE_MSG>().Mensage.text = mensage;
					NewChat.SetActive(true);
					cache[i] = NewChat;
				}
			}
			StartCoroutine("Actualizar");
		}
	}

	public void CrearChat(){
		actualizar = true;
		cache = new GameObject[chats.Length - 1];
		for(int i = 0;i< cache.Length;i++){
			cache[i] = null;
		}
		StartCoroutine("Actualizar");
		for(int i = cache.Length - 1;i > -1;i--){
			string[] datos = chats[i].Split(new string[] {"£"}, StringSplitOptions.None);
			string mensage = datos[0];
			string usuario = datos[1];
			if(usuario == PlayerPrefs.GetString("NombreUsuario")){
			   var NewChat = Instantiate(user) as GameObject;
			   NewChat.transform.SetParent(padreChats, false);
			   NewChat.GetComponent<MOODLE_MSG>().Mensage.text = mensage;
			   NewChat.SetActive(true);
			   cache[i] = NewChat;
			}else{
			   var NewChat = Instantiate(profesor) as GameObject;
			   NewChat.transform.SetParent(padreChats, false);
			   NewChat.GetComponent<MOODLE_MSG>().Mensage.text = mensage;
			   NewChat.SetActive(true);
			   cache[i] = NewChat;
			}
		}
	}

	/*public void TraerTextura(RawImage Imagen,String Profe){
	   Imagen.texture = new WWW("http://localhost/CUESTIONARIOS/php/foto.php?user=" + Profe).texture;
	   Debug.Log("http://localhost/CUESTIONARIOS/php/foto.php?user=" + Profe);
	}*/

	public void Enviar_msg(){
		controlador_chat.EnviarChat();
	}

	public void Destroy(){
		for(int i = 0;i<cache.Length;i++){
			Destroy(cache[i]);
		}
		cache = new GameObject[0];
		actualizar = false;
	}
}
