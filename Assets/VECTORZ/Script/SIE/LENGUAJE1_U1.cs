using UnityEngine;
using System.Collections;

public class LENGUAJE1_U1 : MonoBehaviour {
    public RETROS Controler;
    public GameObject[] Drops;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Restore()
    {
        Controler.Restore();
        for (int i = 0; i < Drops.Length; i++)
        {
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
            }
            else
            {
                Controler.Disminuir();
            }
        }
        Controler.Verficar(Controler.Correctos, Drops.Length);
        StartCoroutine(Controler.FINAL());
    }

}
