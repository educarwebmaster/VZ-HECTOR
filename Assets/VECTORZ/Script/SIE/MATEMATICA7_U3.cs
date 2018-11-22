using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MATEMATICA7_U3 : MonoBehaviour {

    public RETROS Controler;
    public Color ColorNormal;
    public Color ColorSeleccionado;
    public Color ColorDesactivado;
    public Image[] img;
    public int Seleccion = 0;
    public int NumeroS;
    public int contador;

    public void Restore()
    {
        Controler.Restore();
        contador = 0;
        NumeroS = 0;
        Seleccion = 0;
        for (int i = 0; i < img.Length; i++)
        {
                img[i].gameObject.GetComponent<Button>().enabled = true;
                img[i].color = ColorNormal;
        }
    }

    public void Seleccionar(int Numero)
    {
        if(Seleccion == 0)
        {
            
            NumeroS = Numero;
            Seleccion++;
            img[Numero].color = ColorSeleccionado;
            img[Numero].gameObject.GetComponent<Button>().enabled = false;

        }
        else if(Seleccion == 1)
        {
            Seleccion = 0;
            if((NumeroS == 0 && Numero == 5) || (NumeroS == 2 && Numero == 4) || (NumeroS == 1 && Numero == 3) || (NumeroS == 5 && Numero == 0) || (NumeroS == 4 && Numero == 2) || (NumeroS == 3 && Numero == 1))
            {
                        contador++;
                        Controler.Verficar(Numero, Numero);
                        Controler.Aumentar();
                        img[Numero].gameObject.GetComponent<Button>().enabled = false;
                        img[Numero].color = ColorDesactivado;
                        img[NumeroS].gameObject.GetComponent<Button>().enabled = false;
                        img[NumeroS].color = ColorDesactivado;
            }else{
                Controler.Verficar(NumeroS, Numero);
                Controler.Disminuir();
                
                img[Numero].gameObject.GetComponent<Button>().enabled = true;
                img[Numero].color = ColorNormal;
                img[NumeroS].gameObject.GetComponent<Button>().enabled = true;
                img[NumeroS].color = ColorNormal;


            }
            if (contador == 3)
            {
                Controler.Verificar_Final();
            }
        }
    }

}
