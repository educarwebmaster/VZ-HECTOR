using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ELEMENTP_MULTISELECCION : MonoBehaviour {

    public MULTISELECCION Controlador;
    public int ID;
    public Text texto;
    private bool Activado = false;
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Enviar()
    {
        if (Activado)
        {

        }
        else
        {
            Activado = true;
            Controlador.Contando(ID, this.gameObject);
        }
        
    }
}
