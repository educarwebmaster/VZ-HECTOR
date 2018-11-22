using UnityEngine;
using System.Collections;

[System.Serializable]
public class Elemento_Alumbrado
{
    public Material[] Objetos;
    public AudioClip AudioObjeto;
    public float Time;


    public void Cambiar(Shader cambiador)
    {
        for (int i = 0;i < Objetos.Length;i++)
        {
            Objetos[i].shader = cambiador;
        }
    }
}

public class DREAM_UP_CAMBIAR : MonoBehaviour {

    public Elemento_Alumbrado[] Elementos;
    public AudioSource Audio;
    public Shader Normal;
    public Shader Alumbrado;
    public int i;
    private float tiempo;

    void Start ()
    {
        i = 0;
        tiempo = Elementos[i].Time;
        Reproducir(0);
    }
	
	void Update ()
    {
        tiempo -= 0.01f;
        if (tiempo < 0)
        {
            Desabilitar();
            i += 1;
            tiempo = Elementos[i].Time;
            Reproducir(i);
        }
    }

    public void Reproducir(int e)
    {
        Elementos[e].Cambiar(Alumbrado);
        Audio.clip = Elementos[e].AudioObjeto;
        Audio.Play();
    }

    public void Desabilitar()
    {
        for (int i = 0;i < Elementos.Length;i++)
        {
            Elementos[i].Cambiar(Normal);
        }
    }
}
