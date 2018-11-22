using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ElementMentalGame
{
    public int ID;
    public Sprite Imagen;
	public string Nombre;
    public bool Solucionado;
}

public class CONTROLER_MEMORI_NATURALES_U1 : MonoBehaviour {
    public ElementMentalGame[] Elements;
    public Transform Fhater;
    public GameObject ChildElement;
    public GameObject ChildElement2;
    public GameObject Button_uno;
    public GameObject Button_dos;
    public GameObject setuno;
    public GameObject setdos;
    public int Ocupado = 0;
    int Iniciado;
    int ID_primer;
    int contador;
    public int[] RandomTrans;
    public GameObject[] cache1;
    public GameObject[] cache2;
	public int Puntos;
    public int Intentos;
    public Text Intentos_text;
    public Text Puntos_text;
	public GameObject RetroBuena;
	public GameObject RetroMala;
    public GameObject Infom;
	
//construir las listas de los elementos random
    public void ConstrucElemenst()
    {
        Intentos = 12;
        Intentos_text.text = "" + Intentos;
        cache1 = new GameObject[Elements.Length];
        cache2 = new GameObject[Elements.Length];
        for(int i = 0;i < cache1.Length;i++){
           cache1[i] = null;
		}
        for(int i = 0;i < cache2.Length;i++){
           cache2[i] = null;
		}
        for (int i = 0;i < Elements.Length;i++)
        {
            GameObject NewElement = Instantiate(ChildElement) as GameObject;//intanciar boton
            NewElement.transform.SetParent(Fhater, false);//asignale papa
            NewElement.GetComponent<MEMORI_NAT_U1>().ID = Elements[i].ID;//asignale id
            NewElement.GetComponent<MEMORI_NAT_U1>().Image.sprite = Elements[i].Imagen;//asignarle la imagen
            NewElement.SetActive(true);//activarlo
            cache1[i] = NewElement;
            GameObject NewElement2 = Instantiate(ChildElement2) as GameObject;
            NewElement2.transform.SetParent(Fhater, false);
            NewElement2.GetComponent<MEMORI_NAT_U1>().ID = Elements[i].ID;
            NewElement2.GetComponent<MEMORI_NAT_U1>().Texto.text = Elements[i].Nombre;
            NewElement2.SetActive(true);
            cache2[i] = NewElement2;
        }
        RandomPosition();
    }

    public void Verificacion(int ID_,GameObject Button)
    {
        if (Ocupado == 0)//seleccionar el primer elemento
        {
            Ocupado = 1;
            ID_primer = ID_;
            Button_uno = Button;
        }
        else if(Ocupado == 1)//seleccionar el segundo elemento
        {
            OcupeAll();
            Ocupado = 2;
            Button_dos = Button;
            if (ID_ == ID_primer)//verificar si el id es igual al primer elemento
            {
                for (int i = 0; i < Elements.Length; i++)//desavilitar si son correctos
                {
                    if (ID_ == Elements[i].ID)
                    {
                        Elements[i].Solucionado = true;
                        Button_uno.GetComponent<MEMORI_NAT_U1>().Desabilitado = true;
                        Button_dos.GetComponent<MEMORI_NAT_U1>().Desabilitado = true;
                        StartCoroutine("AllRes");
                        Puntos++;
                    }
                }
                Button_uno = null;
                Button_dos = null;
            }
            else
            {
                StartCoroutine("AllRes");
                Button_uno = null;
                Button_dos = null;
            }
            Intentos--;
            if(Intentos <= 0){
                Verify();
            }
            if(Puntos == 5){
                Verify();
            }

        }
        Intentos_text.text = "" + Intentos;
    }

    public void RandomPosition()
    {
        RandomTrans = new int[Fhater.transform.childCount];
        for (int e = 0; e < Fhater.transform.childCount; e++)
        {
            RandomTrans[e] = Random.Range(4, RandomTrans.Length);//asignar variables random
        }
        for (int i = 4; i < Fhater.transform.childCount; i++)
        {
            Fhater.GetChild(i).SetSiblingIndex(RandomTrans[i]);//asignar posiciones en la gerarquia random
        }
        setuno.transform.SetSiblingIndex(7);
        setdos.transform.SetSiblingIndex(9);
        setuno.SetActive(true);
        setdos.SetActive(true);
    }

    public IEnumerator AllRes()
    {
        yield return new WaitForSeconds(2);
        ResAll();
    }
//desactivar todos
    public void OcupeAll()
    {
        for (int a = 0; a < Fhater.transform.childCount; a++)
        {
            if(Fhater.GetChild(a).GetComponent<MEMORI_NAT_U1>()){
                if (!Fhater.GetChild(a).GetComponent<MEMORI_NAT_U1>().Desabilitado)
                {
                    for (int i = 0; i < Fhater.transform.childCount; i++)
                    {
                        Fhater.GetChild(i).GetComponent<MEMORI_NAT_U1>().Ocupado = true;
                    }
                }
            }
        }
    }

    public void Restore(){
        for(int i = 0;i < cache1.Length;i++){
            Destroy(cache1[i]);
        }
        for(int i = 0;i < cache1.Length;i++){
            Destroy(cache2[i]);
        }
        Ocupado = 0;
        Iniciado = 0;
        ID_primer = 0;
        contador = 0;
        RandomTrans = new int[0];
        Intentos = 0;
        Puntos = 0;
    }
//activar a todos los no correctos
    public void ResAll()
    {
        for (int a = 0; a < Fhater.transform.childCount; a++)
        {
            if(Fhater.GetChild(a).GetComponent<MEMORI_NAT_U1>()){
                if (!Fhater.GetChild(a).GetComponent<MEMORI_NAT_U1>().Desabilitado){
                    if (Fhater.GetChild(a).GetComponent<MEMORI_NAT_U1>().Ocupado){
                        Fhater.GetChild(a).GetComponent<MEMORI_NAT_U1>().Ocupado = false;
                        Fhater.GetChild(a).GetComponent<MEMORI_NAT_U1>().AnimationHide();
                    }
                }
            }
        }
        Ocupado = 0;
    }
//verificar los elementos correctos y añadir puntos en el controlador
    public void Verify()
    {
            if (Intentos > 1)
            {
                RetroBuena.SetActive(true);
				RetroMala.SetActive(false);
            }
            else
            {
				RetroBuena.SetActive(false);
                RetroMala.SetActive(true);
			}
            Intentos_text.text = "0";
    }

    public void Info(){
        StartCoroutine("Miinfo");
    }

    public IEnumerator Miinfo(){
        Infom.SetActive(true);
        yield return new WaitForSeconds(4);
        Infom.SetActive(false);
    }
}


