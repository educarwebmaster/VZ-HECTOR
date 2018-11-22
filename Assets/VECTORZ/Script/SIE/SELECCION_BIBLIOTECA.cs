using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class InformacionBiblioteca
{
    public Vector3 Respuestas;
    public Vector3 TextosRespuestas;
    public Vector3 TextosPreguntas;
}

public class SELECCION_BIBLIOTECA : MonoBehaviour {

    public InformacionBiblioteca[] Cuestionario;
    public bool Inicial;
    public int Correctos;
    public int Contador;
    public int Cantidad;
    public GameObject Mascara;
    public GameObject RetroBuena;
    public GameObject RetroMala;
    public GENERAL_INTERFAZ General;
    public Monedas ControladorMonedas;
    public AudioClip SonidoBueno;
    public AudioClip SonidoMalo;
    public INISIO_RECURSO ControladorSIE;
    public Text D1;
    public Text D2;
    public Text D3;
    public Text R1;
    public Text R2;
    public Text R3;
    public GameObject Boton1;
    public GameObject Boton2;
    public GameObject Boton3;
    public GameObject Respuesta1;
    public GameObject Respuesta2;
    public GameObject Respuesta3;


    // Use this for initialization
    void Start () {
        if (Inicial)
        {
            General.Abrir_visor_3d();
        }
        else
        {
            Correctos = 0;
            Contador = 0;
            Mascara.SetActive(false);
            ControladorMonedas.CrearMonedas(Cantidad);
            AumentarPregunta();
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Inicial)
        {
            General.Abrir_visor_3d();
        }
    }

    public void Verificar(bool Validar)
    {
        if (Validar)
        {
            Correctos++;
            ControladorMonedas.ParticulasCrear(Contador);
            GetComponent<AudioSource>().PlayOneShot(SonidoBueno);
        }
        else
        {
            GetComponent<AudioSource>().PlayOneShot(SonidoMalo);
        }
        Contador++;
        Retro();
        
    }

    public IEnumerator StartNewPregun()
    {
        Mascara.SetActive(true);
        yield return new WaitForSeconds(1);
        Mascara.SetActive(false);
        AumentarPregunta();
    }

    public void AumentarPregunta()
    {
        for (int i = 0; i < Cuestionario.Length; i++)
        {
            D1.text = "" + Cuestionario[Contador].TextosRespuestas.x;
            D2.text = "" + Cuestionario[Contador].TextosRespuestas.y;
            D3.text = "" + Cuestionario[Contador].TextosRespuestas.z;
            Boton1.GetComponent<Drag2>().ID = Cuestionario[Contador].Respuestas.x;
            Boton2.GetComponent<Drag2>().ID = Cuestionario[Contador].Respuestas.y;
            Boton3.GetComponent<Drag2>().ID = Cuestionario[Contador].Respuestas.z;

            if (Cuestionario[Contador].TextosPreguntas.x == 100)
            {
                R1.text = "?";
                Respuesta1.GetComponent<Drop2>().enabled = true;
            }
            else
            {
                R1.text = "" + Cuestionario[Contador].TextosPreguntas.x;
                Respuesta1.GetComponent<Drop2>().enabled = false;
            }

            if (Cuestionario[Contador].TextosPreguntas.y == 100)
            {
                R2.text = "?";
                Respuesta2.GetComponent<Drop2>().enabled = true;
            }
            else
            {
                R2.text = "" + Cuestionario[Contador].TextosPreguntas.y;
                Respuesta2.GetComponent<Drop2>().enabled = false;
            }

            if (Cuestionario[Contador].TextosPreguntas.z == 100)
            {
                R3.text = "?";
                Respuesta3.GetComponent<Drop2>().enabled = true;
            }
            else
            {
                R3.text = "" + Cuestionario[Contador].TextosPreguntas.z;
                Respuesta3.GetComponent<Drop2>().enabled = false;
            }

        }
    }

    public void Retro()
    {
        if (Contador == Cantidad)
        {
            if (Correctos > (7))
            {
                RetroBuena.SetActive(true);
            }
            else
            {
                RetroMala.SetActive(true);
            }
        }
        else
        {
            StartCoroutine("StartNewPregun");
        }
    }

    public void DestroiCache()
    {
        if (Correctos > 7)
        {
            Contador = 0;
            Correctos = 0;
            ControladorSIE.Reiniciar();
            RetroBuena.SetActive(false);
            RetroMala.SetActive(false);
            ControladorMonedas.DestruirMonedas();
            ControladorMonedas.CrearMonedas(Cantidad);
        }
        else
        {
            Contador = 0;
            Correctos = 0;
            RetroBuena.SetActive(false);
            RetroMala.SetActive(false);
            ControladorMonedas.DestruirMonedas();
            ControladorMonedas.CrearMonedas(Cantidad);
        }
    }
}
