using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class MATEMATICAS_SELECCION_array
{
    public int Correcto;
    public int Divisor;
    public string Pregunta;
    public Vector3 Array1;
    public Vector3 Array2;
}

public class MATEMATICAS_SELECCION : MonoBehaviour {

    public MATEMATICAS_SELECCION_array[] Datos;
    public GameObject[] Botones;
    public Text[] Textos;
    public GameObject RetroBuena;
    public GameObject RetroMala;
    public GameObject Retroalimentacion;
    public int Correctos;
    public int Incorrectos;
    public int contador;
    public int contadorBuenos;
    public int Estados;
    public Color colorNormal;
    public Color colorPresionado;
    public Text Buenos;
    public Text Malos;
    public Text Informacion;
    public bool Iniciar;
    public GENERAL_INTERFAZ General;

	// Use this for initialization
	void Start () {
        if (Iniciar)
        {
            General.Abrir_visor_3d();
        }
        else
        {
            Estados = 0;
            Crear(Estados);
            
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Iniciar)
        {
            General.Abrir_visor_3d();
        }
        else
        {
            Buenos.text = "" + Correctos;
            Malos.text = "" + Incorrectos;
        }
    }

    public void Crear(int Estado)
    {
        Botones[0].GetComponent<MATEMATICAS_BOTONES_SELECCION_>().ID = Datos[Estado].Array1.x;
        Botones[1].GetComponent<MATEMATICAS_BOTONES_SELECCION_>().ID = Datos[Estado].Array1.y;
        Botones[2].GetComponent<MATEMATICAS_BOTONES_SELECCION_>().ID = Datos[Estado].Array1.z;
        Botones[3].GetComponent<MATEMATICAS_BOTONES_SELECCION_>().ID = Datos[Estado].Array2.x;
        Botones[4].GetComponent<MATEMATICAS_BOTONES_SELECCION_>().ID = Datos[Estado].Array2.y;
        Botones[5].GetComponent<MATEMATICAS_BOTONES_SELECCION_>().ID = Datos[Estado].Array2.z;
        Textos[0].text = "" + Datos[Estado].Array1.x;
        Textos[1].text = "" + Datos[Estado].Array1.y;
        Textos[2].text = "" + Datos[Estado].Array1.z;
        Textos[3].text = "" + Datos[Estado].Array2.x;
        Textos[4].text = "" + Datos[Estado].Array2.y;
        Textos[5].text = "" + Datos[Estado].Array2.z;
        for (int i = 0; i < Botones.Length; i++)
        {
            Botones[i].transform.SetSiblingIndex(int.Parse("" + Random.Range(0, 5) + ""));
            Botones[i].GetComponent<Image>().color = colorNormal;
            Botones[i].GetComponent<Button>().enabled = true;
        }
        Informacion.text = Datos[Estado].Pregunta;
    }

    public void Verificar(float Respuesta)
    {
        if ((Datos[Estados].Divisor% Respuesta) ==0)
        {
            contadorBuenos++;
        }
        else
        {
            contadorBuenos--;
        }
    }

    public void Termine()
    {
        if(contadorBuenos == Datos[Estados].Correcto){
            Correctos++;
            StartCoroutine("RetroB");
        }
        else
        {
            Incorrectos++;
            StartCoroutine("RetroM");
        }
    }

    public void Restore()
    {
        if (contador == Datos.Length)
        {
            Retroalimentacion.SetActive(true);
        }
        else
        {
            RetroBuena.SetActive(false);
            RetroMala.SetActive(false);
            contadorBuenos = 0;
            Estados++;
            Crear(Estados);
        }
    }

    public void Restaurar()
    {
        Estados = 0;
        contador = 0;
        contadorBuenos = 0;
        Correctos = 0;
        Incorrectos = 0;
        RetroBuena.SetActive(false);
        RetroMala.SetActive(false);
        contadorBuenos = 0;
        Crear(Estados);
    }

    public IEnumerator RetroB()
    {
        contador++;
        RetroBuena.SetActive(true);
        RetroMala.SetActive(false);
        yield return new WaitForSeconds(3);
        Restore();
    }

    public IEnumerator RetroM()
    {
        contador++;
        RetroBuena.SetActive(false);
        RetroMala.SetActive(true);
        yield return new WaitForSeconds(3);
        Restore();
    }
}
