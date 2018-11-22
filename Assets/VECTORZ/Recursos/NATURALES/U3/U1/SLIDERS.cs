using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SLIDERS : MonoBehaviour {
	public Sprite[] Sliders;
	public int Estado;
	public GameObject After,Next;
	public Image Fondo;

	// Use this for initialization
	void Start () {
		Restore();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void next(){
		if(Estado < Sliders.Length-1){
			Estado++;
			Fondo.sprite = Sliders[Estado];
		}
		if(Estado == Sliders.Length-1){
			Next.SetActive(false);
		}else{
			Next.SetActive(true);
		}
		if(Estado == 0){
			After.SetActive(false);
		}else{
			After.SetActive(true);
		}
	}

	public void after(){
		if(Estado > 0){
			Estado--;
			Fondo.sprite = Sliders[Estado];
		}
		if(Estado == 0){
			After.SetActive(false);
		}else{
			After.SetActive(true);
		}
		if(Estado == Sliders.Length-1){
			Next.SetActive(false);
		}else{
			Next.SetActive(true);
		}
	}

	public void Restore(){
		Estado=0;
		Fondo.sprite = Sliders[Estado];
		Next.SetActive(true);
		After.SetActive(false);
	}

	public void info(GameObject myinfo){
		StartCoroutine("Aparecer",myinfo);
	}

	public IEnumerator Aparecer(GameObject myinfo){
		myinfo.SetActive(true);
		yield return new WaitForSeconds(5);
		myinfo.SetActive(false);
	}
}
