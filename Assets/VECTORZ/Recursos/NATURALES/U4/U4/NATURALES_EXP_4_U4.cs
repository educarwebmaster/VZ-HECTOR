using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*

 */
public class NATURALES_EXP_4_U4 : MonoBehaviour {
    public RETROS Controlador;
    public DPRBASE[] Drops1, Drops2;
    public GameObject conten1, conten2,INFO2;
    public GameObject[] Escenas,botones1,botones2,terminar;
    public int cor1, cor2,s1,s2;
    public Color Normal, Select;

    public void Randomize()
    {
        for (int i = 0;i<conten1.transform.childCount;i++)
        {
            int R = Random.Range(0,3); 
            conten1.transform.GetChild(i).transform.SetSiblingIndex(R);
        }
        for (int i = 0; i < conten2.transform.childCount; i++)
        {
            int R = Random.Range(0, 3);
            conten2.transform.GetChild(i).transform.SetSiblingIndex(R);
        }
    }

    public void Termine1(int p)
    {
        s1 = p;
        for (int i = 0; i < botones1.Length; i++)
        {
            botones1[i].GetComponent<Image>().color = Normal;
        }
        botones1[p].GetComponent<Image>().color = Select;
    }

    public void Validar1()
    {
        if (s1 == cor1)
        {
            Controlador.Aumentar();

        }
        else
        {
            Controlador.Disminuir();
        }
        botones1[s1].transform.GetChild(0).gameObject.SetActive(true);
        StartCoroutine(Cambiar(1, 2));
    }

    public void Termine2(int p)
    {
        s2 = p;
        for (int i = 0; i < botones1.Length; i++)
        {
            botones2[i].GetComponent<Image>().color = Normal;
        }
        botones2[p].GetComponent<Image>().color = Select;
    }

    public void Validar2()
    {
        if (s2 == cor2)
        {
            Controlador.Aumentar();

        }
        else
        {
            Controlador.Disminuir();
        }
        botones2[s2].transform.GetChild(0).gameObject.SetActive(true);
        StartCoroutine(Cambiar(2, 2));
        Controlador.Info(INFO2);
    }

    public void Termine3()
    {
        for (int i = 0; i < Drops1.Length;i++)
        {
            if (Drops1[i].transform.childCount > 0)
            {
                DRRBASE D = Drops1[i].transform.GetChild(0).gameObject.GetComponent<DRRBASE>();
                if (D.ID == Drops1[i].ID)
                {
                    Controlador.Aumentar();
                    D.transform.GetChild(0).gameObject.SetActive(true);
                }
                else
                {
                    Controlador.Disminuir();
                    D.transform.GetChild(1).gameObject.SetActive(true);
                }
            }
        }
        StartCoroutine(Cambiar(3,2));
    }

    public void Termine4()
    {
        for (int i = 0; i < Drops2.Length; i++)
        {
            if (Drops2[i].transform.childCount > 0)
            {
                DRRBASE D = Drops2[i].transform.GetChild(0).gameObject.GetComponent<DRRBASE>();
                if (D.ID == Drops2[i].ID)
                {
                    Controlador.Aumentar();
                    D.transform.GetChild(0).gameObject.SetActive(true);
                }
                else
                {
                    Controlador.Disminuir();
                    D.transform.GetChild(1).gameObject.SetActive(true);
                }
            }
        }
        StartCoroutine(Finalizar());
    }

    public IEnumerator Finalizar()
    {
        yield return new WaitForSeconds(2);
        Controlador.Verficar(Controlador.Correctos, 3);
        StartCoroutine(Controlador.FINAL());
    }

    public IEnumerator Cambiar(int escena, int tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        
        for (int i = 0; i < Escenas.Length; i++)
        {
            Escenas[i].SetActive(false);
        }
        Escenas[escena].SetActive(true);
    }

    public void Restore()
    {
        for (int i = 0; i < Drops1.Length; i++)
        {
            if (Drops1[i].transform.childCount > 0)
            {
                Drops1[i].Ocupado = false;
                DRRBASE D = Drops1[i].transform.GetChild(0).gameObject.GetComponent<DRRBASE>();
                D.enabled = true;
                D.transform.GetChild(0).gameObject.SetActive(false);
                D.transform.GetChild(1).gameObject.SetActive(false);
                D.Restore();
            }
        }
        for (int i = 0; i < Drops2.Length; i++)
        {
            if (Drops2[i].transform.childCount > 0)
            {
                Drops2[i].Ocupado = false;
                DRRBASE D = Drops2[i].transform.GetChild(0).gameObject.GetComponent<DRRBASE>();
                D.enabled = true;
                D.transform.GetChild(0).gameObject.SetActive(false);
                D.transform.GetChild(1).gameObject.SetActive(false);
                D.Restore();
            }
        }
        for (int i = 0; i < botones1.Length; i++)
        {
            botones1[i].GetComponent<Image>().color = Normal;
            botones1[i].transform.GetChild(0).gameObject.SetActive(false);
        }
        for (int i = 0; i < botones2.Length; i++)
        {
            botones2[i].GetComponent<Image>().color = Normal;
            botones2[i].transform.GetChild(0).gameObject.SetActive(false);
        }
        for (int i = 0; i < Escenas.Length; i++)
        {
            Escenas[i].SetActive(false);
        }
        for (int i = 0; i < terminar.Length; i++)
        {
            terminar[i].GetComponent<Button>().enabled = true;
        }
        Controlador.Restore();
        s1 = 0;s2 = 0;
    }


}
