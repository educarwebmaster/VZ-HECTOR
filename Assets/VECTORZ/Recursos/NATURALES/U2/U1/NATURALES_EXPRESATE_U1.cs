using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NATURALES_EXPRESATE_U1 : MonoBehaviour {
    public RETROS Controler;
	public Text tiempo;
	public int Segundos,Buenos,Malos;
	public string[] Textos1,Textos2;
	public int[] ID1,ID2;
    public GameObject[] DropsOdenar,DragsOrdenar,Drags,Drops,Textos;
	public GameObject RetroBO,RetroMO;
	public Sprite[] Imagenes1,Imagenes2,Imagenes3,Imagenes4;
	public Image RetroB,RetroM,Presentacion,Ejercicio2,Info2;
	public bool tacti;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CambiarSexo(int sex){
		if(sex == 0){
			RetroB.sprite = Imagenes3[0];
			RetroM.sprite = Imagenes3[1];
			Presentacion.sprite =  Imagenes3[2];
			Ejercicio2.sprite =  Imagenes3[3];
			Info2.sprite = Imagenes3[4];
			for(int i = 0;i < DropsOdenar.Length;i++){
				DragsOrdenar[i].GetComponent<Image>().sprite = Imagenes1[i];
			}
			for(int i = 0;i<Textos.Length;i++){
				Textos[i].transform.GetChild(0).gameObject.GetComponent<Text>().text = Textos1[i];
				Textos[i].GetComponent<DragMultiple>().ID = ID1[i];
			}
		}else{
			RetroB.sprite = Imagenes4[0];
			RetroM.sprite = Imagenes4[1];
			Presentacion.sprite =  Imagenes4[2];
			Ejercicio2.sprite =  Imagenes4[3];
			Info2.sprite = Imagenes4[4];
			for(int i = 0;i < DropsOdenar.Length;i++){
				DragsOrdenar[i].GetComponent<Image>().sprite = Imagenes2[i];
			}
			for(int i = 0;i<Textos.Length;i++){
				Textos[i].transform.GetChild(0).gameObject.GetComponent<Text>().text = Textos2[i];
				Textos[i].GetComponent<DragMultiple>().ID = ID2[i];
			}
		}
	}

	public void Restore()
    {
        Controler.Restore();
		Buenos = 0;
		Malos = 0;
		tacti = false;
		StopCoroutine("TiempoInit");
		tiempo.text = "Tiempo: 60";
		Segundos = 0;
		RetroBO.SetActive(false);
		RetroMO.SetActive(false);
        for (int i = 0; i < DropsOdenar.Length; i++)
        {
            DropsOdenar[i].transform.GetChild(0).gameObject.GetComponent<DRORDER>().RestoreLayout();
        }
        for (int i = 0; i < Drags.Length; i++)
        {
            Drags[i].GetComponent<DragMultiple>().enabled = true;
            Drags[i].GetComponent<DragMultiple>().Restore();
        }
        for (int i = 0; i < Drops.Length; i++)
        {
            Drops[i].GetComponent<DropMultiple>().Ocupado = false;
        }
   }

   public void Verificar1()
   {
	    tacti = false;
	   	StopCoroutine("TiempoInit");
        for (int i = 0;i<DropsOdenar.Length;i++)
        {
            if (DropsOdenar[i].GetComponent<DPORDER>().ID == DropsOdenar[i].transform.GetChild(0).gameObject.GetComponent<DRORDER>().ID)
            {
                Buenos++;
            }
            else
            {
                Malos++;
            }
        }
		if(Buenos == 9){
			Buenos = 1;
			RetroBO.SetActive(true);
		}else{
			Buenos = 0;
			RetroMO.SetActive(true);
		}
    }

	public void Verificar2()
    {
        for (int i = 0;i < Drops.Length;i++)
        {
			for (int e = 0;e < Drops[i].transform.childCount;e++){
				if(Drops[i].GetComponent<DropMultiple>().ID ==Drops[i].transform.GetChild(e).gameObject.GetComponent<DragMultiple>().ID){
					Buenos++;
					Controler.Aumentar();
				}else{
					Controler.Disminuir();
				}
			}
        }
		Controler.Verficar(Buenos, 4);
		StartCoroutine(Controler.FINAL());
    }

	public void IniciarTiempo(){
		Segundos = 60;
		tacti = true;
		StartCoroutine("TiempoInit");
	}

	public IEnumerator TiempoInit(){
       if(tacti){
		Segundos--;
		tiempo.text = "Tiempo: " + Segundos;
		if(Segundos<0){
			Verificar1();
		}
		yield return new WaitForSeconds(1);
		StartCoroutine("TiempoInit");
	   }
	}

	public void Info(GameObject g)
    {
        StartCoroutine("Info_c", g);
    }

    public IEnumerator Info_c(GameObject g)
    {
        g.SetActive(true);
        yield return new WaitForSeconds(4);
        g.SetActive(false);
    }
}
