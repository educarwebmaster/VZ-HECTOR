using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DROPDOWNS : MonoBehaviour {
	RectTransform container;
	public bool IsOpen;
	public string[] Items;
	public GameObject b_boton;
	public string ItemSelect;

	// Use this for initialization
	void Start () {
		container = transform.Find("Container").GetComponent<RectTransform>();
		IsOpen = false;
		CrearItems();
		transform.GetChild(0).gameObject.GetComponent<Text>().text = "Seleccionar";
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 scale = container.localScale;
		scale.y = Mathf.Lerp(scale.y,IsOpen ? 1: 0,Time.deltaTime * 12);
		container.localScale = scale;
	}

	public void Check(){
		if(IsOpen){
			IsOpen = false;
		}else{
			IsOpen = true;
		}
	} 

	public void Seleccionar(Text Item){
		ItemSelect = Item.text;
		transform.GetChild(0).gameObject.GetComponent<Text>().text = ItemSelect;
		IsOpen = false;
	}

	public void CrearItems(){
		for(int i = 0;i < Items.Length;i++){
			GameObject NewItem = Instantiate(b_boton) as GameObject;
			NewItem.transform.SetParent(container.transform);
			NewItem.transform.localScale = b_boton.transform.localScale;
			NewItem.transform.localPosition = b_boton.transform.localPosition;
			NewItem.transform.GetChild(0).gameObject.GetComponent<Text>().text = Items[i];
			NewItem.SetActive(true);
		}
	}
}
