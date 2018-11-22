/***********************************************

Sistema Drag And Drop 
Creado Originalmente por : Hector Stiven Gomez Ramirez
Modificado por :

Esta script esta creada para tener los componentes logicos 
del elemento Drop o receptor

*********************************************/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class Drop3 : MonoBehaviour, IDropHandler
{
    public enum TipeDrop
    {//lista para saber que tipo de receptor es
        Objetivo,
        Inicial
    }
    public float ID;
    public TipeDrop DropTipe = TipeDrop.Inicial;
    public bool Check;
    public MATEMATICAS6CONTROLER Controlador;

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

    #region IdropHandler implementation
    public void OnDrop(PointerEventData eventData)//al colocar un objeto
    {
        if (!item)//verificar si no hay un objeto arrastrandose
        {
            InsertDrag();
        }
        else
        {
            if (DropTipe == TipeDrop.Objetivo)
            {
                InsertDrag();
            }

            if (DropTipe == TipeDrop.Inicial)
            {
                RestoreDrag();
            }
        }
    }

    #endregion
    public void RestoreDrag()
    {
        Drag3.item.GetComponent<Drag3>().Restore();//reestaurar pocicion
    }

    public void InsertDrag()// incertar elemento como hijo
    {
        Drag3.item.transform.SetParent(transform);
        //Drag.item.GetComponent<LayoutElement>().ignoreLayout = false;
        if (item.GetComponent<Drag3>().ID == ID)//comparar id para saber si son correctos
        {
            Controlador.contador_buenos++;
            Controlador.Verificar();
            //RestoreDrag();
        }
        else
        {
            Controlador.Verificar();
            //RestoreDrag();
        }
    }
}
