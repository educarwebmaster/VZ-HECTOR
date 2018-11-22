using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click_efect : MonoBehaviour {
	public Camera Main;
	public void Click(GameObject obj){
		this.transform.SetParent(obj.transform.parent);
		this.transform.localPosition = obj.transform.localPosition;
		//this.GetComponent<RectTransform>().anchoredPosition3D = objeto.GetComponent<RectTransform>().anchoredPosition3D;
		this.GetComponent<Animator>().Play("click");
	}
}
