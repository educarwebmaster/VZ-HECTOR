using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class COMPRENDE_MAT3_U3_sistem{

	public Sprite regla, fondo, contenedor, info, infoimg;
	public Sprite[] botones, botonessobre;
	public  int respuesta;

	
}



public class COMPRENDE_MAT3_U3 : MonoBehaviour 
{
	public RETROS Controlador;
	public  COMPRENDE_MAT3_U3_sistem[] escenas;
	public Image regla, fondo, contenedorimg, info, pasar, pasar001, pasar2, infoimg;
	public Sprite[] pasarimg, pasarimg001, pasarimg2;
	public Image[] botones;
	public int slider, seleccionado, sliderpasar;
	public GameObject chulos, malos,siguiente,atras;

	
	public void randomizar ()
	{
		for (int i=0;i<botones.Length;i++)
		{
			botones[i].transform.SetSiblingIndex(Random.Range(0,2));
		}
	}

	public void cambiar(int s)
	{
		regla.sprite= escenas[s].regla;
		fondo.sprite= escenas[s].fondo;
		infoimg.sprite= escenas[s].infoimg;
		contenedorimg.sprite= escenas[s].contenedor;
		info.sprite= escenas[s].info;
		chulos.SetActive(false);
		malos.SetActive(false);
		
		for (int i=0;i<botones.Length;i++)
		{
			botones[i].sprite= escenas[s].botones[i];
		}	
		Controlador.Informacion_mostrar(1);	
	}

	public void seleccionar (int r)
	{
		for (int i=0;i<botones.Length;i++)
		{
			botones[i].sprite= escenas[slider].botones[i];
		}
		botones[r].sprite= escenas[slider].botonessobre[r];		
		seleccionado = r;	

		if (seleccionado == escenas[slider].respuesta)
		{
			Controlador.Aumentar();
			chulos.SetActive(true);
		}
		else
		{
			Controlador.Disminuir();
			malos.SetActive(true);
		}
		StartCoroutine(avanzar());	
	}


	public IEnumerator avanzar()
	{
		yield return new WaitForSeconds (2);
		slider++;
		if (slider == 4)
		{
			Controlador.Verficar(Controlador.Correctos,3);
			StartCoroutine(Controlador.FINAL());
		}
		else
		{
			cambiar(slider);
		}
		
	}

	public void aumentarpasar()
	{
		if (sliderpasar<3)
		{
			sliderpasar++;
			pasar.sprite=pasarimg[sliderpasar];
            pasar001.sprite = pasarimg001[sliderpasar];
            pasar2.sprite=pasarimg2[sliderpasar];
        }

        if (sliderpasar==3)
        {
            siguiente.SetActive(false);
        }
        else
        {
            siguiente.SetActive(true);
            atras.SetActive(true);
        }
	}

	public void disminuirpasar()
	{
		if (sliderpasar>0)
		{
			sliderpasar--;
			pasar.sprite=pasarimg[sliderpasar];
            pasar001.sprite = pasarimg001[sliderpasar];
            pasar2.sprite=pasarimg2[sliderpasar];
            siguiente.SetActive(true);
            atras.SetActive(true);
        }
        else
        {
            atras.SetActive(false);
        }

        if (sliderpasar == 0)
        {
            atras.SetActive(false);
        }
        else
        {
            siguiente.SetActive(true);
            atras.SetActive(true);
            
        }
    }

	public void Restore ()
	{
		Controlador.Restore();
		chulos.SetActive(false);
		malos.SetActive(false);
		cambiar (0);
		slider=0;
		seleccionado=0;
		sliderpasar=0;
		pasar.sprite=pasarimg[0];
		pasar2.sprite=pasarimg2[0];
        pasar001.sprite = pasarimg001[sliderpasar];
    }







	
}





	
