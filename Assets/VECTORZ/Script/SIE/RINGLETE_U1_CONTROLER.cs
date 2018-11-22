using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class RINGLETE_U1_DATOS
{
    public string[] textos;
    public float[] correctos;
    public Sprite[] imagen;
}

public class RINGLETE_U1_CONTROLER : MonoBehaviour {
    public RINGLETE_U1_DATOS[] Datos;
    public GENERAL_INTERFAZ General;
    public INISIO_RECURSO Controler;
    public Monedas Monedas;
    public GameObject RetroBueno;
    public GameObject RetroMalo;
    public GameObject Drop;
    public GameObject Drag1;
    public GameObject Drag2;
    public Transform PadreDrag;
    public Transform PadreDrop;
    public int Correctos;
    public int Incorrectos;
    public int contador;
    public int contador_buenos;
    public int Estado = 0;
    public GameObject[] Cache1;
    public GameObject[] Cache2;
    public AudioSource AudioController;
    public AudioClip AudioBueno;
    public AudioClip AudioMalo;

    void Start () {
            Crear();
            Monedas.CrearMonedas(Datos.Length);
	}

	void Update () {
    }

    public void Crear()
    {
        bool pareja = true;
        PadreDrag.GetComponent<GridLayoutGroup>().enabled = true;
        for (int i = 0; i < Datos[Estado].textos.Length;i++)
        {
            if (pareja)
            {
                pareja = false;
                GameObject NewD1 = Instantiate(Drag1) as GameObject;
                NewD1.GetComponent<DRR>().texto.text = Datos[Estado].textos[i];
                NewD1.GetComponent<DRR>().ID = Datos[Estado].correctos[i];
                NewD1.GetComponent<DRR>().enabled = true;
                NewD1.GetComponent<LayoutElement>().enabled = true;
                NewD1.transform.SetParent(PadreDrag, false);
                NewD1.transform.SetSiblingIndex(Random.Range(0, Datos[Estado].textos.Length));
                NewD1.SetActive(true);
                Cache1[i] = NewD1;
            }
            else
            {
                pareja = true;
                GameObject NewD2 = Instantiate(Drag2) as GameObject;
                NewD2.GetComponent<DRR>().texto.text = Datos[Estado].textos[i];
                NewD2.GetComponent<DRR>().ID = Datos[Estado].correctos[i];
                NewD2.GetComponent<DRR>().enabled = true;
                NewD2.GetComponent<LayoutElement>().enabled = true;
                NewD2.transform.SetParent(PadreDrag, false);
                NewD2.transform.SetSiblingIndex(Random.Range(0, Datos[Estado].textos.Length));
                NewD2.SetActive(true);
                Cache1[i] = NewD2;
            }
        }

        int con = 0;
        for (int i = 0;i < Datos[Estado].imagen.Length;i++)
        {
            GameObject NewD1 = Instantiate(Drop) as GameObject;
            NewD1.GetComponent<RINGLETE_U1_DROP>().img.sprite = Datos[Estado].imagen[i];
            NewD1.GetComponent<RINGLETE_U1_DROP>().Id1.GetComponent<DPR>().ID = Datos[Estado].correctos[i] + con;
            con++;
            NewD1.GetComponent<RINGLETE_U1_DROP>().Id2.GetComponent<DPR>().ID = Datos[Estado].correctos[i] + con;
            NewD1.transform.SetParent(PadreDrop, false);
            NewD1.SetActive(true);
            Cache2[i] = NewD1;
        }
    }

    public void Clear()
    {
        contador = 0;
        contador_buenos = 0;
        for (int i = 0;i < Cache1.Length;i++)
        {
            if (Cache1[i] == null)
            {
            }
            else
            {
                Destroy(Cache1[i]);
            }
        }

        for (int i = 0; i < Cache2.Length; i++)
        {
            if (Cache2[i] == null)
            {
            }
            else
            {
                Destroy(Cache2[i]);
            }
        }
    }

    public void DES()
    {
        PadreDrag.GetComponent<GridLayoutGroup>().enabled = false;
    }

    public void Verificar(bool b)
    {
        if (b == true)
        {
            contador++;
            contador_buenos++;
        }
        else
        {
            contador++;
        }

        if (contador == Datos[Estado].textos.Length)
        {
            if (contador_buenos >= Datos[Estado].textos.Length)
            {
                Monedas.ParticulasCrear(Estado);
                Correctos++;
                AudioController.PlayOneShot(AudioBueno);
                StartCoroutine("Actualizar");
            }
            else
            {
                Incorrectos++;
                AudioController.PlayOneShot(AudioMalo);
                StartCoroutine("Actualizar");
            }
        }
    }

    public void Restore()
    {
        contador = 0;
        contador_buenos = 0;
        Correctos = 0;
        Incorrectos = 0;
        Estado = 0;
        RetroBueno.SetActive(false);
        RetroMalo.SetActive(false);
        Clear();
    }

    public IEnumerator Actualizar()
    {
        Estado++;
        if (Estado == Datos.Length)
        {
            if (Correctos >= 2)
            {
                StartCoroutine("RetroB");
            }
            else
            {
                StartCoroutine("RetroM");
            }
        }
        else
        {
            yield return new WaitForSeconds(2);
            Clear();
            Crear();
        }
        yield return new WaitForSeconds(0);
    }

    public IEnumerator RetroB()
    {
        yield return new WaitForSeconds(2);
        RetroBueno.SetActive(true);
        RetroMalo.SetActive(false);
    }

    public IEnumerator RetroM()
    {
        yield return new WaitForSeconds(2);
        RetroBueno.SetActive(false);
        RetroMalo.SetActive(true);
    }
}
