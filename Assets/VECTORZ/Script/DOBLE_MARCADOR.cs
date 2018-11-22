using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOBLE_MARCADOR : MonoBehaviour {
	public Transform hijo;
	// Update is called once per frame
	void Update () {
		if(this.gameObject.activeSelf){
			hijo.SetParent(this.transform);
		}
	}
}
