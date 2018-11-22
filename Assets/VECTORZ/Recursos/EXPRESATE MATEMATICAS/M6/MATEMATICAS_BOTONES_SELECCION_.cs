using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MATEMATICAS_BOTONES_SELECCION_ : MonoBehaviour {

    public MATEMATICAS_SELECCION Controlador;
    public Color color;
    public float ID;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Verificacion(Image Img)
    {
        Img.color = color;
        Controlador.Verificar(ID);
        enabled = false;
    }
}
