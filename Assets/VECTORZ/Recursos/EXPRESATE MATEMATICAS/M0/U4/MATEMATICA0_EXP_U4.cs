using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MATEMATICA0_EXP_U4 : MonoBehaviour {
    public RETROS Controlador;
    public Image[] Botones;
    public Sprite[] Normal, Selecionado, Validado;
    public bool[] Estados, Correctos;
    public GameObject[] Scenas,Mascaras;

    public void Randomize()
    {
        for (int i = 0; i < Botones.Length; i++)
        {
            Botones[i].transform.SetSiblingIndex(Random.Range(0,2));
            Botones[i].sprite = Normal[i];
            if (Botones[i].transform.childCount>0)
            {
                Botones[i].transform.GetChild(0).gameObject.SetActive(false);
                Botones[i].transform.GetChild(1).gameObject.SetActive(false);
            }
        }
    }

    public void Capturar(int p)
    {
        if (Estados[p])
        {
            Estados[p] = false;
            Botones[p].sprite = Normal[p];
        }
        else
        {
            Estados[p] = true;
            Botones[p].sprite = Selecionado[p];
        }
    }

    public void Verificar1()
    {
        for (int i = 0; i < 6; i++)
        {
            if (Estados[i])
            {
                if (Estados[i]==Correctos[i])
                {
                    Controlador.Aumentar();
                    Botones[i].transform.GetChild(0).gameObject.SetActive(true);
                }
                else
                {
                    Controlador.Disminuir();
                    Botones[i].transform.GetChild(1).gameObject.SetActive(true);
                }
            }
        }
        Mascaras[0].SetActive(true);
        StartCoroutine(Cambiar(1,2));
    }

    public void Verificar2()
    {
        for (int i = 6; i < 9; i++)
        {
            if (Estados[i])
            {
                if (Estados[i] == Correctos[i])
                {
                    Controlador.Aumentar();
                }
                else
                {
                    Controlador.Disminuir();
                }
                Botones[i].sprite = Validado[i];
            }
        }
        Mascaras[1].SetActive(true);
        StartCoroutine(Cambiar(2, 2));
    }

    public void Verificar3()
    {
        for (int i = 9; i < 12; i++)
        {
            if (Estados[i])
            {
                if (Estados[i] == Correctos[i])
                {
                    Controlador.Aumentar();
                }
                else
                {
                    Controlador.Disminuir();
                }
                Botones[i].sprite = Validado[i];
            }
        }
        Mascaras[2].SetActive(true);
        StartCoroutine(Final());
    }

    public IEnumerator Final()
    {
        yield return new WaitForSeconds(1);
        Controlador.Verficar(Controlador.Correctos - Controlador.Incorrectos, 3);
        StartCoroutine(Controlador.FINAL());
    }

    public IEnumerator Cambiar(int escena, int tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        for (int i = 0; i < Scenas.Length; i++)
        {
            Scenas[i].SetActive(false);
        }
        Controlador.Informacion_mostrar(escena);
        
        Scenas[escena].SetActive(true);
    }

    public void Restore()
    {
        Controlador.Restore();
        for (int i = 0; i < Scenas.Length; i++)
        {
            Scenas[i].SetActive(false);
        }
        Randomize();
        for (int i = 0; i < Estados.Length; i++)
        {
            Estados[i]=false;
        }
        for (int i = 0; i < Mascaras.Length; i++)
        {
            Mascaras[i].SetActive(false);
        }
    }
}
