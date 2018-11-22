using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZOOM_TEXT : MonoBehaviour {
    public GameObject Zoom;
	public Text Zoom_text;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Agrandar(Text texto){
		Zoom_text.text = texto.text;
		Zoom.SetActive(true);
	}

	public void Cerrar(){
		Zoom_text.text = "";
		Zoom.SetActive(false);
	}
}
