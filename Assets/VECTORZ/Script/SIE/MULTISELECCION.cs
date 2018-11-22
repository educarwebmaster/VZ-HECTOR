using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MULTISELECCION : MonoBehaviour {

    public GENERAL_INTERFAZ general;
    public INISIO_RECURSO ControladorSIE;
    public bool Inicial;
    public GameObject RetroBuena;
    public GameObject RetroMala;
    public Transform PadreElementos;
    public GameObject Elemento;
    public Color colorBueno;
    public Color colorMalo;
    public int Contador;
    public int Punto;
    public int Max;
    private GameObject[] cache;

	// Use this for initialization
	void Start () {
        if (Inicial)
        {
            general.Abrir_visor_3d();
        }
        else
        {
            Contador = 0;
            Punto = 0;
            cache = new GameObject[Max];
            Crear();
        }
        
	}

	// Update is called once per frame
	void Update () {
        if (Inicial)
        {
            general.Abrir_visor_3d();
        }
    }

    public void Crear()
    {
        for (int i = 0;i < Max;i++)
        {
            GameObject newElement = Instantiate(Elemento) as GameObject;
            newElement.transform.SetParent(PadreElementos,false);
            newElement.transform.SetSiblingIndex(Random.Range(0,Max));
            newElement.GetComponent<ELEMENTP_MULTISELECCION>().ID = i + 1;
            newElement.GetComponent<ELEMENTP_MULTISELECCION>().texto.text = "" + (i + 1);
            newElement.SetActive(true);
            cache[i] = newElement;
        }
    }

    public void Contando(int posicion,GameObject Objeto)
    {
        Contador++;
        Punto = posicion;
        if (Punto == Contador)
        {
            Objeto.GetComponent<Image>().color = colorBueno;
            if (Contador == Max)
            {
                StartCoroutine("RetroB");
            }
        }
        else
        {
            Objeto.GetComponent<Image>().color = colorMalo;
            StartCoroutine("RetroM");
        }
    }

    public void DestroiCache()
    {
        if (Contador == Max)
        {
            
            for (int i = 0; i < cache.Length; i++)
            {
                Destroy(cache[i]);
            }
            Contador = 0;
            Punto = 0;
            cache = new GameObject[Max];
            ControladorSIE.Reiniciar();
            RetroBuena.SetActive(false);
            RetroMala.SetActive(false);
            Crear();
        }
        else
        {
            for (int i = 0; i < cache.Length; i++)
            {
                Destroy(cache[i]);
            }
            Contador = 0;
            Punto = 0;
            cache = new GameObject[Max];
            RetroBuena.SetActive(false);
            RetroMala.SetActive(false);
            Crear();
        }
    }

    public IEnumerator RetroB()
    {
        yield return new WaitForSeconds(0.2f);
        RetroBuena.SetActive(true);
        RetroMala.SetActive(false);
    }

    public IEnumerator RetroM()
    {
        yield return new WaitForSeconds(0.2f);
        RetroBuena.SetActive(false);
        RetroMala.SetActive(true);
    }
}
