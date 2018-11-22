using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class RINGLETE_U4_DATOS
{
    public bool Correcto;
    public GameObject boton;
}

public class RINGLETE_U4_SELECCION : MonoBehaviour
{
    public RINGLETE_U4_DATOS[] Datos;
    public INISIO_RECURSO InicioController;
    public Monedas Moneda;
    public GENERAL_INTERFAZ General;
    public int Correcto;
    public int Incorrecto;
    public int Estado;
    public int contador;
    public GameObject RestroBuena;
    public GameObject RestroMala;
    public GameObject Mascara;
    public AudioSource audioController;
    public AudioClip audioBueno;
    public AudioClip audioMalo;

    // Use this for initialization
    void Start()
    {
            Moneda.CrearMonedas(6);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Verificar(int i)
    {
        if (Datos[i].Correcto)
        {
            Correcto++;
            Mascara.SetActive(true);
            audioController.PlayOneShot(audioBueno);
            Moneda.ParticulasCrear(Estado);
            Datos[i].boton.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            Incorrecto++;
            Mascara.SetActive(true);
            audioController.PlayOneShot(audioMalo);
            Datos[i].boton.transform.GetChild(1).gameObject.SetActive(true);
        }
        StartCoroutine("Aumentar");
    }

    public IEnumerator Aumentar()
    {
        contador++;
        Estado++;
        yield return new WaitForSeconds(0.2f);
        if (contador >= 6)
        {
            if (Correcto >= 4)
            {
                RB();

            }
            else
            {
                RM();
            }
        }
        else
        {
            Mascara.SetActive(false);
        }

    }

    public void Restore()
    {
        Correcto = 0;
        Incorrecto = 0;
        Estado = 0;
        contador = 0;
        Mascara.SetActive(false);
        RestroBuena.SetActive(false);
        RestroMala.SetActive(false);
        Moneda.DestruirMonedas();
        for (int i = 0;i < Datos.Length;i++)
        {
            Datos[i].boton.transform.GetChild(0).gameObject.SetActive(false);
            Datos[i].boton.transform.GetChild(1).gameObject.SetActive(false);
        }
        Moneda.CrearMonedas(6);
    }

    public void RM()
    {
        RestroBuena.SetActive(false);
        RestroMala.SetActive(true);
    }

    public void RB()
    {
        RestroBuena.SetActive(true);
        RestroMala.SetActive(false);
    }
}
