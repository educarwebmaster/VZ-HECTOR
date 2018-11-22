
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class DPR : MonoBehaviour, IDropHandler
{
    public float ID;
    public RINGLETE_U1_CONTROLER Controlador;
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
        if (!item)//verificar si no hay un objeto arrastrandose
        {
            RestoreDrag();
        }
        else
        {
            InsertDrag();
        }
    }

    #endregion

    public void RestoreDrag()
    {
        DRR.item.GetComponent<DRR>().Restore();//reestaurar pocicion
    }

    public void InsertDrag()// incertar elemento como hijo
    {
        DRR.item.transform.SetParent(transform);
        DRR.item.GetComponent<LayoutElement>().ignoreLayout = false;
        DRR.item.GetComponent<DRR>().enabled = false;
        if (item.GetComponent<DRR>().ID == ID)//comparar id para saber si son correctos
        {
            Controlador.Verificar(true);
        }
        else
        {
            Controlador.Verificar(false);
        }
    }
}
