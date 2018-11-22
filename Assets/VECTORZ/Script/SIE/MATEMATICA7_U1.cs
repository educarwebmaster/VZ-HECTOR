using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MATEMATICA7_U1 : MonoBehaviour {

    public int Correctos;
    public int Incorrectos;
    public GameObject[] Drags;
    public GameObject[] Drops;
    public GameObject RetroMala;
    public GameObject RetroBuena;
    public GameObject RetroAlimentacion;
    public Text Buenos;
    public Text Malos;
    public int C_correctos;
    public bool Boton;
    public bool Comodin;
    public int contador;
    // Use this for initialization
    void Start () {
        Comodin = true;
	}
	
	// Update is called once per frame
	void Update () {
        Buenos.text = "" + Correctos;
        Malos.text = "" + Incorrectos;
        if (Boton)
        {

        }
        else
        {
            if (contador >= Drags.Length)
            {
                if (Comodin)
                {
                    Comodin = false;
                    Validar();
                }
            }
        }
    }

    public void Restore()
    {
        Correctos = 0;
        Incorrectos = 0;
        Comodin = true;
        contador = 0;
        RetroBuena.SetActive(false);
        RetroMala.SetActive(false);
        RetroAlimentacion.SetActive(false);
        for (int i = 0; i < Drops.Length; i++)
        {
            Drops[i].GetComponent<DRR2>().enabled = true;
            Drops[i].GetComponent<DRR2>().Restore();
        }

        for (int i = 0; i < Drags.Length; i++)
        {
            Drags[i].GetComponent<DPR2>().Ocupado = false;
        }
    }

    public void Validar()
    {
        for (int i = 0;i < Drags.Length;i++)
        {
            Drags[i].GetComponent<DPR2>().Verifi();
        }

        if (Correctos > C_correctos)
        {
            RetroBuena.SetActive(true);
            RetroMala.SetActive(false);
            StartCoroutine("RetroDefiniti");     
        }
        else
        {
            RetroBuena.SetActive(false);
            RetroMala.SetActive(true);
            StartCoroutine("RetroDefiniti");
        }
    }

    public IEnumerator RetroDefiniti()
    {
        yield return new WaitForSeconds(3);
        
        RetroBuena.SetActive(false);
        RetroMala.SetActive(false);
        RetroAlimentacion.SetActive(true);
    }

    public void Info(GameObject g)
    {
        StartCoroutine("Info_c", g);
    }

    public IEnumerator Info_c(GameObject g)
    {
        g.SetActive(true);
        yield return new WaitForSeconds(5);
        g.SetActive(false);
    }
}
