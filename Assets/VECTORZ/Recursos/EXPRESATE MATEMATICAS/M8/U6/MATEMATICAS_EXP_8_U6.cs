using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MATEMATICAS_EXP_8_U6 : MonoBehaviour {
	public RETROS Controler;
    public GameObject[] Drops;
	public Transform contenedor;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

	public void Rand(){
		for(int i = 0; i < contenedor.childCount;i++){
			contenedor.GetChild(i).transform.SetSiblingIndex(Random.Range(0,contenedor.childCount));
		}
		for(int i = 0; i < contenedor.childCount;i++){
			contenedor.GetChild(i).transform.gameObject.GetComponent<DPORDER>().ID = i;
		}
	}

	public void Restore()
    {
        Controler.Restore();
        for (int i = 0; i < Drops.Length; i++)
        {
			Drops[i].transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.SetActive(false);
			Drops[i].transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.SetActive(false);
            Drops[i].transform.GetChild(0).gameObject.GetComponent<DRORDER>().RestoreLayout();
        }
   	}

    public void Verificar()
    {
        for (int i = 0;i<Drops.Length;i++)
        {
            if (Drops[i].GetComponent<DPORDER>().ID == Drops[i].transform.GetChild(0).gameObject.GetComponent<DRORDER>().ID)
            {
                Controler.Aumentar();
				Drops[i].transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.SetActive(true);
            }
            else
            {
                Controler.Disminuir();
				Drops[i].transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.SetActive(true);
            }
        }
        StartCoroutine("saltar");
    }

	public IEnumerator saltar(){
		yield return new WaitForSeconds(2);
		Controler.Verficar(Controler.Correctos, Drops.Length);
        StartCoroutine(Controler.FINAL());
	}
}
