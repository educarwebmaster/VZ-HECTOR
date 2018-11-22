using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class DPR2 : MonoBehaviour, IDropHandler
{
    public bool Ocupado;
    public float ID;
    public MATEMATICA7_U1 Controlador;
    public GameObject item//variable autoasignable a los elementos hijos
    {
        get
        {
            if (transform.childCount > 0)
            { 
                return transform.GetChild(0).gameObject;// mirar el ultimo hijo
            }
            return null;
        }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    #region IdropHandler implementation

    public void OnDrop(PointerEventData eventData)//al colocar un objeto
    {
        if (Ocupado)
        {

        }
        else
        {
            if (!item)//verificar si no hay un objeto arrastrandose
            {
                InsertDrag();
            }
            else
            {
                RestoreDrag();
            }
        }
        
    }

    #endregion

    public void RestoreDrag()
    {
        DRR2.item.GetComponent<DRR2>().Restore();//reestaurar pocicion
    }

    public void InsertDrag()// incertar elemento como hijo
    {
        Ocupado = true;
        DRR2.item.transform.SetParent(transform);
        DRR2.item.GetComponent<LayoutElement>().ignoreLayout = false;
        DRR2.item.GetComponent<DRR2>().enabled = false;
        if (Controlador.Boton)
        {

        }
        else
        {
            Controlador.contador++;
        }
    }

    public void Verifi()
    {
        if (item.GetComponent<DRR2>().ID == ID)//comparar id para saber si son correctos
        {
            Controlador.Correctos++;
        }
        else
        {
            Controlador.Incorrectos++;
        }
    }
}
