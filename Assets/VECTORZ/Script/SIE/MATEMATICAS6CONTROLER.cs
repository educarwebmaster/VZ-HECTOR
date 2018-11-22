using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class MATEMATICAS6CONTROLERmas
{
    public Sprite sprite1;
    public Sprite sprite2;
    public string elemento1;
    public string elemento2;
    public string titulo;
    public Vector2 respuestas;
}

public class MATEMATICAS6CONTROLER : MonoBehaviour {

    RETROS controlador;
    public MATEMATICAS6CONTROLERmas[] info;
    public GameObject Drag1;
    public GameObject Drag2;
    public GameObject Drop1;
    public GameObject Drop2;
    public GameObject RetroBueno;
    public GameObject RetroMalo;
    public GameObject Resultado;
    public Text texto1;
    public Text texto2;
    public Text titulo;
    public Text Buenos;
    public Text Malos;
    public int Correctos;
    public int Incorrectos;
    public int contador_buenos;
    public int contador;
    public int intentos;
    public int estado;
    public GENERAL_INTERFAZ General;
    public bool Inicial;

	// Use this for initialization
	void Start () {
        if (Inicial)
        {
            
            General.Abrir_visor_3d();
        }
        else
        {
            Mas(estado);
        }
    }

	// Update is called once per frame
	void Update () {
        if (Inicial)
        {
            General.Abrir_visor_3d();
        }
    }

    public void Verificar()
    {
        contador++;
        intentos++;
        if (contador == 2)
        {
            if (contador_buenos == 2)
            {
                Correctos++;
                contador_buenos = 0;
                contador = 0;
                RetroBueno.SetActive(true);
                RetroMalo.SetActive(false);
            }
            else
            {
                Incorrectos++;
                contador_buenos = 0;
                contador = 0;
                RetroBueno.SetActive(false);
                RetroMalo.SetActive(true);
            }
            if (intentos == 6)
            {
                StartCoroutine("ResultadoTotal");
            }
            else
            {
                estado++;
                StartCoroutine("Avanzar");
            }
        }
    }

    public IEnumerator Avanzar()
    {
        yield return new WaitForSeconds(2);
        Drag1.GetComponent<Drag3>().Restore();
        Drag2.GetComponent<Drag3>().Restore();
        Mas(estado);
    }

    public IEnumerator ResultadoTotal()
    {
        yield return new WaitForSeconds(2);
        Drag1.GetComponent<Drag3>().Restore();
        Drag2.GetComponent<Drag3>().Restore();
        Buenos.text = "" + Correctos;
        Malos.text = "" + Incorrectos;
        RetroBueno.SetActive(false);
        RetroMalo.SetActive(false);
        Resultado.SetActive(true);
    }

    public void Mas(int s)
    {
        Drag1.GetComponent<Drag3>().ID = info[s].respuestas.x;
        Drag2.GetComponent<Drag3>().ID = info[s].respuestas.y;
        Drag1.GetComponent<Image>().sprite = info[s].sprite1;
        Drag2.GetComponent<Image>().sprite = info[s].sprite2;
        texto1.text = info[s].elemento1;
        texto2.text = info[s].elemento2;
        titulo.text = info[s].titulo;
        RetroBueno.SetActive(false);
        RetroMalo.SetActive(false);
    }

    public void Restaurar()
    {
        contador = 0;
        Correctos = 0;
        Incorrectos = 0;
        contador_buenos = 0;
        intentos = 0;
        estado = 0;
        RetroBueno.SetActive(false);
        RetroMalo.SetActive(false);
        Drag1.GetComponent<Drag3>().Restore();
        Drag2.GetComponent<Drag3>().Restore();
        Mas(0);
    }
}
