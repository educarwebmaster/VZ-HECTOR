using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MATEMATICAS_EXP_M0_U2 : MonoBehaviour {
    public RETROS Controler;
    public DPRBASE[] Drops, Drops2;
    public GameObject[] Mascara,S,u,d;

    public void Termine()
    {
        for (int i = 0; i < Drops.Length; i++)
        {
            if (Drops[i].transform.childCount > 0)
            {
                DRRBASE d = Drops[i].transform.GetChild(0).gameObject.GetComponent<DRRBASE>();
                if (d.ID == Drops[i].ID)
                {
                    Controler.Aumentar();
                    d.transform.GetChild(0).gameObject.SetActive(true);
                }
                else
                {
                    Controler.Disminuir();
                    d.transform.GetChild(1).gameObject.SetActive(true);
                }
            }
        }
        Mascara[0].SetActive(true);
        StartCoroutine(Cambiar(1,2));
    }

    public void Randomize()
    {
        
        for (int i = 0; i < u.Length; i++)
        {
            int re = Random.Range(0, 3);
            u[i].transform.SetSiblingIndex(re);
           
        }
        for (int i = 0; i < d.Length; i++)
        {
            int re = Random.Range(0, 3);
            d[i].transform.SetSiblingIndex(re);
        }
    }

    public void Termine2()
    {
        for (int i = 0; i < Drops2.Length; i++)
        {
            if (Drops2[i].transform.childCount > 0)
            {
                DRRBASE d = Drops2[i].transform.GetChild(0).gameObject.GetComponent<DRRBASE>();
                if (d.ID == Drops2[i].ID)
                {
                    Controler.Aumentar();
                    d.transform.GetChild(0).gameObject.SetActive(true);
                }
                else
                {
                    Controler.Disminuir();
                    d.transform.GetChild(1).gameObject.SetActive(true);
                }
            }
        }
        Mascara[1].SetActive(true);
        StartCoroutine(Finalizar());
    }

    public IEnumerator Finalizar()
    {
        yield return new WaitForSeconds(2);
        Controler.Verficar(Controler.Correctos, 7);
        StartCoroutine(Controler.FINAL());
    }

    public IEnumerator Cambiar(int escena, int tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        for (int i = 0; i < S.Length; i++)
        {
            S[i].SetActive(false);
        }
        Controler.Informacion_mostrar(escena);
        S[escena].SetActive(true);
    }

    public void Restore()
    {
        Controler.Restore();
        Mascara[0].SetActive(false);
        Mascara[1].SetActive(false);
        S[0].SetActive(false);
        S[1].SetActive(false);
        for (int i = 0; i < Drops.Length; i++)
        {
            if (Drops[i].transform.childCount > 0)
            {
                DRRBASE d = Drops[i].transform.GetChild(0).gameObject.GetComponent<DRRBASE>();
                d.transform.GetChild(0).gameObject.SetActive(false);
                d.transform.GetChild(1).gameObject.SetActive(false);
                d.enabled = true;
                d.Restore();
                Drops[i].Ocupado = false;
            }
        }

        for (int i = 0; i < Drops2.Length; i++)
        {
            if (Drops2[i].transform.childCount > 0)
            {
                DRRBASE d = Drops2[i].transform.GetChild(0).gameObject.GetComponent<DRRBASE>();
                d.transform.GetChild(0).gameObject.SetActive(false);
                d.transform.GetChild(1).gameObject.SetActive(false);
                d.enabled = true;
                d.Restore();
                Drops2[i].Ocupado = false;
            }
        }
    }



}
