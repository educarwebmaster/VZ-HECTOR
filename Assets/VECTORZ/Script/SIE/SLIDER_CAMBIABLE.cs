using UnityEngine;
using System.Collections;

public class SLIDER_CAMBIABLE : MonoBehaviour {

    public int SLIDE;
    public GameObject BotonBack;
    public GameObject BotonNext;
    public GameObject[] Imagenes;

	void Update () {
        if (SLIDE == 0)
        {
            BotonBack.SetActive(false);
        }
        else
        {
            BotonBack.SetActive(true);
        }

        if (SLIDE == Imagenes.Length - 1)
        {
            BotonNext.SetActive(false);
        }
        else
        {
            BotonNext.SetActive(true);
        }
    }

    public void Pagina(int S)
    {
        SLIDE = S;
        for (int i = 0; i < Imagenes.Length; i++)
        {
            Imagenes[i].SetActive(false);
        }
        Imagenes[S].SetActive(true);
    }

    public void Siguiente()
    {
            if (SLIDE < Imagenes.Length - 1)
            {
                for (int i = 0; i < Imagenes.Length; i++)
                {
                    Imagenes[i].SetActive(false);
                }
                SLIDE += 1;
                Imagenes[SLIDE].SetActive(true);
            }
    }

    public void Anterior()
    {
        if (SLIDE > 0){
                for (int i = 0; i < Imagenes.Length; i++)
                {
                    Imagenes[i].SetActive(false);
                }
                SLIDE -= 1;
                Imagenes[SLIDE].SetActive(true);
        }  
    }
}
