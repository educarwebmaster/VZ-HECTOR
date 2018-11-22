using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class DRRSIN : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Camera Main;
    public static GameObject item;// Elemento propio que sirve para modificarse a si mismo y enviarlo como parametro
    public float ID;// id del objeto que se compara con su elemento recentor
    public Color hoverColor;//color de hover
    public Transform hoverParent;//padre del elemento al arrastrar
    public Transform startParent;//padre inicial del elemento
    public Vector3 startPosition;// vector que guarda la pocicion inicial

    void Start()
    {
        item = gameObject;
        startParent = this.transform.parent;
        startPosition = Camera.main.WorldToScreenPoint(transform.position);
    }

    public void OnBeginDrag(PointerEventData eventData)//al iniciar el arrastre
    {
        item = gameObject;
        startPosition = Camera.main.WorldToScreenPoint(transform.position);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        item.GetComponent<LayoutElement>().ignoreLayout = true;
    }

    public void OnDrag(PointerEventData eventData)// al estar arrastrando
    {
        transform.SetParent(hoverParent, false);
        Vector3 screenPoint = Input.mousePosition;//posicionar segun el mouse
        screenPoint.z = 0.5f;
        transform.position = Main.ScreenToWorldPoint(screenPoint);//posicionar el vector z
    }

    public void OnEndDrag(PointerEventData eventData)//al finalizar el arrastre
    {
        item = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        Vector3 screenPoint = Input.mousePosition;//posicionar segun el mouse
        screenPoint.z = 0.5f;
        transform.position = Main.ScreenToWorldPoint(screenPoint);//posicionar el vector z
    }

    public void Restore()//restaurar variables
    {
        item = null;
        transform.SetParent(startParent, false);
        transform.position = Camera.main.ScreenToWorldPoint(startPosition);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
