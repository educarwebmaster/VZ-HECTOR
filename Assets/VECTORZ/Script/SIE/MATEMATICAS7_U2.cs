using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class MATEMATICA_U7_DATOS
{
    public string Titulo;
    public string[] Textos = new string[3];
    public int correctos;
}

public class MATEMATICAS7_U2 : MonoBehaviour {
    public MATEMATICA_U7_DATOS[] Datos;
    public Image[] Objetivos;
    public Text[] Objetivos_textos;
    public GameObject[] Imagenes1;
    public GameObject[] Imagenes2;
    public GameObject RetroBuena;
    public GameObject RetroMala;
    public GameObject RetroFinal;
    public GameObject BotonBack;
    public GameObject BotonNext;
    public Color Hover;
    public Color Normal;
    public Image Boton_Animal;
    public Image Boton_Vegetal;
    public Text Buenos;
    public Text Malos;
    public Text Titulo; 
    public Sprite Imag_Buena;
    public Sprite Imag_Mala;
    public int Correctos;
    public int Incorrectos;
    public int Celula_1_int;
    public int Celula_2_int;
    public int celAct;
    public int Estado;

    // Use this for initialization
    void Start () {
        for (int i = 0; i < Objetivos.Length; i++)
        {
            Objetivos[i].sprite = Imag_Buena;
        }
        Objetivos_textos[0].text = Datos[Estado].Textos[0];
        Objetivos_textos[1].text = Datos[Estado].Textos[1];
        Objetivos_textos[2].text = Datos[Estado].Textos[2];
        Titulo.text = Datos[Estado].Titulo;
    }
	
	// Update is called once per frame
	void Update () {
        Buenos.text = "" + Correctos;
        Malos.text = "" + Incorrectos;
        if (celAct == 0)
        {
            Boton_Animal.color = Hover;
            Boton_Vegetal.color = Normal;

            if(Celula_1_int == 0)
            {
                BotonBack.SetActive(false);
            }
            else
            {
                BotonBack.SetActive(true);
            }

            if (Celula_1_int == Imagenes1.Length - 1)
            {
                BotonNext.SetActive(false);
            }
            else
            {
                BotonNext.SetActive(true);
            }
        }
        else
        {
            Boton_Animal.color = Normal;
            Boton_Vegetal.color = Hover;
            if (Celula_2_int == 0)
            {
                BotonBack.SetActive(false);
            }
            else
            {
                BotonBack.SetActive(true);
            }
            if (Celula_2_int == Imagenes2.Length - 1)
            {
                BotonNext.SetActive(false);
            }
            else
            {
                BotonNext.SetActive(true);
            }
        }
	}

    public void Restore()
    {
        Estado = 0;
        Correctos = 0;
        Incorrectos = 0;
        Celula_1_int = 0;
        Celula_2_int = 0;
        RetroBuena.SetActive(false);
        RetroMala.SetActive(false);
        RetroFinal.SetActive(false);
        for (int i = 0; i < Objetivos.Length; i++)
        {
            Objetivos[i].sprite = Imag_Buena;
        }
        Objetivos_textos[0].text = Datos[Estado].Textos[0];
        Objetivos_textos[1].text = Datos[Estado].Textos[1];
        Objetivos_textos[2].text = Datos[Estado].Textos[2];
        Titulo.text = Datos[Estado].Titulo;
    }

    public void PopUp(int i){
        celAct = i;
        if (i == 0)
        {
            Celula_1_int = 0;
        }
        else
        {
            Celula_2_int = 0;
        }
    }

    public void Cambiar(Image img)
    {
        img.sprite = Imag_Mala;
    }

    public void Info(GameObject g)
    {
        StartCoroutine("Info_c",g);
    }

    public IEnumerator Info_c(GameObject g)
    {
        g.SetActive(true);
        yield return new WaitForSeconds(5);
        g.SetActive(false);
    }

    public void Verficar(int elemento)
    {
        if (elemento == Datos[Estado].correctos)
        {
            Correctos++;
            StartCoroutine("Actializar");
            RetroBuena.SetActive(true);
            RetroMala.SetActive(false);
        }
        else
        {
            Incorrectos++;
            StartCoroutine("Actializar");
            RetroBuena.SetActive(false);
            RetroMala.SetActive(true);
        }
    }

    public IEnumerator Actializar()
    {
        yield return new WaitForSeconds(3);
        RetroBuena.SetActive(false);
        RetroMala.SetActive(false);
        if (Estado == 9)
        {
            RetroFinal.SetActive(true);
        }
        if (Estado < 9)
        {
            Estado++;
            for (int i = 0; i < Objetivos.Length; i++)
            {
                Objetivos[i].sprite = Imag_Buena;
            }
            Objetivos_textos[0].text = Datos[Estado].Textos[0];
            Objetivos_textos[1].text = Datos[Estado].Textos[1];
            Objetivos_textos[2].text = Datos[Estado].Textos[2];
            Titulo.text = Datos[Estado].Titulo;
        }
        
    }

    public void Siguiente()
    {
        if (celAct == 0)
        {
            if (Celula_1_int < Imagenes1.Length - 1)
            {
                for (int i = 0; i < Imagenes1.Length; i++)
                {
                    Imagenes1[i].SetActive(false);
                }
                Celula_1_int += 1;
                Imagenes1[Celula_1_int].SetActive(true);
            }
        }
        else
        {
            if (Celula_2_int < Imagenes2.Length - 1)
            {
                for (int i = 0; i < Imagenes2.Length; i++)
                {
                    Imagenes2[i].SetActive(false);
                }
                Celula_2_int += 1;
                Imagenes2[Celula_2_int].SetActive(true);
            }
        }
    }

    public void Anterior()
    {
        if (celAct == 0)
        {
            if (Celula_1_int > 0)
            {
                for (int i = 0; i < Imagenes1.Length; i++)
                {
                    Imagenes1[i].SetActive(false);
                }
                Celula_1_int -= 1;
                Imagenes1[Celula_1_int].SetActive(true);
            }
        }
        else
        {
            if (Celula_2_int > 0)
            {
                for (int i = 0; i < Imagenes2.Length; i++)
                {
                    Imagenes2[i].SetActive(false);
                }
                Celula_2_int -= 1;
                Imagenes2[Celula_2_int].SetActive(true);
            }
        }
    }

}
