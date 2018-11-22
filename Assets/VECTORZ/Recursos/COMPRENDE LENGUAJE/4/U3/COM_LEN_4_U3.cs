using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class COM_LEN_4_U3 : MonoBehaviour {
    public RETROS Controlador;
    public GameObject[] Actididad1, Actididad2, Actididad3,Escenas,botones1,botones2,Mascara;
    public bool[] Array1, Array2,Correctos1,Correctos2;
    public Color Blanco, Transparente;

    public void Activiti1(int S)
    {
        for (int i = 0; i < Actididad1.Length; i++)
        {
            Actididad1[i].GetComponent<Image>().color = Transparente;
        }
        Actididad1[S].GetComponent<Image>().color = Blanco;
    }

    public void Activiti2(int S)
    {
        for (int i = 0; i < Actididad2.Length; i++)
        {
            Actididad2[i].gameObject.SetActive(false);
        }
        Actididad2[S].gameObject.SetActive(true);
    }

    public void Activiti3(int S)
    {
        for (int i = 0; i < Actididad3.Length; i++)
        {
            Actididad3[i].gameObject.SetActive(false);
        }
        Actididad3[S].gameObject.SetActive(true);
    }

    public void Validar1()
    {
        for (int i = 0; i < Array1.Length; i++)
        {
            if (Array1[i])
            {
                if (Array1[i] == Correctos1[i])
                {
                    Controlador.Aumentar();
                }
                else
                {
                    Controlador.Disminuir();
                }
            }
        }
        Controlador.Informacion_mostrar(2);
        Mascara[0].SetActive(true);
        StartCoroutine(Cambiar(2));
    }

    public void Validar2()
    {
        for (int i = 0; i < Array2.Length; i++)
        {
            if (Array2[i])
            {
                if (Array2[i] == Correctos2[i])
                {
                    Controlador.Aumentar();
                }
                else
                {
                    Controlador.Disminuir();
                }
            }
        }
        Mascara[1].SetActive(true);
        StartCoroutine(Final());
    }

    public IEnumerator Final()
    {
        yield return new WaitForSeconds(1);
        Controlador.Verficar(Controlador.Correctos, 5);
        StartCoroutine(Controlador.FINAL());
    }

    public void Seleccion1(int s)
    {
        if (Array1[s])
        {
            Array1[s] = false;
            botones1[s].transform.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            Array1[s] = true;
            botones1[s].transform.GetChild(0).gameObject.SetActive(true);
        }  
    }

    public void Seleccion2(int s)
    {
        if (Array2[s])
        {
            Array2[s] = false;
            botones2[s].transform.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            Array2[s] = true;
            botones2[s].transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    public IEnumerator Cambiar(int s)
    {
        yield return new WaitForSeconds(1);
        for (int i = 0; i < Escenas.Length; i++)
        {
            Escenas[i].SetActive(false);
        }
        Escenas[s].SetActive(true);
    }

    public void Restore()
    {
        for (int i = 0; i < Escenas.Length; i++)
        {
            Escenas[i].SetActive(false);
        }
        for (int i = 0; i < Array1.Length; i++)
        {
            Array1[i]=false;
            botones1[i].transform.GetChild(0).gameObject.SetActive(false);
        }
        for (int i = 0; i < Array2.Length; i++)
        {
            Array2[i] = false;
            botones2[i].transform.GetChild(0).gameObject.SetActive(false);
        }
        for (int i = 0; i < Actididad2.Length; i++)
        {
            Actididad2[i].gameObject.SetActive(false);
        }
        Actididad2[0].gameObject.SetActive(true);
        for (int i = 0; i < Actididad3.Length; i++)
        {
            Actididad3[i].gameObject.SetActive(false);
        }
        Actididad3[0].gameObject.SetActive(true);
        for (int i = 0; i < Actididad1.Length; i++)
        {
            Actididad1[i].GetComponent<Image>().color = Transparente;
        }
        Mascara[0].SetActive(false);
        Mascara[1].SetActive(false);
    }
}
