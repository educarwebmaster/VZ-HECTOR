using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MATEMATICAS_EXP_M1_U1 : MonoBehaviour {

    public RETROS Controler;
    public InputField[] Inputs;
    public Toggle[] Radios;
    public string[] Correctos;
    public GameObject[] Mascaras,Escenas;

    public void Termine1()
    {
        if (Inputs[0].text == Correctos[0])
        {
            Controler.Aumentar();
            Inputs[0].transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            Controler.Disminuir();
            Inputs[0].transform.GetChild(1).gameObject.SetActive(true);
        }
        Mascaras[0].SetActive(true);
        StartCoroutine(Cambiar(1,1));
    }

    public void Termine2()
    {
        for (int i = 1;i < Inputs.Length;i++)
        {
            if (Inputs[i].text == Correctos[0])
            {
                Controler.Aumentar();
                Inputs[i].transform.GetChild(0).gameObject.SetActive(true);
            }
            else
            {
                Controler.Disminuir();
                Inputs[i].transform.GetChild(1).gameObject.SetActive(true);
            }
        }

        Mascaras[1].SetActive(true);
        StartCoroutine(Cambiar(2, 1));
    }

    public void Termine3()
    {
        for (int i = 0; i < Radios.Length; i++)
        {
            if (Radios[i].isOn)
            {
                if (i == 2)
                {
                    Controler.Aumentar();
                }
                else
                {
                    Controler.Disminuir();
                }
            }
            else
            {
            }
        }
        Mascaras[2].SetActive(true);
        StartCoroutine(Final());
    }

    public void Restore()
    {
        for (int i = 0; i < Inputs.Length; i++)
        {
            Inputs[i].text = "";
            Inputs[i].transform.GetChild(0).gameObject.SetActive(false);
            Inputs[i].transform.GetChild(1).gameObject.SetActive(false);
        }
        for (int i = 0; i < Radios.Length; i++)
        {
            Radios[i].isOn = false;
        }
        for (int i = 0; i < Mascaras.Length; i++)
        {
            Mascaras[i].SetActive(false);
        }
        for (int i = 0; i < Escenas.Length; i++)
        {
            Escenas[i].SetActive(false);
        }
    }

    public IEnumerator Final()
    {
        yield return new WaitForSeconds(1);
        Controler.Verficar(Controler.Correctos, 3);
        StartCoroutine(Controler.FINAL());
    }

    public IEnumerator Cambiar(int escena, int tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        for (int i = 0; i < Escenas.Length; i++)
        {
            Escenas[i].SetActive(false);
        }
        Escenas[escena].SetActive(true);
        Controler.Informacion_mostrar(escena);
    }

}
