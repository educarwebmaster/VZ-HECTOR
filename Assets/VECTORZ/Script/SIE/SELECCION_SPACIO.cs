using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class OBJETOS_SPACIO
{
    public Image Elementos;
    public GameObject LETREROS;
}

public class SELECCION_SPACIO : MonoBehaviour {

    public OBJETOS_SPACIO[] Objetos;
    public Color ColorInicial;
    public Color ColorSeleccionado;
    public bool Inicial;
    public GENERAL_INTERFAZ General;

    // Use this for initialization
    void Start () {
        if (Inicial)
        {
            General.Abrir_visor_3d();
        }
        else
        {
            Desactivar();
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Inicial)
        {
            General.Abrir_visor_3d();
        }
    }

    public void Activar(int obj)
    {
        Desactivar();
        Objetos[obj].Elementos.color = ColorSeleccionado;
        Objetos[obj].LETREROS.SetActive(true);
    }

    public void Desactivar()
    {
        for (int i = 0; i < Objetos.Length; i++)
        {
            Objetos[i].Elementos.color = ColorInicial;
            Objetos[i].LETREROS.SetActive(false);
        }
    }
}

