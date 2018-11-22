using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class COM_LEN_5_U2 : MonoBehaviour {

    public RETROS Controlador;
    public GameObject[] Actididad,Escenas;
    public DPRBASE[] Drops1;
    public DropMultiple[] Drops2;
    public Image[] Imagenes;
    public Sprite[] Normal, Sobre;

    public void Activiti(int S)
    {
        for (int i = 0; i < Imagenes.Length; i++)
        {
            Imagenes[i].sprite = Normal[i];
        }
        Imagenes[S].sprite = Sobre[S];
        for (int i = 0; i < Actididad.Length; i++)
        {
            Actididad[i].SetActive(false);
        }
        Actididad[S].SetActive(true);
    }

    public void terminar()
    {
        for (int i = 0; i < Drops1.Length; i++)
        {
            if (Drops1[i].transform.childCount > 0)
            {
                DRRBASE C = Drops1[i].transform.GetChild(0).gameObject.GetComponent<DRRBASE>();
                if (C.ID == Drops1[i].ID)
                {
                    Controlador.Aumentar();
                    C.transform.GetChild(0).gameObject.SetActive(true);

                }
                else
                {
                    Controlador.Disminuir();
                    C.transform.GetChild(1).gameObject.SetActive(true);
                }
            }
        }
        StartCoroutine(Cambiar(2, 2));
    }

    public void terminar2()
    {
        for (int i = 0; i < Drops2.Length; i++)
        {
            if (Drops2[i].transform.childCount > 0)
            {
                for (int e = 0; e < Drops2[i].transform.childCount; e++)
                {
                    DragMultiple C = Drops2[i].transform.GetChild(e).gameObject.GetComponent<DragMultiple>();
                    if (C.ID == Drops2[i].ID)
                    {
                        Controlador.Aumentar();
                        C.transform.GetChild(0).gameObject.SetActive(true);
                    }
                    else
                    {
                        Controlador.Disminuir();
                        C.transform.GetChild(1).gameObject.SetActive(true);
                    }
                }
            }
        }
        StartCoroutine(Final());
    }

    public IEnumerator Final()
    {
        yield return new WaitForSeconds(2);
        Controlador.Verficar(Controlador.Correctos, 5);
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
        Controlador.Informacion_mostrar(escena);
    }

    public void Restore()
    {
        Controlador.Restore();
        for (int i = 0; i < Escenas.Length; i++)
        {
            Escenas[i].SetActive(false);
        }
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
            int cantidad = 0;
            cantidad = Drops2[i].transform.childCount;
            if (Drops2[i].transform.childCount > 0)
            { 
                for (int e = 0; e < cantidad; e++)
                {
                    Drops2[i].Ocupado = false;
                    DragMultiple D = Drops2[i].transform.GetChild(0).gameObject.GetComponent<DragMultiple>();
                    D.enabled = true;
                    D.transform.GetChild(0).gameObject.SetActive(false);
                    D.transform.GetChild(1).gameObject.SetActive(false);
                    D.Restore();
                }
            }
        }

        for (int i = 0; i < Imagenes.Length; i++)
        {
            Imagenes[i].sprite = Normal[i];
        }
        Imagenes[0].sprite = Sobre[0];
    }
}
