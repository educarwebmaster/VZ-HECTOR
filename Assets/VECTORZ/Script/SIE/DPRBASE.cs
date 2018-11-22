using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class DPRBASE : MonoBehaviour, IDropHandler
{
    public bool Ocupado;
    public float ID;
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
        DRRBASE.item.GetComponent<DRRBASE>().Restore();//reestaurar pocicion
    }

    public void InsertDrag()// incertar elemento como hijo
    {
        Ocupado = true;
        DRRBASE.item.transform.SetParent(transform);
        DRRBASE.item.GetComponent<LayoutElement>().ignoreLayout = false;
        DRRBASE.item.GetComponent<DRRBASE>().enabled = false;
    }

    public void Verifi()
    {
        
    }
}

