using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class INISIO_RECURSO : MonoBehaviour {
    [Header("Escenas")]
    public GameObject ScenaIncial;
    public GameObject ScenaConosco;
    public GameObject ScenaTutorial;
    public GameObject ScenaContador;
    public GameObject ScenaActividad;
    public GameObject RetroBuena;
    public GameObject RetroMala;
    public GameObject MensajeInfo;
    [Header("Tiempos")]
    public int TimeConosco;
    public int TimeContador;
    public int TimeTutorial;
    public int TimeInfo;
    [Header("Activadores")]
    public bool Conoscob;
    public bool Contadorb;
    public bool Tutorialb;

    // Use this for initialization
    void Start () {
        RetroBuena.SetActive(false);
        RetroMala.SetActive(false);
        ScenaIncial.SetActive(true);
        ScenaConosco.SetActive(false);
        ScenaActividad.SetActive(false);
        ScenaTutorial.SetActive(false);
        ScenaContador.SetActive(false);
        MensajeInfo.SetActive(false);
    }

    public void Iniciar()
    {
        ScenaIncial.SetActive(false);
        ScenaConosco.SetActive(true);
        ScenaContador.SetActive(false);
        ScenaTutorial.SetActive(false);
        ScenaActividad.SetActive(false);
        MensajeInfo.SetActive(false);
        StartCoroutine("Conosco");
    }

    public IEnumerator Conosco()
    {
        if (Conoscob)
        {
            yield return new WaitForSeconds(TimeConosco);
            ScenaIncial.SetActive(false);
            ScenaConosco.SetActive(false);
            ScenaActividad.SetActive(false);
            ScenaTutorial.SetActive(true);
            ScenaContador.SetActive(false);
            MensajeInfo.SetActive(false);
            StartCoroutine("Tutorial");
        }
        else
        {

        }
    }

    public IEnumerator Contador()
    {
        if (Contadorb)
        {
            yield return new WaitForSeconds(TimeContador);
            ScenaIncial.SetActive(false);
            ScenaConosco.SetActive(false);
            ScenaActividad.SetActive(true);
            ScenaTutorial.SetActive(false);
            ScenaContador.SetActive(false);
            MensajeInfo.SetActive(false);
        }
        else
        {

        }
    }

    public IEnumerator Tutorial()
    {
        if (Tutorialb)
        {
            yield return new WaitForSeconds(TimeTutorial);
            ScenaIncial.SetActive(false);
            ScenaConosco.SetActive(false);
            ScenaActividad.SetActive(false);
            ScenaTutorial.SetActive(true);
            ScenaContador.SetActive(true);
            MensajeInfo.SetActive(false);
            StartCoroutine("Contador");
        }
        else
        {

        }
    }

    public void Reiniciar()
    {
        ScenaIncial.SetActive(true);
        ScenaConosco.SetActive(false);
        ScenaActividad.SetActive(false);
        ScenaTutorial.SetActive(false);
        ScenaContador.SetActive(false);
        RetroBuena.SetActive(false);
        RetroMala.SetActive(false);
        MensajeInfo.SetActive(false);
    }

    public void InfoFuntion()
    {
        StartCoroutine("Info");
    }

    public IEnumerator Info()
    {
        MensajeInfo.SetActive(true);
        yield return new WaitForSeconds(TimeInfo);
        MensajeInfo.SetActive(false);
    }
}
