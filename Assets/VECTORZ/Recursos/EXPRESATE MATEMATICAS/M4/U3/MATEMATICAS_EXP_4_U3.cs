using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MATEMATICAS_EXP_4_U3 : MonoBehaviour {
    public RETROS Controler;
    public DPRBASE[] Drops;
    public Sprite[] Normales, Seleccionadas;
    public Color Normal, Verde, Rojo;
    public GameObject Mascara;

    public void Termine()
    {
        for (int i = 0;i<Drops.Length;i++)
        {
            if (Drops[i].transform.childCount > 0)
            {
                DRRBASE d = Drops[i].transform.GetChild(0).gameObject.GetComponent<DRRBASE>();
                if (d.ID == Drops[i].ID)
                {
                    Controler.Aumentar();
                    d.gameObject.GetComponent<Image>().sprite = Seleccionadas[i];
                    d.gameObject.GetComponent<Image>().color = Verde;
                }
                else
                {
                    Controler.Disminuir();
                    d.gameObject.GetComponent<Image>().color = Rojo;
                }
            }
        }
        Mascara.SetActive(true);
        StartCoroutine(Finalizar());
    }

    public IEnumerator Finalizar()
    {
        yield return new WaitForSeconds(2);
        Controler.Verficar(Controler.Correctos, 7);
        StartCoroutine(Controler.FINAL());
    }

    public void Restore()
    {
        Controler.Restore();
        Mascara.SetActive(false );
        for (int i = 0; i < Drops.Length; i++)
        {
            if (Drops[i].transform.childCount > 0)
            {
                DRRBASE d = Drops[i].transform.GetChild(0).gameObject.GetComponent<DRRBASE>();
                //d.gameObject.GetComponent<Image>().sprite = Normales[i];
                d.gameObject.GetComponent<Image>().color = Normal;
                d.enabled = true;
                d.Restore();
                d.gameObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                Drops[i].Ocupado = false;
            }
        }
    }
}
