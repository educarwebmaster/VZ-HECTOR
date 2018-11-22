/***********************************************

Sistema Drag And Drop 
Creado Originalmente por : Hector Stiven Gomez Ramirez
Modificado por :
Sistema Multiple Drag
*********************************************/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class DropMultiple : MonoBehaviour, IDropHandler
{
    public bool Ocupado;
    public float ID;
    public GameObject item//variable autoasignable a los elementos hijos
    {
        get
        {
            if (transform.childCount > 0)
            { 
                return transform.GetChild(transform.childCount - 1).gameObject;// mirar el ultimo hijo
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
                InsertDrag();
            }
        }
        
    }
    #endregion

    public void RestoreDrag()
    {
        DragMultiple.item.GetComponent<DragMultiple>().Restore();//reestaurar pocicion
    }

    public void InsertDrag()// incertar elemento como hijo
    {
        //Ocupado = true;
        DragMultiple.item.transform.SetParent(transform);
        DragMultiple.item.GetComponent<LayoutElement>().ignoreLayout = false;
        DragMultiple.item.GetComponent<DragMultiple>().enabled = false;
    }

}

