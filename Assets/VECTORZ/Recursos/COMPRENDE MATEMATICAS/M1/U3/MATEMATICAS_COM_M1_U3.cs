using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MATEMATICAS_COM_M1_U3 : MonoBehaviour {
    public RETROS Controler;
    public Monedas Moneda;
    public DPRBASE[] Drops;
    public AudioSource audioControler;
    public AudioClip audioB,audioM;
    public bool[] Sistema;
    public int cont;

    public void StartMonedas()
    {
        Moneda.CrearMonedas(6);
    }

    void Update()
    {
        for (int i = 0;i< Drops.Length;i++)
        {
            if (Drops[i].transform.childCount>0)
            {
                DRRBASE D = Drops[i].transform.GetChild(0).gameObject.GetComponent<DRRBASE>();
                if (!Sistema[i])
                {
                    Sistema[i] = true;
                    if (Drops[i].ID == D.ID)
                    {
                        audioControler.PlayOneShot(audioB);
                        Moneda.ParticulasCrear(i);
                        Controler.Aumentar();
                        cont++;
                    }
                    else
                    {
                        audioControler.PlayOneShot(audioM);
                        Controler.Disminuir();
                        cont++;
                    }
                }
            }
        }
        if (cont==6)
        {
            cont = 0;
            StartCoroutine(Verificar());
        }

    }

    public IEnumerator Verificar()
    {
        yield return new WaitForSeconds(2);
        Controler.Verficar2(Controler.Correctos,4);
    }

    public void Restore()
    {
        for (int i = 0; i < Drops.Length; i++)
        {
            if (Drops[i].transform.childCount>0)
            {
                DRRBASE D = Drops[i].transform.GetChild(0).gameObject.GetComponent<DRRBASE>();
                D.enabled = true;
                D.Restore();
                Drops[i].Ocupado = false;
            }
        }
        for (int i = 0; i < Sistema.Length; i++)
        {
            Sistema[i] = false;
        }
        cont = 0;
        Moneda.DestruirMonedas();
    }
}
