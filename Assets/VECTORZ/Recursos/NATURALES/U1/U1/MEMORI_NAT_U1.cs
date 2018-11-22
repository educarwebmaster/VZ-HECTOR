using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MEMORI_NAT_U1 : MonoBehaviour {


    public int ID;
    public Image Image;
    public Text Texto;
    public CONTROLER_MEMORI_NATURALES_U1 Controlador;
    public bool Ocupado = false;
    public bool Desabilitado;
    // al iniciar
    void Start () {
        Ocupado = false;
        GetComponent<Animator>().Play("Ocultar");
	}

    public void Verificar()
    {
        if (!Desabilitado)
        {
            if (!Ocupado)
            {
                Ocupado = true;
                AnimationShow();
                Controlador.Verificacion(ID, this.gameObject);
            }
        }
    }

    public void AnimationShow()
    {
        this.GetComponent<Animator>().Play("Mostrar");
    }

    public void AnimationHide()
    {
        this.GetComponent<Animator>().Play("Ocultar");
    }
}
