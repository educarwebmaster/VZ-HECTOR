using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class COMPRENDE_LEN_1_U4 : MonoBehaviour {
    public RETROS Controlador;
    public Sprite[] Animales,Garabatos;
    public Image[] Botones1,Botones2,BotonesFinal;
    public Image Garabato,GarabatoMalo,botonteminar;
    public GameObject animal,c1,c2,colm1,colm2;
    public GameObject[] Escenas,Infos;
    public DPRBASE[] Drops;
    public Color colorNormal, colorSelect,colorTrans;
    public int seleccionado1, seleccionado2,cont,cont2,gara;
    public bool activado;
    public AudioSource audio;
    public AudioClip error, correc;


    public void Randomize()
    {
        for (int i = 0;i<colm1.transform.childCount;i++)
        {
            int c = Random.Range(0,3);
            colm1.transform.GetChild(i).transform.SetSiblingIndex(c);
        }
        for (int i = 0; i < colm2.transform.childCount; i++)
        {
            int c = Random.Range(0, 3);
            colm2.transform.GetChild(i).transform.SetSiblingIndex(c);
        }
    }
    
    public void Seleccionado1(int im)
    {
        cont++;
        Image img = Botones1[im];
        img.raycastTarget = false;
        img.color = colorSelect;
        seleccionado1 = im;
        c1.SetActive(true);
        if (activado)
        {
            if (im == seleccionado2)
            {
                Controlador.Aumentar();
                animal.SetActive(true);
                animal.GetComponent<Image>().sprite = Animales[im];
            }
            else
            {
                Controlador.Disminuir();
            }
            c1.SetActive(false);
            c2.SetActive(false);
            activado = false;
            seleccionado1 = 0;
            seleccionado2 = 0;
        }
        else
        {
            activado = true;
        }
        if (cont == 10)
        {
            StartCoroutine(Cambiar(1,2));
        }
    }

    public void Seleccionado2(int im)
    {
        cont++;
        Image img = Botones2[im];
        img.raycastTarget = false;
        img.color = colorSelect;
        seleccionado2 = im;
        c2.SetActive(true);
        if (activado)
        {
            if (im == seleccionado1)
            {
                Controlador.Aumentar();
                animal.SetActive(true);
                animal.GetComponent<Image>().sprite = Animales[im];
            }
            else
            {
                Controlador.Disminuir();
            }
            c1.SetActive(false);
            c2.SetActive(false);
            activado = false;
            seleccionado1 = 0;
            seleccionado2 = 0;
        }
        else
        {
            activado = true;
        }
        if (cont == 10)
        {
            StartCoroutine(Cambiar(1, 2));
        }
    }

    public IEnumerator Cambiar(int escena, int tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        for (int i = 0; i < Escenas.Length; i++)
        {
            Escenas[i].SetActive(false);
        }
        Escenas[escena].SetActive(true);
        Controlador.Info(Infos[escena]);
    }

    public  void terminar()
    {
        botonteminar.raycastTarget = false;
        botonteminar.gameObject.SetActive(false);
        for (int i = 0; i < Drops.Length; i++)
        {
            if (Drops[i].transform.childCount > 0)
            {
                DRRBASE C = Drops[i].transform.GetChild(0).gameObject.GetComponent<DRRBASE>();
                if (C.ID == Drops[i].ID)
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

    public void Final_bueno(int n)
    {
        audio.PlayOneShot(correc);
        Controlador.Aumentar();
        BotonesFinal[n].color = colorNormal;
        gara++;
        cont2++;
        
        Garabato.sprite = Garabatos[gara];
        if (cont2 >= 5)
        {
            GarabatoMalo.raycastTarget = false;
            Controlador.Verficar(Controlador.Correctos,10);
            StartCoroutine(Controlador.FINAL());
        }
    }

    public void Final_malo()
    {
        audio.PlayOneShot(error);
        Controlador.Disminuir();
        cont2++;
        
        if (cont2 >= 5)
        {
            GarabatoMalo.raycastTarget = false;
            Controlador.Verficar(Controlador.Correctos, 10);
            StartCoroutine(Controlador.FINAL());
        }
    }

    public void Restore()
    {
        Controlador.Restore();
        c1.SetActive(false);
        c2.SetActive(false);
        animal.SetActive(false);
        activado = false;
        seleccionado1 = 0;
        seleccionado2 = 0;
        cont = 0;
        cont2 = 0;
        gara = 0;
        Garabato.sprite = Garabatos[0];
        GarabatoMalo.raycastTarget = true;
        botonteminar.raycastTarget = true;
        botonteminar.gameObject.SetActive(true);
        for (int i = 0;i < Botones1.Length;i++)
        {
            Botones1[i].raycastTarget = true;
            Botones1[i].color = colorNormal;
        }
        for (int i = 0; i < Botones2.Length; i++)
        {
            Botones2[i].raycastTarget = true;
            Botones2[i].color = colorNormal;
        }
        for (int i = 0; i < BotonesFinal.Length; i++)
        {
            BotonesFinal[i].color = colorTrans;
        }
        for (int i = 0; i < Escenas.Length; i++)
        {
            Escenas[i].SetActive(false);
        }
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

    }


}






