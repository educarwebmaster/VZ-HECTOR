using UnityEngine;
using System.Collections;

public class MULTISELECCION_OBJETOS : MonoBehaviour {

    public GameObject[] Objetos;
    public int Seleccionar;
	void Start () {
	
	}
	
	void Update () {
	
	}

    public void Siguiente()
    {
        if (Seleccionar < Objetos.Length)
        {
            Desabilitar();
            Seleccionar += 1;
            Objetos[Seleccionar].SetActive(true);
        }
    }

    public void Atras()
    {
        if (Seleccionar > 0)
        {
            Desabilitar();
            Seleccionar -= 1;
            Objetos[Seleccionar].SetActive(true);
        }
    }

    void Desabilitar()
    {
        for (int i = 0; i < Objetos.Length; i++)
        {
            Objetos[i].SetActive(false);
        }
    }
}
