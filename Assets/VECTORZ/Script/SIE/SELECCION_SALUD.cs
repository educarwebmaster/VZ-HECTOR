using UnityEngine;
using System.Collections;

public class SELECCION_SALUD : MonoBehaviour {

    public bool Inicial;
    public int Correctos;
    public int Contador;
    public int Cantidad;
    public GameObject Mascara;
    public GameObject RetroBuena;
    public GameObject RetroMala;
    public GameObject Ambulancia;
    public GameObject[] Botones;
    public GENERAL_INTERFAZ General;
    public Monedas ControladorMonedas;
    public AudioClip SonidoBueno;
    public AudioClip SonidoMalo;
    public INISIO_RECURSO ControladorSIE;

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
        }
	}
	
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
            StartCoroutine("StartAmbulance");
        }
        else
        {
            GetComponent<AudioSource>().PlayOneShot(SonidoMalo);
        }
        Contador++;
        StartCoroutine("Retro");
    }

    public IEnumerator StartAmbulance()
    {
        Transform inicio = Ambulancia.GetComponent<Transform>();
        Ambulancia.GetComponent<Animator>().Play("Ambulancia");
        Mascara.SetActive(true);
        yield return new WaitForSeconds(2);
        Mascara.SetActive(false);
        Ambulancia.transform.position = inicio.position;
    }

    public IEnumerator Retro()
    {
        yield return new WaitForSeconds(1.5f);
        if (Contador == Cantidad)
        {
            if (Contador == Correctos)
            {
                RetroBuena.SetActive(true);
            }
            else
            {
                RetroMala.SetActive(true);
            }
        }
    }

    public void DestroiCache()
    {
        for (int i = 0; i < Botones.Length; i++)
        {
            Botones[i].SetActive(true);
            Botones[i].GetComponent<Drag>().Recreate();
        }
        if (Contador == Correctos)
        {
            Contador = 0;
            Correctos = 0;
            //ControladorMonedas.Moneda = new Moneda[Cantidad];
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
            //ControladorMonedas.Moneda = new Moneda[Cantidad];
            RetroBuena.SetActive(false);
            RetroMala.SetActive(false);
            ControladorMonedas.DestruirMonedas();
            ControladorMonedas.CrearMonedas(Cantidad);
        }
        
    }
}
