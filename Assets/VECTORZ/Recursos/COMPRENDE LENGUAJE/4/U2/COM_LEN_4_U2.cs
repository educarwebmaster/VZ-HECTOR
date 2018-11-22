using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class COM_LEN_4_U2 : MonoBehaviour {

    public RETROS Desencamaronamelo;
    public GameObject[] Actididad1, Actididad3,Escenas;
    public Sprite[] Imagenenes;
    public Image imagen;
    public Color Blanco, Transparente;
    public int Slider;
    public DPRBASE[] Drops;

    public void Activiti1(int S)
    {
        for (int i = 0; i < Actididad1.Length;i++)
        {
            Actididad1[i].GetComponent<Image>().color = Transparente;
        }
        Actididad1[S].GetComponent<Image>().color = Blanco;
    }

    public void Activiti3(int S)
    {
        for (int i = 0; i < Actididad3.Length; i++)
        {
            Actididad3[i].GetComponent<Image>().color = Transparente;
        }
        Actididad3[S].GetComponent<Image>().color = Blanco;
    }

    public void Next_slider()
    {
        if (Slider<Imagenenes.Length-1)
        {
            Slider++;
            imagen.sprite = Imagenenes[Slider];
        }
        else
        {
            Cambiar(2);
            Desencamaronamelo.Informacion_mostrar(2);
        }
    }

    public void After_slider()
    {
        if (Slider>0)
        {
            Slider--;
            imagen.sprite = Imagenenes[Slider];
        }
        else
        {
            Cambiar(0);
        }
    }

    public void Cambiar(int s)
    {
        for (int i = 0; i < Escenas.Length; i++)
        {
            Escenas[i].SetActive(false);
        }
        Escenas[s].SetActive(true);
        Slider = 0;
    }

    public void Termine()
    {
        for (int i = 0; i < Drops.Length; i++)
        {
            if (Drops[i].transform.childCount > 0)
            {
                DRRBASE C = Drops[i].transform.GetChild(0).gameObject.GetComponent<DRRBASE>();
                if (C.ID == Drops[i].ID)
                {
                    Desencamaronamelo.Aumentar();
                    C.transform.GetChild(0).gameObject.SetActive(true);

                }
                else
                {
                    Desencamaronamelo.Disminuir();
                    C.transform.GetChild(1).gameObject.SetActive(true);
                }
            }
        }
        StartCoroutine(Final());
    }

    public IEnumerator Final()
    {
        yield return new WaitForSeconds(1);
        Desencamaronamelo.Verficar(Desencamaronamelo.Correctos, 2);
        StartCoroutine(Desencamaronamelo.FINAL());
    }

    public void Restore()
    {
        for (int i = 0; i < Escenas.Length; i++)
        {
            Escenas[i].SetActive(false);
        }
        Slider = 0;
        for (int i = 0; i < Drops.Length; i++)
        {
            if (Drops[i].transform.childCount > 0)
            {
                Drops[i].Ocupado = false;
                DRRBASE D = Drops[i].transform.GetChild(0).gameObject.GetComponent<DRRBASE>();
                D.enabled = true;
                D.transform.GetChild(0).gameObject.SetActive(false);
                D.transform.GetChild(1).gameObject.SetActive(false);
                D.Restore();
            }
        }
        for (int i = 0; i < Actididad1.Length; i++)
        {
            Actididad1[i].GetComponent<Image>().color = Transparente;
        }
        
        for (int i = 0; i < Actididad3.Length; i++)
        {
            Actididad3[i].GetComponent<Image>().color = Transparente;
        }
       
    }
}
