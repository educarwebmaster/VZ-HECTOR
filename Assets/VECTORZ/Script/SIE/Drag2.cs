/*********************************************

Sistema Drag And Drop 
Creado Originalmente por : Hector Stiven Gomez Ramirez
Modificado por :

Esta script esta creada para tener los componentes logicos 
del elemento Drag o que se arrastra

*********************************************/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class Drag2 : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Camera Main;
    public static GameObject item;// Elemento propio que sirve para modificarse a si mismo y enviarlo como parametro
    public float ID;// id del objeto que se compara con su elemento recentor
    public Color hoverColor;//color de hover
    public Transform hoverParent;//padre del elemento al arrastrar
    public Transform startParent;//padre inicial del elemento
    public Vector3 Initial;
    public Transform InitialParent;
    Vector3 startPosition;// vector que guarda la pocicion inicial
    Color startColor;// variable que guarda el color inicial
    Image imageElement;// variable que guarda el componente imagen

    void Awake()
    {
        Initial = transform.localPosition;
        InitialParent = this.transform.parent;
        startPosition = Camera.main.WorldToScreenPoint(transform.position);
        startParent = this.transform.parent;
    }

    public void OnBeginDrag(PointerEventData eventData)//al iniciar el arrastre
    {
        item = gameObject;
        startParent = this.transform.parent;
        startPosition = Camera.main.WorldToScreenPoint(transform.position);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        item.GetComponent<LayoutElement>().ignoreLayout = true;
        imageElement = GetComponent<Image>();
        startColor = imageElement.color;
    }

    public void OnDrag(PointerEventData eventData)// al estar arrastrando
    {
        transform.SetParent(hoverParent, false);
        imageElement.color = hoverColor;
        Vector3 screenPoint = Input.mousePosition;//posicionar segun el mouse
        screenPoint.z = 0.5f;
        transform.position = Main.ScreenToWorldPoint(screenPoint);//posicionar el vector z
    }

    public void OnEndDrag(PointerEventData eventData)//al finalizar el arrastre
    {
        item = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        imageElement.color = startColor;
        if (hoverParent == transform.parent)//regresar a su posicion inicial
        {
            transform.SetParent(startParent, false);
            transform.position = Camera.main.ScreenToWorldPoint(startPosition);
        }
    }

    public void Restore()//restaurar variables
    {
        item = null;
        transform.SetParent(startParent, false);
        transform.position = Camera.main.ScreenToWorldPoint(startPosition);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        imageElement.color = startColor;
    }

    public void Recreate()
    {
        item = null;
        transform.SetParent(InitialParent, false);
        transform.localPosition = Initial;
        //item = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        //imageElement.color = startColor;
    }

}

