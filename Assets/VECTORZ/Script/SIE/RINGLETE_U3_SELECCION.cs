using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class RINGLETE_U3_DATOS
{
    public int Respuestas;
    public Sprite Imagenen;
}

public class RINGLETE_U3_SELECCION : MonoBehaviour {

    public RINGLETE_U3_DATOS[] Datos;
    public INISIO_RECURSO InicioController;
    public Monedas Moneda;
    public GENERAL_INTERFAZ General;
    public Image Fondo;
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
    void Start () {
            Moneda.CrearMonedas(4);
	}
	
	// Update is called once per frame
	void Update () {
    }

    public void Verificar(int i)
    {
        if (i == Datos[Estado].Respuestas)
        {
            Correcto++;
            Mascara.SetActive(true);
            audioController.PlayOneShot(audioBueno);
            Moneda.ParticulasCrear(Estado);
        }
        else
        {
            Incorrecto++;
            Mascara.SetActive(true);
            audioController.PlayOneShot(audioMalo);
        }
        StartCoroutine("Aumentar");
    }

    public IEnumerator Aumentar()
    {
        contador++;
        Estado++;
        yield return new WaitForSeconds(1);
        if (contador == Datos.Length)
        {
            if (Correcto >= 3)
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
            Fondo.sprite = Datos[Estado].Imagenen;
            Mascara.SetActive(false);
        }
        
    }

    public void Restore()
    {
       Correcto = 0;
       Incorrecto = 0;
       Estado = 0;
       contador = 0;
       Fondo.sprite = Datos[Estado].Imagenen;
       Mascara.SetActive(false);
        RestroBuena.SetActive(false);
        RestroMala.SetActive(false);
        Moneda.DestruirMonedas();
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
