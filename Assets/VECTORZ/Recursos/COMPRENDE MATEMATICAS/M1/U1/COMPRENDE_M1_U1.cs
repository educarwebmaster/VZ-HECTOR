using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class COMPRENDE_M1_U1_sistem
{
    public Sprite[] botones;
    public int Correcto;
    public Sprite Info;
}

public class COMPRENDE_M1_U1 : MonoBehaviour {
    public RETROS Controlador;
    public COMPRENDE_M1_U1_sistem[] botones;
    public Image[] Boton;
    public Image Info;
    public int Slider;

    public void Randomize()
    {
        for (int i = 0; i < Boton.Length; i++)
        {
            Boton[i].transform.SetSiblingIndex(Random.Range(0,3));
        }
    }

    public void Verificar(int s)
    {
        if (s == botones[Slider].Correcto)
        {
            Controlador.Aumentar();
            Boton[s].transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            Controlador.Disminuir();
            Boton[s].transform.GetChild(1).gameObject.SetActive(true);
        }

        for (int i = 0; i < Boton.Length; i++)
        {
            Boton[i].raycastTarget = false;
        }
        Slider++;
        StartCoroutine(Cambiar());
    }

    public IEnumerator Cambiar()
    {
        yield return new WaitForSeconds(2);
        if (Slider == 4)
        {
            Controlador.Verficar(Controlador.Correctos, 3);
            StartCoroutine(Controlador.FINAL());
            
        }
        else
        {
            for (int i = 0; i < Boton.Length; i++)
            {
                Boton[i].raycastTarget = true;
                Boton[i].sprite = botones[Slider].botones[i];
                Boton[i].transform.GetChild(0).gameObject.SetActive(false);
                Boton[i].transform.GetChild(1).gameObject.SetActive(false);
            }
            Info.sprite = botones[Slider].Info;
            Controlador.Info(Info.transform.parent.gameObject);
        }
    }



    public void Restore()
    {
        Slider = 0;
        for (int i = 0; i < Boton.Length; i++)
        {
            Boton[i].raycastTarget = true;
            Boton[i].sprite = botones[0].botones[i];
            Boton[i].transform.GetChild(0).gameObject.SetActive(false);
            Boton[i].transform.GetChild(1).gameObject.SetActive(false);
        }
        Info.sprite = botones[0].Info;
    }


}
