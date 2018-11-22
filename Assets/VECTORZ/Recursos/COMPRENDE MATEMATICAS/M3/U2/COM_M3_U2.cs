using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class COM_M3_U2 : MonoBehaviour {

    public RETROS Controlador;
    public Color[] Color;
    public Sprite[] Selecionado,Normal,Info1,Info2;
    public int Slider;
    public string[] NombreColores,correctos;
    public Image[] Electrodomesticos;
    public Image In1, In2,Cuadro;
    public InputField Texto;
    public DROPDOWNS down;
    public GameObject Mascara,Chulo,Mal;

    void Update()
    {
        for (int i = 0; i < NombreColores.Length; i++)
        {
            if (down.ItemSelect == NombreColores[i])
            {
                Electrodomesticos[Slider].transform.GetChild(0).gameObject.GetComponent<Image>().color = Color[i];
                Cuadro.color = Color[i];
                break;
            }
        }
    }

    public void CambiarColor()
    {
        if(Texto.text == correctos[Slider])
        {
            Electrodomesticos[Slider].transform.GetChild(0).gameObject.SetActive(true);
            Controlador.Aumentar();
            Chulo.SetActive(true);
        }
        else
        {
            Electrodomesticos[Slider].transform.GetChild(0).gameObject.SetActive(true);
            Controlador.Disminuir();
            Mal.SetActive(true);
        }
        Mascara.SetActive(true);
        if (Slider==4)
        {
            StartCoroutine(Final());
        }
        else
        {
            Slider++;
            StartCoroutine(Cambiar());
        }
        
    }

    public IEnumerator Final()
    {
        yield return new WaitForSeconds(2);
        Controlador.Verficar(Controlador.Correctos,3);
        StartCoroutine(Controlador.FINAL());
    }

    public IEnumerator Cambiar()
    {
        yield return new WaitForSeconds(2);
        down.ItemSelect = "Seleccionado";
        Cuadro.color = Color[6];
        Texto.text = "";
        Mascara.SetActive(false);
        Chulo.SetActive(false);
        Mal.SetActive(false);
        In1.sprite = Info1[Slider];
        In2.sprite = Info2[Slider];
        for (int i = 0; i < Electrodomesticos.Length; i++)
        {
            Electrodomesticos[i].sprite = Normal[i];
        }
        Electrodomesticos[Slider].sprite = Selecionado[Slider];
    }

    public void Restore()
    {
        down.ItemSelect = "Seleccionado";
        Cuadro.color = Color[6];
        Texto.text = "";
        Mascara.SetActive(false);
        Chulo.SetActive(false);
        Mal.SetActive(false);
        Slider = 0;
        In1.sprite = Info1[0];
        In2.sprite = Info2[0];
        Cuadro.color = Color[6];
        for (int i = 0; i < Electrodomesticos.Length; i++)
        {
            Electrodomesticos[i].transform.GetChild(0).gameObject.GetComponent<Image>().color = Color[6];
            Electrodomesticos[i].transform.GetChild(0).gameObject.SetActive(false);
            Electrodomesticos[i].sprite = Normal[i];
        }
        Electrodomesticos[0].sprite = Normal[0];
    }


}
