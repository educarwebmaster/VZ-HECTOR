using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MATEMATICA_COM_M2_U4 : MonoBehaviour {
    public RETROS Controler;
    public string[] Correctos;
    public InputField[] Textos;
    public int Slider;
    public GameObject Mascara;
    public GameObject[] Escenas;
    public GameObject[] RetroBuena, RetroMala;
    public DRRSIN[] Reglas;

    public void Revisar()
    {
        Mascara.SetActive(true);
        if (Textos[Slider].text == Correctos[Slider])
        {
            Controler.Aumentar();
            RetroBuena[Slider].SetActive(true);
        }
        else
        {
            Controler.Disminuir();
            RetroMala[Slider].SetActive(true);
        }
        if (Slider == 9)
        {
            StartCoroutine(Final());
        }
        else
        {
            Slider++;
            StartCoroutine(Cambiar(Slider,1));
        }
    }

    public IEnumerator Cambiar(int escena, int tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        for (int i = 0; i < Escenas.Length; i++)
        {
            Escenas[i].SetActive(false);
        }
        Escenas[escena].SetActive(true);
        Mascara.SetActive(false);
    }

    public IEnumerator Final()
    {
        yield return new WaitForSeconds(2);
        Mascara.SetActive(false);
        Controler.Verficar(Controler.Correctos,6);
        StartCoroutine(Controler.FINAL());
    }

    public void Restore()
    {
        for (int i = 0; i < Textos.Length;i++)
        {
            Textos[i].text = "";
        }
        for (int i = 0; i < Escenas.Length; i++)
        {
            Escenas[i].SetActive(false);
        }
        for (int i = 0; i < RetroBuena.Length; i++)
        {
            RetroBuena[i].SetActive(false);
        }
        for (int i = 0; i < RetroMala.Length; i++)
        {
            RetroMala[i].SetActive(false);
        }
        for (int i = 0; i < Reglas.Length; i++)
        {
            Reglas[i].Restore();
        }
        Mascara.SetActive(false);
        Slider = 0;
    } 

}
