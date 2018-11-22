using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class MATEMATICAS7_U4_DATOS
{
    public int Correctos;
    public string Pregunta;
    public string Texto1;
    public string Texto2;
    public string Texto3;
    public Sprite imagen;
}

public class MATEMATICAS7_U4 : MonoBehaviour {

    public MATEMATICAS7_U4_DATOS[] Datos;
    public GameObject Bt;
    public RETROS Controler;
    public int contador;
    public Text Pregunta1;
    public Text Pregunta2;
    public Text Pregunta3;
    public Text Pregunta;
    public Image imagen;

	// Use this for initialization
	void Start () {
        Changer(0);
	}
	
	// Update is called once per frame
	void Update () {
        if (contador == Datos.Length)
        {
            Controler.Verificar_Final();
        }
	}

    public void Restore()
    {
        contador = 0;
        Changer(0);
        Controler.Restore();
    }

    public void Verifi(int s)
    {
        if (s == Datos[contador].Correctos)
        {
            Controler.Verficar(s, Datos[contador].Correctos);
            Controler.Aumentar();
            contador++;
            Changer(contador);
        }
        else
        {
            Controler.Verficar(s, 10000);
            Controler.Disminuir();
            contador++;
            Changer(contador);
        }
    }

    public void Changer(int s)
    {
        Bt.transform.SetSiblingIndex(Random.Range(0, 2));
        Pregunta.text = Datos[s].Pregunta;
        Pregunta1.text = Datos[s].Texto1;
        Pregunta2.text = Datos[s].Texto2;
        Pregunta3.text = Datos[s].Texto3;
        imagen.sprite = Datos[s].imagen;
    }
}
