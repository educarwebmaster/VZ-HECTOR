using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class DPORDER : MonoBehaviour, IDropHandler
{
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

    #region IdropHandler implementation

    public void OnDrop(PointerEventData eventData)//al colocar un objeto
    {
 
            if (!item)//verificar si no hay un objeto arrastrandose
            {
                InsertDrag();
            }
            else
            {
                ReOrder();
            }
        
    }

    #endregion

    public void RestoreDrag()
    {
        DRORDER.item.GetComponent<DRORDER>().Restore();//reestaurar pocicion

    }

    public void InsertDrag()// incertar elemento como hijo
    {
        DRORDER.item.transform.SetParent(transform);
        DRORDER.item.GetComponent<LayoutElement>().ignoreLayout = false;
        DRORDER.item.GetComponent<DRORDER>().enabled = false;
    }

    public void ReOrder()
    {
        ORDER_CONTROLLER.ItemTwo = transform.GetChild(0).gameObject;
        ORDER_CONTROLLER.ItemTwo.GetComponent<CanvasGroup>().blocksRaycasts = false;
        ORDER_CONTROLLER.ItemTwo.GetComponent<LayoutElement>().ignoreLayout = true;
        ORDER_CONTROLLER.ItemTwo.transform.SetParent(ORDER_CONTROLLER.PositionInitial, false);
        ORDER_CONTROLLER.PositionInitial.GetComponent<DPORDER>().enabled = true;
        
        ORDER_CONTROLLER.ItemFirst.transform.SetParent(this.transform, false);
        ORDER_CONTROLLER.ItemFirst.GetComponent<LayoutElement>().ignoreLayout = false;

        ORDER_CONTROLLER.ItemTwo.GetComponent<CanvasGroup>().blocksRaycasts = true;
        ORDER_CONTROLLER.ItemTwo.GetComponent<LayoutElement>().ignoreLayout = false;
        ORDER_CONTROLLER.ItemTwo = null;
        ORDER_CONTROLLER.ItemFirst = null;

    }
}
