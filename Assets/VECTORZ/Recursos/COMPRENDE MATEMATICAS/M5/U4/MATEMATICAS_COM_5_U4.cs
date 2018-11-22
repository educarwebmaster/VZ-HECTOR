using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class MATEMATICAS_COM_5_U4_system
{
    public Sprite Info;
    public Sprite[] SpritesN, SpritesH;
    public int correcto;
}

public class MATEMATICAS_COM_5_U4 : MonoBehaviour {

    public RETROS Controlador;
    public MATEMATICAS_COM_5_U4_system[] system;
    public Image[] Imagenes;
    public Image Info;
    public int Slider,selec;
    public GameObject Mascara;

    public void verificar(int index)
    {
        selec = index;
    }

    public void Randomize()
    {
        for(int i = 0; i < Imagenes.Length; i++)
        {
            Imagenes[i].transform.SetSiblingIndex(Random.Range(0,3));
        }
    }

    public void termine()
    {
        if (selec == system[Slider].correcto)
        {
            Controlador.Aumentar();
        }
        else
        {
            Controlador.Disminuir();
        }
        Imagenes[selec].sprite = system[Slider].SpritesH[selec];
        Mascara.SetActive(true);
        StartCoroutine(Cambiar());
    }

    public IEnumerator Cambiar()
    {
        yield return new WaitForSeconds(2);
        if (Slider==4)
        {
            Controlador.Verficar(Controlador.Correctos,3);
            StartCoroutine(Controlador.FINAL());
        }
        else
        {
            Slider++;
            Asignar();
        }
    }

    public void Asignar()
    {
        for (int i = 0;i<Imagenes.Length;i++)
        {
            Imagenes[i].sprite = system[Slider].SpritesN[i];
        }
        Info.sprite = system[Slider].Info;
        Mascara.SetActive(false);
    }

    public void Restore()
    {
        selec = 0;
        Slider = 0;
        Asignar();
    }
    
}
