using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class COM_MAT_4_U4 : MonoBehaviour {
    public RETROS Controlador;
    public GameObject[] Slider, Escenas, botones,preguntas;
    public GameObject Mascara;
    public Sprite[] botonesN, botonesS;
    public Sprite checN, checR, checV;
    public int Slider_pos;
    public bool[] correctos;
    public Toggle[] respuestas;

    public void Slider_cambiar(int s)
    {
        for (int i = 0; i < botones.Length; i++)
        {
            botones[i].GetComponent<Image>().sprite = botonesN[i];
            Slider[i].SetActive(false);
        }
        botones[s].GetComponent<Image>().sprite = botonesS[s];
        Slider[s].SetActive(true);
    }

    public void randomize()
    {
        for (int i = 0; i < preguntas.Length; i++)
        {
            preguntas[i].transform.SetSiblingIndex(Random.Range(0,3));
        }
    }

    public void Restore()
    {
        Slider_pos = 0;
        for (int i = 0; i < botones.Length; i++)
        {
            botones[i].GetComponent<Image>().sprite = botonesN[i];
            Slider[i].SetActive(false);
        }
        botones[0].GetComponent<Image>().sprite = botonesS[0];
        Slider[0].SetActive(true);
        for (int i = 0; i < respuestas.Length; i++)
        {
            respuestas[i].isOn = false;
            respuestas[i].transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = checN;
        }
        for (int i = 0; i < Escenas.Length; i++)
        {
            Escenas[i].SetActive(false);
        }
        Mascara.SetActive(false);
    }

    public void Termine()
    {
        Mascara.SetActive(true);
        for (int i = 0; i < respuestas.Length; i++)
        {
            if (respuestas[i].isOn == correctos[i])
            {
                Controlador.Aumentar();
                if (respuestas[i].isOn)
                {
                    respuestas[i].transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = checV;
                }
            }
            else
            {
                Controlador.Disminuir();
                if (respuestas[i].isOn)
                {
                    respuestas[i].transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = checR;
                }
            }
        }
        StartCoroutine(Final());
    }

    public IEnumerator Final()
    {
        yield return new WaitForSeconds(2);
        Controlador.Verficar((Controlador.Correctos/2), 3);

        StartCoroutine(Controlador.FINAL());
    }


}
